using AutoMapper;
using SIA102_Midterms_2.DTOs;
using SIA102_Midterms_2.Models;


namespace SIA102_Midterms_2.Models.Mapping
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherReadDTO>();
            CreateMap<Publisher, PublisherCreateDTO>();
            CreateMap<Publisher, PublisherUpdateDTO>();
            CreateMap<PublisherReadDTO, Publisher>();
            CreateMap<PublisherCreateDTO, Publisher>();
            CreateMap<PublisherUpdateDTO, Publisher>();
        }
    }
}
