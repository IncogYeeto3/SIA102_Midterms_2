using System.ComponentModel.DataAnnotations;

namespace SIA102_Midterms_2.DTOs
{
    public class TitleDeleteDTO
    {
        [Required(ErrorMessage = "Title ID is required.")]
        [StringLength(6, ErrorMessage = "Title ID cannot be longer than 6 characters.")]
        public string TitleId { get; set; }
    }
}
