using AutoMapper;
using WebAPi.Models;
using WebAPi.Models.DTO;

namespace WebAPi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<VillaNumber, VillaDTO>();
            CreateMap<VillaDTO, VillaNumber>();

            CreateMap<VillaNumber, VillaCreateDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaUpdateDTO>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberDTO>();


            CreateMap<VillaNumber, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();

        }
    }
}
