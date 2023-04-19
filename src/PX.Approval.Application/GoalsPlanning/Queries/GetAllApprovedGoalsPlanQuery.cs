using MediatR;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries;

public class GetAllApprovedGoalsPlanQuery : IRequest<Response>
{
    public IEnumerable<Guid> IntegrationIds { get; private set; }

	public GetAllApprovedGoalsPlanQuery(IEnumerable<Guid> IntegrationIds)
	{
		IntegrationIds= IntegrationIds;
	}
}
