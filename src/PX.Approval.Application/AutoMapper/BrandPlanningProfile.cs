using AutoMapper;
using PX.Approval.Application.ViewModel;
using PX.Approval.Domain.Models;

namespace PX.Approval.Application.AutoMapper
{
    public class BrandPlanningProfile : Profile
    {
        public BrandPlanningProfile() {

            CreateMap<BrandPlanningViewModel, ValuedBrandsViewModel>()
                    .ForMember(dest => dest.BrandGoalsPlanningIntegrationId, cfg => cfg.MapFrom(source => source.IntegrationId))
                    .ForMember(dest => dest.Brand, cfg => cfg.MapFrom(source => source.Name))
                    .ForMember(dest => dest.Sellout, cfg => cfg.MapFrom(source => source.Price.GetValueOrDefault(0) * source.Sellout))
                    .ForMember(dest => dest.FirstSellinPeriod, cfg => cfg.MapFrom(source => source.FirstSellinPeriod.HasValue ? (source.FirstSellinPeriod.GetValueOrDefault(0) * source.Price) * (1 - (source.ClassificationCPMargin / 100)) : null))
                    .ForMember(dest => dest.SecondSellinPeriod, cfg => cfg.MapFrom(source => (source.SecondSellinPeriod * source.Price) * (1 - (source.ClassificationCPMargin / 100))))
                    .AfterMap((after, dest) => dest.TotalSellin = dest.FirstSellinPeriod.GetValueOrDefault(0) + dest.SecondSellinPeriod.GetValueOrDefault(0));

            CreateMap<BrandPlanningViewModel, VolumeBrandsViewModel>()
                    .ForMember(dest => dest.BrandGoalsPlanningIntegrationId, cfg => cfg.MapFrom(source => source.IntegrationId))
                    .ForMember(dest => dest.Brand, cfg => cfg.MapFrom(source => source.Name))
                    .ForMember(dest => dest.Sellout, cfg => cfg.MapFrom(source => source.Sellout))
                    .ForMember(dest => dest.FirstSellinPeriod, cfg => cfg.MapFrom(source => source.FirstSellinPeriod))
                    .ForMember(dest => dest.SecondSellinPeriod, cfg => cfg.MapFrom(source => source.SecondSellinPeriod.GetValueOrDefault(0)))
                    .AfterMap((after, dest) => dest.TotalSellin = dest.FirstSellinPeriod.GetValueOrDefault(0) + dest.SecondSellinPeriod.GetValueOrDefault(0));

        }
    }
}
