using MediatR;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Commands;

public class ReturnStatusGoalsPlanningCommand : IRequest<Response>
{
    public ReturnStatusGoalsPlanningCommand(List<Guid> goalsPlanningIntegrationIds)
    {
        GoalsPlanningIntegrationIds = goalsPlanningIntegrationIds;
    }

    public List<Guid> GoalsPlanningIntegrationIds { get; set; }
}

