using AutoMapper;
using Web_mvc.Models.DTO;

namespace Web_mvc
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VillaDTO,VillaCreateDTO>().ReverseMap();
            CreateMap<VillaDTO,VillaUpdateDTO>().ReverseMap();

            CreateMap<VillaNumberDTO,VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumberDTO,VillaNumberUpdateDTO>().ReverseMap();
        }
    }
}
