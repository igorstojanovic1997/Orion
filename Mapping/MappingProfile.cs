using AutoMapper;
using Orion.Dtos;
using Orion.Models;
using Orion.ViewModels;

namespace Orion.Mapping
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<PlanFormViewModel, Plan>().ReverseMap();
            CreateMap<PlanDto, Plan>().ReverseMap();
        }
    }
}