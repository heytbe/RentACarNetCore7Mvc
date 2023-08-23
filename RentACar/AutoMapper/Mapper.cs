using AutoMapper;
using RentACar.Models;
using RentACar.Models.Dto;

namespace RentACar.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CarType, CarTypeDto>().ReverseMap();
            CreateMap<CarBrand,CarBrandListDto>().ReverseMap();
            CreateMap<Cars,CarListDto>().ReverseMap();
        }
    }
}
