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
        var result = await _goalsPlanningClient.ReturnStatusGoalsPlanningAsync(request.Reason, request.GoalsPlanningIntegrationIds);

        return await _response.CreateSuccessResponseAsync(result);
    }
}
