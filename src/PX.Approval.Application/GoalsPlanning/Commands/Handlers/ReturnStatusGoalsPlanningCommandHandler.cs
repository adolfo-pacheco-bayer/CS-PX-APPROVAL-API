using MediatR;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;
using PX.Crop.Domain.Enum;

namespace PX.Approval.Application.GoalsPlanning.Commands.Handlers;

public class ReturnStatusGoalsPlanningCommandHandler : IRequestHandler<ReturnStatusGoalsPlanningCommand, Response>
{
    private IResponse _response;
    private IGoalsPlanningClient _goalsPlanningClient;

    public ReturnStatusGoalsPlanningCommandHandler(IResponse response, IGoalsPlanningClient goalsPlanningClient)
    {
        _response = response;
        _goalsPlanningClient = goalsPlanningClient;
    }

    public async Task<Response> Handle(ReturnStatusGoalsPlanningCommand request, CancellationToken cancellationToken)
    {
        var goalsPlanningEntity = new List<PlanningEntity>();
        var allGoalsPlanning = await _goalsPlanningClient.GetAllGoalsPlanningByCropIntegrationsIdAsync(request.GoalsPlanningIntegrationIds.ToArray());

        foreach (var goalPlanning in allGoalsPlanning)
        {
            var status = goalPlanning.Status;

            status = goalPlanning.Status switch
            {
                GoalsPlanningStatus.Reproved => GoalsPlanningStatus.InPreparation,
                GoalsPlanningStatus.Canceled => GoalsPlanningStatus.InPreparation,
                _ => goalPlanning.Status
            };

            goalPlanning.SetStatus(status);
            goalsPlanningEntity.Add(await _planningRepository.UpdateAsync(goalPlanning));
        }

        return await _response.CreateSuccessResponseAsync(goalsPlanningEntity, PlanningMessages.ReturnStatusSuccess);
    }
}
