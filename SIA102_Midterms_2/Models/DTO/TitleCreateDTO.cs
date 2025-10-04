using System;
using System.ComponentModel.DataAnnotations;

namespace SIA102_Midterms_2.DTOs
{
    public class TitleCreateDTO
    {
        [StringLength(6, ErrorMessage = "Title ID cannot be longer than 6 characters.")]
        public string TitleId { get; set; } // Optional if auto-generated

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title1 { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [StringLength(20, ErrorMessage = "Type cannot be longer than 20 characters.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Publisher ID is required.")]
        [StringLength(11, ErrorMessage = "Publisher ID cannot be longer than 11 characters.")]
        public string PubId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be non-negative.")]
        public decimal? Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Advance must be non-negative.")]
        public decimal? Advance { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Royalty must be non-negative.")]
        public int? Royalty { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "YTD Sales must be non-negative.")]
        public int? YtdSales { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot be longer than 500 characters.")]
        public string Notes { get; set; }

        [Required(ErrorMessage = "Publication date is required.")]
        public DateTime Pubdate { get; set; }
    }
}
