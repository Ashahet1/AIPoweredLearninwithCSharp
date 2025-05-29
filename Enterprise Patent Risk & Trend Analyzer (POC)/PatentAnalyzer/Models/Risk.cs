namespace PatentAnalyzer.Models
{
    public class Risk
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); // Unique ID for the risk
        public string PatentId { get; set; } // Foreign key to Patent
        public string Type { get; set; } // E.g., "Infringement", "Expiration", "Competitor Filing"
        public string Description { get; set; }
        public double Score { get; set; } // E.g., 0-1 for severity
        public DateTime IdentifiedDate { get; set; } = DateTime.UtcNow;
        public string[] Keywords { get; set; } = new string[0]; // Keywords extracted from the risk
    }
}