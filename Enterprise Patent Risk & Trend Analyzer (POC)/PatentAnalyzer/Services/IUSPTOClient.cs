using PatentAnalyzer.USPTOApiModels;
using System.Threading.Tasks;

namespace PatentAnalyzer.Services
{
    public interface IUSPTOApiClient
    {
        // Updated to return the specific response DTO for the search endpoint
        Task<PatentApplicationSearchResponse> SearchPatentApplicationsAsync(string searchTerm, int limit, int offset = 0);
        // You might add methods for specific application lookups by ID if needed,
        // using other ODP endpoints like /patent/applications/{applicationNumber}
    }
}