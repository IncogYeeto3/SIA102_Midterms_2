using System.Collections.Generic;

namespace SIA102_Midterms_2.DTOs
{
    public class PublisherReadDTO
    {
        public string PubId { get; set; }
        public string PubName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public List<string> EmployeeIds { get; set; } = new List<string>(); // Optional: IDs of Employees
        public object PubInfo { get; set; } // Optional: can map PubInfoDTO if needed
        public List<string> TitleIds { get; set; } = new List<string>(); // Optional: IDs of Titles
    }
}
