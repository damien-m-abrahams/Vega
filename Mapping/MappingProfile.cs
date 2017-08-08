using AutoMapper;
using cars.Controllers.Resources;
using cars.Models;

namespace cars.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
        }
    }
}