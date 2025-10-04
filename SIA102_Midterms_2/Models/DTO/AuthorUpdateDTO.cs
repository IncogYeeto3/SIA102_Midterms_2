using System.ComponentModel.DataAnnotations;

namespace SIA102_Midterms_2.DTOs
{
    public class AuthorUpdateDTO
    {
        [Required(ErrorMessage = "Author ID is required.")]
        [StringLength(11, ErrorMessage = "Author ID cannot be longer than 11 characters.")]
        public string AuId { get; set; }

        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string AuLname { get; set; }

        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string AuFname { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(20, ErrorMessage = "Phone number cannot be longer than 20 characters.")]
        public string Phone { get; set; }

        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters.")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters.")]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = "State cannot be longer than 50 characters.")]
        public string State { get; set; }

        [StringLength(10, ErrorMessage = "Zip cannot be longer than 10 characters.")]
        public string Zip { get; set; }

        public bool Contract { get; set; }
    }
}
