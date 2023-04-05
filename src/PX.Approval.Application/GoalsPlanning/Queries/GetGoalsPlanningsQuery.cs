using MediatR;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries
{
    public class GetGoalsPlanningsQuery : IRequest<Response>
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public Guid CropIntegrationId { get; set; }
        public string PartnerType { get; set; }
    }
}
