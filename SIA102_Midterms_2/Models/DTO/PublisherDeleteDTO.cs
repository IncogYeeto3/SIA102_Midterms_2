using System.ComponentModel.DataAnnotations;

namespace SIA102_Midterms_2.DTOs
{
    public class PublisherDeleteDTO
    {
        [Required(ErrorMessage = "Publisher ID is required.")]
        [StringLength(11, ErrorMessage = "Publisher ID cannot be longer than 11 characters.")]
        public string PubId { get; set; }
    }
}
