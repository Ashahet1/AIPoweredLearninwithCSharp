// Services/PatentDataService.cs

using PatentAnalyzer.Models;
using PatentAnalyzer.USPTOApiModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System; // Make sure System is included for DateTime

namespace PatentAnalyzer.Services
{
    public class PatentDataService : IPatentDataService
    {
        private readonly IUSPTOApiClient _usptoApiClient;
        private readonly List<Patent> _patents = new();
        private readonly List<Risk> _risks = new();
        private readonly List<Trend> _trends = new();

        public PatentDataService(IUSPTOApiClient usptoApiClient)
        {
            _usptoApiClient = usptoApiClient;
        }

        public async Task IngestNewPatentsAsync(int numberOfPatentsToIngest)
        {
            Console.WriteLine($"Attempting to ingest {numberOfPatentsToIngest} patents from USPTO...");

            string searchTerm = "Artificial Intelligence"; // Example search term
            int limit = numberOfPatentsToIngest;
            int offset = 0;

            PatentApplicationSearchResponse apiResponse = await _usptoApiClient.SearchPatentApplicationsAsync(searchTerm, limit, offset);

            if (apiResponse?.PatentFileWrapperDataBag != null)
            {
                Console.WriteLine($"Found {apiResponse.PatentFileWrapperDataBag.Count} patents matching '{searchTerm}' from USPTO API.");

                foreach (var usptoPatentData in apiResponse.PatentFileWrapperDataBag)
                {
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

        private Patent? MapUSPTOToInternalPatent(PatentFileWrapperDataBag usptoPatentData)
        {
            // Ensure usptoPatentData and its ApplicationMetaData are not null for core properties
            if (usptoPatentData?.ApplicationMetaData == null)
            {
                return null;
            }

                string patentId = usptoPatentData.ApplicationNumberText ?? // This is the new primary source for ID
                      usptoPatentData.ApplicationMetaData.ApplicationNumberText ??
                      Guid.NewGuid().ToString();
            var patent = new Patent
            {
                Id = patentId,

                // --- CORRECTED MAPPING BASED ON JSON ---
                Title = usptoPatentData.ApplicationMetaData.InventionTitle ?? "N/A", // Found under ApplicationMetaData

                // Abstract and Claims are NOT present in the provided JSON for this endpoint.
                // They will remain placeholders or empty.
                Abstract = "N/A - Abstract not found in this API response. May require another endpoint.",
                Claims = new string[] { "N/A - Claims not found in this API response. May require another endpoint." },

                // Assignee: Using ApplicantNameText from the first applicant in ApplicationMetaData
                Assignee = usptoPatentData.ApplicationMetaData.ApplicantBag?.FirstOrDefault()?.ApplicantNameText ?? "N/A",

                // Inventors: Using InventorNameText from the list of inventors in ApplicationMetaData
                Inventors = usptoPatentData.ApplicationMetaData.InventorBag?.Select(i => i.InventorNameText ?? "N/A").ToArray() ?? new string[0],

                // PublicationDate: Found directly under ApplicationMetaData
                PublicationDate = usptoPatentData.ApplicationMetaData.EarliestPublicationDate ?? DateTime.MinValue,

                // GrantDate: Not found in this API response. Applications are not granted.
                GrantDate = null, // Set to null as it's not provided by this endpoint

                // ClassificationCode: Found under ApplicationMetaData -> CpcClassificationBag
                ClassificationCode = usptoPatentData.ApplicationMetaData.CpcClassificationBag?.FirstOrDefault() ?? "N/A",

                // Consider adding more fields based on your JSON if useful for your Patent model
                // Example: ApplicationNumberText, FilingDate, ApplicationStatusDescriptionText, etc.
                // You can add these to your Patent model and map them here.

                Url = $"https://patents.google.com/patent/{patentId}" // Still a placeholder, consider a more official link if available
            };

            return patent;
        }

        // --- Other methods remain the same ---
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