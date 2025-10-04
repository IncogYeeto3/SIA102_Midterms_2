using System.ComponentModel.DataAnnotations;

namespace SIA102_Midterms_2.DTOs
{
    public class AuthorDeleteDTO
    {
        [Required(ErrorMessage = "Author ID is required.")]
        [StringLength(11, ErrorMessage = "Author ID cannot be longer than 11 characters.")]
        public string AuId { get; set; }
    }
}
