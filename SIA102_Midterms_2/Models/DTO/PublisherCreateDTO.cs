using System.ComponentModel.DataAnnotations;

namespace SIA102_Midterms_2.DTOs
{
    public class PublisherCreateDTO
    {
        [StringLength(11, ErrorMessage = "Publisher ID cannot be longer than 11 characters.")]
        public string PubId { get; set; } // optional if auto-generated

        [Required(ErrorMessage = "Publisher name is required.")]
        [StringLength(100, ErrorMessage = "Publisher name cannot be longer than 100 characters.")]
        public string PubName { get; set; }

        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters.")]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = "State cannot be longer than 50 characters.")]
        public string State { get; set; }

        [StringLength(50, ErrorMessage = "Country cannot be longer than 50 characters.")]
        public string Country { get; set; }
    }
}
