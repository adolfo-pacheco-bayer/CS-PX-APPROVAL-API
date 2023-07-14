using AutoMapper;
using Microsoft.Extensions.Azure;
using PX.Approval.Domain.Messages.Messages;
using PX.Approval.Domain.Models;

namespace PX.Approval.Application.AutoMapper
{
    public class PlanningElasticProfile : Profile
    {
        public PlanningElasticProfile() 
        {
            CreateMap<PlanningElasticEntity, PlanningElasticViewModel>()
                    .ForMember(dest => dest.PartnerType, cfg => cfg.MapFrom(source => source.PartnerType))
                    .ForMember(dest => dest.Id, cfg => cfg.MapFrom(source => source.Id))
                    .ForMember(dest => dest.FirstSellinPeriodRequired, cfg => cfg.MapFrom(source => source.FirstSellinPeriodRequired))
                    .ForMember(dest => dest.SelloutCp, cfg => cfg.MapFrom(source => source.SelloutCp))
                    .ForMember(dest => dest.Status, cfg => cfg.MapFrom(source => source.Status))
                    .ForMember(dest => dest.CWIDCPApprover, cfg => cfg.MapFrom(source => source.CwidcpApprover))
                    .ForMember(dest => dest.Classifications, cfg => cfg.MapFrom(source => source.Classifications))
                    .ForMember(dest => dest.Brands, cfg => cfg.MapFrom(source => source.Brands))
                    .ForMember(dest => dest.CropIntegrationId, cfg => cfg.MapFrom(source => source.CropIntegrationId))
                    .ForMember(dest => dest.CWIDSeedsApprover, cfg => cfg.MapFrom(source => source.CwidSeedsApprover))
                    .ForMember(dest => dest.DaysInQueue, cfg => cfg.MapFrom(source => DateTime.Now.Subtract(source.LastUpdate).TotalDays))
                    .ForMember(dest => dest.Details, cfg => cfg.MapFrom(source => source.Details))
                    .ForMember(dest => dest.RtvName, cfg => cfg.MapFrom(source => source.RtvName))
                    .ForMember(dest => dest.IsGoalPlanningValued, cfg => cfg.MapFrom(source => source.IsGoalPlanningValued))
                    .ForMember(dest => dest.SelloutSeeds, cfg => cfg.MapFrom(source => source.SelloutSeeds))
                    .ForMember(dest => dest.EmailGoalsPlanning, cfg => cfg.MapFrom(source => source.EmailGoalsPlanning))
                    .ForMember(dest => dest.LastUpdate, cfg => cfg.MapFrom(source => source.LastUpdate))
                    .ForMember(dest => dest.Total, cfg => cfg.MapFrom(source => source.Total));

            CreateMap<PlanningElasticViewModel, PlanningElasticViewModel>()
                    .ForMember(dest => dest.PartnerType, cfg => cfg.MapFrom(source => source.PartnerType.ToString()))
                    .ForMember(dest => dest.Id, cfg => cfg.MapFrom(source => source.Id))
                    .ForMember(dest => dest.FirstSellinPeriodRequired, cfg => cfg.MapFrom(source => source.FirstSellinPeriodRequired))
                    .ForMember(dest => dest.SelloutCp, cfg => cfg.MapFrom(source => source.SelloutCp))
                    .ForMember(dest => dest.Status, cfg => cfg.MapFrom(source => source.Status))
                    .ForMember(dest => dest.CWIDCPApprover, cfg => cfg.MapFrom(source => source.CWIDCPApprover))
                    .ForMember(dest => dest.Classifications, cfg => cfg.MapFrom(source => source.Classifications))
                    .ForMember(dest => dest.Brands, cfg => cfg.MapFrom(source => source.Brands))
                    .ForMember(dest => dest.CropIntegrationId, cfg => cfg.MapFrom(source => source.CropIntegrationId))
                    .ForMember(dest => dest.CWIDSeedsApprover, cfg => cfg.MapFrom(source => source.CWIDSeedsApprover))
                    .ForMember(dest => dest.DaysInQueue, cfg => cfg.MapFrom(source => DateTime.Now.Subtract(source.LastUpdate).TotalDays))
                    .ForMember(dest => dest.Details, cfg => cfg.MapFrom(source => source.Details))
                    .ForMember(dest => dest.RtvName, cfg => cfg.MapFrom(source => source.RtvName))
                    .ForMember(dest => dest.IsGoalPlanningValued, cfg => cfg.MapFrom(source => source.IsGoalPlanningValued))
                    .ForMember(dest => dest.SelloutSeeds, cfg => cfg.MapFrom(source => source.SelloutSeeds))
                    .ForMember(dest => dest.EmailGoalsPlanning, cfg => cfg.MapFrom(source => source.EmailGoalsPlanning))
                    .ForMember(dest => dest.LastUpdate, cfg => cfg.MapFrom(source => source.LastUpdate))
                    .ForMember(dest => dest.Total, cfg => cfg.MapFrom(source => source.Total));

        }
    }
}
