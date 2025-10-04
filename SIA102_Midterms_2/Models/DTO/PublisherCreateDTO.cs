namespace SIA102_Midterms_2.DTOs
{
    public class PublisherCreateDTO
    {
        public string PubId { get; set; } // Optional if auto-generated
        public string PubName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
