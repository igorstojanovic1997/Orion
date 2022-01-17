using System.Linq;
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
            CreateMap<ContractHistory, ContractHistoryDto>()
                .ForMember(dest => dest.Sum, opt => opt.MapFrom(s => s.Plan.Price));
            CreateMap<PlanDto, Plan>().ReverseMap();
            CreateMap<ContractDto, Contract>().ReverseMap();
            CreateMap<NewContractViewModel, ContractPlan>().ForMember(dest => dest.Contract, 
                opt => opt.MapFrom(s => new Contract
                {
                    DiscountRate = s.DiscountRate,
                    Username = s.Username,
                    GratisPeriod = s.GratisPeriod,
                    IsActive = s.IsActive,
                    Duration = s.Duration,
                    Fee = s.Fee,
                    Id = s.ContractId,
                    DateTimeCreated = s.DateTimeCreated
                }));

            CreateMap<ContractPlan, NewContractViewModel>()
                .ForMember(dest => dest.ContractId, opt => opt.MapFrom(s => s.ContractId))
                .ForMember(dest => dest.DiscountRate, opt => opt.MapFrom(s => s.Contract.DiscountRate))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(s => s.Contract.Duration))
                .ForMember(dest => dest.GratisPeriod, opt => opt.MapFrom(s => s.Contract.GratisPeriod))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(s => s.Contract.IsActive))
                .ForMember(dest => dest.PlanId, opt => opt.MapFrom(s => s.PlanId))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(s => s.Contract.Username))
                .ForMember(dest => dest.DateTimeCreated, opt => opt.MapFrom(s => s.Contract.DateTimeCreated));
        }
    }
}