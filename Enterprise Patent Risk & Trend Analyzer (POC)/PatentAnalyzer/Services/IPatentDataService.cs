/*
This is where your core business logic and external API interactions will live.

Services/IPatentDataService.cs (Your Interface)
This interface defines the contract for what your patent data service can do. It separates the "what" from the "how".

*/
using PatentAnalyzer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatentAnalyzer.Services
{
    public interface IPatentDataService
    {
        Task IngestNewPatentsAsync(int numberOfPatentsToIngest); // Example: ingest X recent patents
        Task<Patent?> GetPatentByIdAsync(string id);
        Task<IEnumerable<Patent>> GetAllPatentsAsync();
        Task<IEnumerable<Risk>> GetRisksAsync();
        Task<IEnumerable<Trend>> GetTrendsAsync();

        // More methods would go here, e.g., for saving extracted risks/trends
        Task AddRiskAsync(Risk risk);
        Task AddTrendAsync(Trend trend);
        Task UpdatePatentAsync(Patent patent); // If you add risks/trends directly to patent objects
    }
}