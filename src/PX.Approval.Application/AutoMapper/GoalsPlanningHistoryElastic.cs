using AutoMapper;
using Microsoft.Extensions.Azure;
using PX.Approval.Domain.Messages.Messages;
using PX.Approval.Domain.Models;

namespace PX.Approval.Application.AutoMapper
{

    public class GoalsPlanningHistoryElastic : Profile
    {
        public GoalsPlanningHistoryElastic() 
        {
            CreateMap<GoalsPlanningStatusHistory, GoalsPlanningStatusHistoryViewModel>()
                    .ForMember(dest => dest.GoalsPlanningId, cfg => cfg.MapFrom(source => source.GoalsPlanningId))
                    .ForMember(dest => dest.Status, cfg => cfg.MapFrom(source => Translations.ResourceManager.GetString(source.Status.ToString())))
                    .ForMember(dest => dest.StatusChanged, cfg => cfg.MapFrom(source => source.StatusChanged))
                    .ForMember(dest => dest.Status, cfg => cfg.MapFrom(source => source.Status))
                    .ForMember(dest => dest.StaStatusChangedUserCWID, cfg => cfg.MapFrom(source => source.StaStatusChangedUserCWID))
                    .ForMember(dest => dest.Reason, cfg => cfg.MapFrom(source => source.Reason))
                    .ForMember(dest => dest.IntegrationId, cfg => cfg.MapFrom(source => source.IntegrationId))
                    .ForMember(dest => dest.UrlFile, cfg => cfg.MapFrom(source => source.UrlFile));
                    

        }
    }
}
