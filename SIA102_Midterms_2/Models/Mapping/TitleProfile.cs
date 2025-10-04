using AutoMapper;
using SIA102_Midterms_2.DTOs;
using SIA102_Midterms_2.Models;


namespace SIA102_Midterms_2.Models.Mapping
{
    public class TitleProfile : Profile
    {
        public TitleProfile()
        {
            CreateMap<Title, TitleReadDTO>();
            CreateMap<Title, TitleCreateDTO>();
            CreateMap<Title, TitleUpdateDTO>();
            CreateMap<TitleReadDTO, Title>();
            CreateMap<TitleCreateDTO, Title>();
            CreateMap<TitleUpdateDTO, Title>();
        }
    }
}
