using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PX.Approval.Application.GoalsPlanning.Queries
{
    public class ExportExcelModelQuery : IRequest<FileStreamResult>
    {
        public Guid GoalsPlanningIntegrationId { get; set; }
        public Guid PartnerIntegrationId { get; set; }

        public ExportExcelModelQuery(Guid goalsPlanningIntegrationId, Guid partnerIntegrationId)
        {
            GoalsPlanningIntegrationId = goalsPlanningIntegrationId;
            PartnerIntegrationId = partnerIntegrationId;    
        }
    }
}
