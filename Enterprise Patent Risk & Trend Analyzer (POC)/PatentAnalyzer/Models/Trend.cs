namespace PatentAnalyzer.Models
{
    public class Trend
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); // Unique ID for the trend
        public string Name { get; set; } // E.g., "AI in Healthcare", "5G Communication"
        public string Description { get; set; }
        public double GrowthScore { get; set; } // E.g., based on patent filing velocity
        public DateTime IdentifiedDate { get; set; } = DateTime.UtcNow;
        public string[] RelatedPatents { get; set; } = new string[0]; // IDs of patents contributing to this trend
        public string[] Keywords { get; set; } = new string[0]; // Keywords defining the trend
    }
}