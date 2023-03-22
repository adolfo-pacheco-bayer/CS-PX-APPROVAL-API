using MediatR;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries
{
    public class GetPlanningTotalQuery : IRequest<Response>
    {
        public Guid CropIntegrationId { get; set; }

    }
}
