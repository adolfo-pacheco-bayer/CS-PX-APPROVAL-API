using MediatR;
using Microsoft.AspNetCore.Http;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Commands;

public class ReproveGoalsPlanningCommand : IRequest<Response>
{
    public ReproveGoalsPlanningCommand(string reason, IFormFile file, List<Guid> goalsPlanningIntegrationIds)
    {
        Reason = reason;
        File = file;
        GoalsPlanningIntegrationIds = goalsPlanningIntegrationIds;
    }

    public string Reason { get; set; }
    public IFormFile? File { get; set; }
    public List<Guid> GoalsPlanningIntegrationIds { get; set; }
}

