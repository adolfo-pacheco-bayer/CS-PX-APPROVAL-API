using MassTransit.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Approval.Infrastructure.Services.Accomplashiment
{
    public class AccomplashimentClientConfiguration
    {
        public const string PlanningServiceOptions = "PlanningServiceOptions";

        public string PlanningBaseAddress { get; set; } = string.Empty;

        public string PlanningGetServiceEndPoint { get; set; } = string.Empty; //"approval/all-goals-planning/crop/{cropintegrationid}";
        public string PlanningGetHistoryServiceEndPoint { get; set; } = string.Empty;//"approval/history/{goalsplanningintegrationId}";
        public string PlanningGetBrandsByGoalsPlanningIdServiceEndPoint { get; set; } = string.Empty; //"approval/get-brands/{goalsPlanningIntegrationId}";
        public string PlanningGetByGoalsPlanningIntegrationIdServiceEndPoint { get; set; } = string.Empty;//"approval/get-goals-planning/{goalsPlanningIntegrationId}";
        public string PlanningGetByFilterServiceEndPoint { get; set; } = string.Empty; //"approval/get-goalsplanning-by-filter/{cropIntegrationId}";
        public string PlanningGetGraphicsByCropIntegrationIdServiceEndPoint { get; set; } = string.Empty; //"approval/graphic/{cropintegrationid}";
        public string PlanningGetTotalServiceEndPoint { get; set; } = string.Empty; //"approval/planning-total/crop/{cropintegrationid}";

        
    }
}

