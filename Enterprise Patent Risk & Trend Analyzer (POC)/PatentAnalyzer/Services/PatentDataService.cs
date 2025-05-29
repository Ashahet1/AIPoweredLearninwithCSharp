// Services/PatentDataService.cs

using PatentAnalyzer.Models;
using PatentAnalyzer.USPTOApiModels; // Import the USPTO DTOs
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatentAnalyzer.Services
{
    public class PatentDataService : IPatentDataService
    {
        private readonly IUSPTOApiClient _usptoApiClient;
        // In a real app, you'd inject a database context here
        // private readonly ApplicationDbContext _dbContext;

        // Using in-memory lists for POC simplicity *before* full DB integration
        private readonly List<Patent> _patents = new();
        private readonly List<Risk> _risks = new();
        private readonly List<Trend> _trends = new();

        public PatentDataService(IUSPTOApiClient usptoApiClient /*, ApplicationDbContext dbContext */)
        {
            _usptoApiClient = usptoApiClient;
            // _dbContext = dbContext;
        }

        public async Task IngestNewPatentsAsync(int numberOfPatentsToIngest)
        {
            Console.WriteLine($"Attempting to ingest {numberOfPatentsToIngest} patents from USPTO...");

            // --- CALL THE NEW USPTO API ---
            string searchTerm = "Artificial Intelligence"; // Example search term
            int limit = numberOfPatentsToIngest;
            int offset = 0; // Start from beginning

            PatentApplicationSearchResponse apiResponse = await _usptoApiClient.SearchPatentApplicationsAsync(searchTerm, limit, offset);

            if (apiResponse?.PatentFileWrapperDataBag != null)
            {
                Console.WriteLine($"Found {apiResponse.PatentFileWrapperDataBag.Count} patents matching '{searchTerm}' from USPTO API.");

                foreach (var usptoPatentData in apiResponse.PatentFileWrapperDataBag)
                {
                    // --- MAP USPTO DTO TO INTERNAL PATENT MODEL ---
                    var newPatent = MapUSPTOToInternalPatent(usptoPatentData);
                    if (newPatent != null)
                    {
                        if (!_patents.Any(p => p.Id == newPatent.Id))
                        {
                            _patents.Add(newPatent);
                            Console.WriteLine($"Ingested: {newPatent.Title} (ID: {newPatent.Id})");
                        }
                        else
                        {
                            Console.WriteLine($"Skipping existing patent: {newPatent.Title} (ID: {newPatent.Id})");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No patents found or API response was null.");
            }
            Console.WriteLine($"Finished ingestion process.");
        }

        // --- CORRECTED MAPPER METHOD ---
        private Patent? MapUSPTOToInternalPatent(PatentFileWrapperDataBag usptoPatentData)
        {
            if (usptoPatentData == null || (string.IsNullOrEmpty(usptoPatentData.ApplicationNumberText) && string.IsNullOrEmpty(usptoPatentData.PatentNumber)))
            {
                return null;
            }

            // Prioritize PatentNumber if available, otherwise use ApplicationNumberText
            string patentId = usptoPatentData.PatentNumber ?? usptoPatentData.ApplicationNumberText!;

            var patent = new Patent
            {
                Id = patentId,
                Title = usptoPatentData.InventionTitle ?? "N/A",

                // --- CORRECTIONS HERE ---
                // Abstract: This field was NOT explicitly listed in the response properties you shared.
                // You will need to check the actual JSON response or USPTO's full schema/Swagger for where it is.
                // For now, it's set to N/A.
                Abstract = "N/A - Abstract field location needs to be confirmed from USPTO API response.",

                // Claims: Similar to Abstract, not explicitly listed.
                // You will need to confirm where this is returned.
                Claims = new string[] { "N/A - Claims field location needs to be confirmed from USPTO API response." },

                // Assignee: This is nested within AssignmentBag
                Assignee = usptoPatentData.AssignmentBag?.FirstOrDefault()?.AssigneeBag?.FirstOrDefault()?.AssigneeNameText ?? "N/A",

                // Inventors: This is a list of InventorBag
                Inventors = usptoPatentData.InventorBag?.Select(i => i.InventorNameText ?? "N/A").ToArray() ?? new string[0],

                // PublicationDate: This is directly on PatentFileWrapperDataBag
                PublicationDate = usptoPatentData.EarliestPublicationDate ?? DateTime.MinValue,

                // GrantDate: This is directly on PatentFileWrapperDataBag
                GrantDate = usptoPatentData.GrantDate,

                // ClassificationCode: This is a list of CpcClassificationBag
                ClassificationCode = usptoPatentData.CpcClassificationBag?.FirstOrDefault()?.CpcSymbol ?? "N/A",

                Url = $"https://patents.google.com/patent/{patentId}" // Still a placeholder, check USPTO API for official URL
            };

            // You'll need to meticulously map all other relevant fields
            // based on the actual API response JSON structure.

            return patent;
        }

        // --- Other methods remain largely the same ---
        public Task<Patent?> GetPatentByIdAsync(string id) => Task.FromResult(_patents.FirstOrDefault(p => p.Id == id));
        public Task<IEnumerable<Patent>> GetAllPatentsAsync() => Task.FromResult<IEnumerable<Patent>>(_patents);
        public Task<IEnumerable<Risk>> GetRisksAsync() => Task.FromResult<IEnumerable<Risk>>(_risks);
        public Task<IEnumerable<Trend>> GetTrendsAsync() => Task.FromResult<IEnumerable<Trend>>(_trends);
        public Task AddRiskAsync(Risk risk) { _risks.Add(risk); return Task.CompletedTask; }
        public Task AddTrendAsync(Trend trend) { _trends.Add(trend); return Task.CompletedTask; }
        public Task UpdatePatentAsync(Patent patent)
        {
            var existingPatent = _patents.FirstOrDefault(p => p.Id == patent.Id);
            if (existingPatent != null) { /* Update properties */ }
            return Task.CompletedTask;
        }
    }
}