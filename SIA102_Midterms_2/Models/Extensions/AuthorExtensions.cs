using SIA102_Midterms_2.Models;

namespace SIA102_Midterms_2.Extensions
{
    public static class AuthorExtensions
    {
        // Returns full name of the author
        public static string FullName(this Author author)
        {
            return $"{author.AuFname} {author.AuLname}";
        }
    }
}
