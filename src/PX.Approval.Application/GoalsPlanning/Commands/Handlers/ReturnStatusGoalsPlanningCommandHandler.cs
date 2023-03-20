using MediatR;
using Microsoft.AspNetCore.Http;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;
using PX.Library.Common.Extensions;

namespace PX.Approval.Application.GoalsPlanning.Commands.Handlers;

public class ReturnStatusGoalsPlanningCommandHandler : IRequestHandler<ReturnStatusGoalsPlanningCommand, Response>
{
    private IResponse _response;
    private IGoalsPlanningClient _goalsPlanningClient;
    private IHttpContextAccessor _httpContextAccessor;

    public ReturnStatusGoalsPlanningCommandHandler(IResponse response, IGoalsPlanningClient goalsPlanningClient, IHttpContextAccessor httpContextAccessor)
    {
        _response = response;
        _goalsPlanningClient = goalsPlanningClient;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Response> Handle(ReturnStatusGoalsPlanningCommand request, CancellationToken cancellationToken)
    {
        var returnUserCWID = _httpContextAccessor.HttpContext.GetCwid();
        var result = await _goalsPlanningClient.ReturnStatusGoalsPlanningAsync(returnUserCWID, request.Reason, request.GoalsPlanningIntegrationIds);

        return await _response.CreateSuccessResponseAsync(result);
    }
}
