using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PatentAnalyzer.USPTOApiModels;
using System.Text.Json;

namespace PatentAnalyzer.Services
{
    public class USPTOApiClient : IUSPTOApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseApiUrl;

        public USPTOApiClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["USPTOApi:ApiKey"] ?? throw new ArgumentNullException("USPTOApi:ApiKey not found in configuration.");
            _baseApiUrl = configuration["USPTOApi:BaseUrl"] ?? "https://api.uspto.gov/api/v1/";
            _httpClient.BaseAddress = new Uri(_baseApiUrl);

            // This is where the API key is added to the HTTP client's default headers.
            // Any request made by this _httpClient instance will now include these headers.
            _httpClient.DefaultRequestHeaders.Add("X-API-KEY", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<PatentApplicationSearchResponse> SearchPatentApplicationsAsync(string searchTerm, int limit, int offset = 0)
        {
            // The API key is already in the default headers, so it's not needed in the URL.
            string requestUri = $"patent/applications/search?q={Uri.EscapeDataString(searchTerm)}&rows={limit}&start={offset}";

            Console.WriteLine($"Making USPTO API call to: {_httpClient.BaseAddress}{requestUri}");

            var response = await _httpClient.GetAsync(requestUri);

            // This line will throw an exception if the status code is 4xx or 5xx, including 403.
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var apiResponse = JsonSerializer.Deserialize<PatentApplicationSearchResponse>(jsonString, options);

            return apiResponse ?? new PatentApplicationSearchResponse();
        }
    }
}