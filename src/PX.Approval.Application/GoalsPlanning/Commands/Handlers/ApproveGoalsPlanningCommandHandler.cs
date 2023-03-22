using MediatR;
using Microsoft.AspNetCore.Http;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Messages.Messages;
using PX.Approval.Domain.Response;
using PX.Library.Common.Extensions;
using PX.Library.Common.Notification.Email;
using PX.Library.Common.ServiceBus.Interfaces;

namespace PX.Approval.Application.GoalsPlanning.Commands.Handlers;

public class ApproveGoalsPlanningCommandHandler : IRequestHandler<ApproveGoalsPlanningCommand, Response>
{
    private IResponse _response;
    private IGoalsPlanningClient _goalsPlanningClient;
    private IHttpContextAccessor _httpContextAccessor;
    private IElasticSearchServiceClient _elasticSearchClient;
    private IServiceBus _serviceBusClient;

    public ApproveGoalsPlanningCommandHandler(IResponse response, IGoalsPlanningClient goalsPlanningClient, IHttpContextAccessor httpContextAccessor, IElasticSearchServiceClient elasticSearchClient, IServiceBus serviceBusClient)
    {
        _response = response;
        _goalsPlanningClient = goalsPlanningClient;
        _httpContextAccessor = httpContextAccessor;
        _elasticSearchClient = elasticSearchClient;
        _serviceBusClient = serviceBusClient;
    }

    public async Task<Response> Handle(ApproveGoalsPlanningCommand request, CancellationToken cancellationToken)
    {
        var approveUserCWID = _httpContextAccessor.HttpContext.GetCwid();
        var result = await _goalsPlanningClient.ApproveGoalsPlanningAsync(approveUserCWID, request.GoalsPlanningIntegrationIds);

        foreach (var goalsPlanning in request.GoalsPlanningIntegrationIds)
        {
            var goalsPlanningInfo = await _elasticSearchClient.GetByGoalsPlanningIntegrationId(goalsPlanning);

            var emailPartner = string.Empty;
            var namePartner = string.Empty;
            var content = Translations.EmailApprove.Replace("#PARCEIRO#", namePartner);

            if (!string.IsNullOrEmpty(emailPartner))
                await _serviceBusClient.SendEmailMessage(new Email(emailPartner, Translations.NoReplyEmail, Translations.DefaultSender, Translations.SubjectApprove, content, true), cancellationToken);
        }

        return await _response.CreateSuccessResponseAsync(result);
    }
}
