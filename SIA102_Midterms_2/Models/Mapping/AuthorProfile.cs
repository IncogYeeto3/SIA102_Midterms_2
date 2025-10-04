using AutoMapper;
using SIA102_Midterms_2.DTOs;
using SIA102_Midterms_2.Models;


namespace SIA102_Midterms_2.Models.Mapping
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile() {
            CreateMap<Author, AuthorReadDTO>();
            CreateMap<Author, AuthorCreateDTO>();
            CreateMap<Author, AuthorUpdateDTO>();
            CreateMap<AuthorReadDTO, Author>();
            CreateMap<AuthorCreateDTO, Author>();
            CreateMap<AuthorUpdateDTO, Author>();
        }
    }
}
