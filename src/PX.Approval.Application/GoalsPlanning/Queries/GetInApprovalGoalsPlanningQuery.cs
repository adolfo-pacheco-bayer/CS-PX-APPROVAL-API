using MediatR;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries;

public class GetInApprovalGoalsPlanningQuery : IRequest<Response>
{
    public IEnumerable<Guid> CropIntegrationIds { get; private set; }

	public GetInApprovalGoalsPlanningQuery(IEnumerable<Guid> cropIntegrationIds)
	{
		CropIntegrationIds= cropIntegrationIds;
	}
}
