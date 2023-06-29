using AutoMapper;
using Microsoft.Extensions.Azure;
using PX.Approval.Domain.Messages.Messages;
using PX.Approval.Domain.Models;
using PX.Crop.Domain.Enum;

namespace PX.Approval.Application.AutoMapper
{

    public class GoalsPlanningHistoryElasticProfile : Profile
    {
        public GoalsPlanningHistoryElasticProfile()
        {
            CreateMap<GoalsPlanningStatusHistory, GoalsPlanningStatusHistoryViewModel>()
                    .ForMember(dest => dest.GoalsPlanningId, cfg => cfg.MapFrom(source => source.GoalsPlanningId))
                    .ForMember(dest => dest.Status, cfg => cfg.MapFrom(source => TranslateStatus(source.Status)))
                    .ForMember(dest => dest.StatusChanged, cfg => cfg.MapFrom(source => source.StatusChanged.ToLocalTime()))
                    .ForMember(dest => dest.StatusChangedUserCWID, cfg => cfg.MapFrom(source => source.StatusChangedUserCWID))
                    .ForMember(dest => dest.Reason, cfg => cfg.MapFrom(source => source.Reason))
                    .ForMember(dest => dest.IntegrationId, cfg => cfg.MapFrom(source => source.IntegrationId))
                    .ForMember(dest => dest.UrlFile, cfg => cfg.MapFrom(source => source.UrlFile))
                    .ForMember(dest => dest.OriginalFileName, cfg => cfg.MapFrom(source => source.OriginalFileName));


        }

        private string TranslateStatus(GoalsPlanningStatus status)
        => status switch
        {
            GoalsPlanningStatus.New => "Criado",
            GoalsPlanningStatus.Approved => "Aprovado",
            GoalsPlanningStatus.InApproval => "Aguardando Aprovação",
            GoalsPlanningStatus.Canceled => "Cancelado",
            GoalsPlanningStatus.InPreparation => "Em Elaboração",
            GoalsPlanningStatus.Reproved => "Reprovado",
            GoalsPlanningStatus.Returned => "Retornado",
            _=> string.Empty
        };
    }
}
