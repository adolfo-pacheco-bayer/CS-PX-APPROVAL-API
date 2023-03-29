using MediatR;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries;

public class GetInApprovalGoalsPlanningQuery : IRequest<Response>
{
    public Guid CropIntegrationId { get; private set; }

	public GetInApprovalGoalsPlanningQuery(Guid cropIntegrationId)
	{
		CropIntegrationId = cropIntegrationId;
	}
}
