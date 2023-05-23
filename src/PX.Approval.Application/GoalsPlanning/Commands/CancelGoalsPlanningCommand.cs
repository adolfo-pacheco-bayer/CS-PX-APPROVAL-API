﻿using MediatR;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Commands;

public class CancelGoalsPlanningCommand : IRequest<Response>
{
    public CancelGoalsPlanningCommand(string reason, List<Guid> goalsPlanningIntegrationIds)
    {
        Reason = reason;
        GoalsPlanningIntegrationIds = goalsPlanningIntegrationIds;
    }

    public string Reason { get; set; }
    public List<Guid> GoalsPlanningIntegrationIds { get; set; }
}

