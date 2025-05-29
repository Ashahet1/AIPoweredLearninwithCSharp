// Services/USPTOApiClient.cs

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PatentAnalyzer.USPTOApiModels;
using System.Text.Json; // Make sure this is included
using System.IO;       // Make sure this is included

namespace PatentAnalyzer.Services
{
    public class USPTOApiClient : IUSPTOApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseApiUrl;
        private readonly string _jsonOutputDirectory; // New property for output directory

        public USPTOApiClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["USPTOApi:ApiKey"] ?? throw new ArgumentNullException("USPTOApi:ApiKey not found in configuration.");
            _baseApiUrl = configuration["USPTOApi:BaseUrl"] ?? "https://api.uspto.gov/api/v1/";
            _httpClient.BaseAddress = new Uri(_baseApiUrl);

            _httpClient.DefaultRequestHeaders.Add("X-API-KEY", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            // --- NEW: Get JSON output directory from configuration ---
            _jsonOutputDirectory = configuration["AppConfig:JsonOutputDirectory"] ?? "JsonOutput"; // Default to "JsonOutput" folder
            Directory.CreateDirectory(_jsonOutputDirectory); // Ensure the directory exists
        }

        public async Task<PatentApplicationSearchResponse> SearchPatentApplicationsAsync(string searchTerm, int limit, int offset = 0)
        {
            string requestUri = $"patent/applications/search?q={Uri.EscapeDataString(searchTerm)}&rows={limit}&start={offset}";

            Console.WriteLine($"Making USPTO API call to: {_httpClient.BaseAddress}{requestUri}");

            var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();

            // --- NEW: Save raw JSON to a file ---
            string fileName = $"uspto_response_{DateTime.Now:yyyyMMdd_HHmmss}.json";
            string filePath = Path.Combine(_jsonOutputDirectory, fileName);

            // Use JsonSerializer to pretty-print for readability
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonDocument = JsonDocument.Parse(jsonString);
            string formattedJson = JsonSerializer.Serialize(jsonDocument, options);

            await File.WriteAllTextAsync(filePath, formattedJson);
            Console.WriteLine($"Raw USPTO API response saved to: {filePath}");
            // --- END NEW ---

            var deserializeOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var apiResponse = JsonSerializer.Deserialize<PatentApplicationSearchResponse>(jsonString, deserializeOptions);

            return apiResponse ?? new PatentApplicationSearchResponse();
        }
    }
}