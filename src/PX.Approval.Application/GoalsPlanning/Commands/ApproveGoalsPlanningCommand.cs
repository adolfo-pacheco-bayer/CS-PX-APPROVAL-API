using MediatR;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Commands;

public class ApproveGoalsPlanningCommand : IRequest<Response>
{
    public ApproveGoalsPlanningCommand(List<Guid> goalsPlanningIntegrationIds)
    {
        GoalsPlanningIntegrationIds = goalsPlanningIntegrationIds;
    }
    
    public List<Guid> GoalsPlanningIntegrationIds { get; set; }
}

