using MediatR;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Commands;

public class ReturnStatusGoalsPlanningCommand : IRequest<Response>
{
    public ReturnStatusGoalsPlanningCommand(string reason, byte[] file, string fileName, List<Guid> goalsPlanningIntegrationIds)
    {
        Reason = reason;
        File = file;
        FileName = fileName;
        GoalsPlanningIntegrationIds = goalsPlanningIntegrationIds;
    }

    public string Reason { get; set; }
    public byte[] File { get; set; }
    public string FileName { get; set; }
    public List<Guid> GoalsPlanningIntegrationIds { get; set; }
}

