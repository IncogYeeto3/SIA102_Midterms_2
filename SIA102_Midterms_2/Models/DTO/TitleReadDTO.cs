using System;
using System.Collections.Generic;

namespace SIA102_Midterms_2.DTOs
{
    public class TitleReadDTO
    {
        public string TitleId { get; set; }
        public string Title1 { get; set; }
        public string Type { get; set; }
        public string PubId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Advance { get; set; }
        public int? Royalty { get; set; }
        public int? YtdSales { get; set; }
        public string Notes { get; set; }
        public DateTime Pubdate { get; set; }

        public object Publisher { get; set; } // Optional: can map to PublisherDTO
        public List<string> SaleIds { get; set; } = new List<string>(); // Optional
        public List<string> AuthorIds { get; set; } = new List<string>(); // Optional: from Titleauthors
    }
}
