namespace PatentAnalyzer.Models
{
    public class Patent
    {
        public string Id { get; set; } // USPTO patent/application number
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string[] Claims { get; set; } = new string[0]; // Array of claims
        public string Assignee { get; set; } // Current owner
        public string[] Inventors { get; set; } = new string[0];
        public DateTime PublicationDate { get; set; }
        public DateTime? GrantDate { get; set; } // Nullable if it's an application
        public string ClassificationCode { get; set; } // E.g., CPC or USPC
        public string Url { get; set; } // Link to original patent document

        // You might add properties for related risks/trends later
        public List<Risk> Risks { get; set; } = new List<Risk>();
        public List<Trend> Trends { get; set; } = new List<Trend>();
    }
}