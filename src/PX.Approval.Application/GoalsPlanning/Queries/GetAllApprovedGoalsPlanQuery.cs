using MediatR;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries;

public class GetAllApprovedGoalsPlanQuery : IRequest<Response>
{
    public Guid IntegrationId { get; private set; }

	public GetAllApprovedGoalsPlanQuery(Guid integrationId)
	{
		IntegrationId = integrationId;
	}
}
