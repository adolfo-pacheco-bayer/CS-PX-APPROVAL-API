using Azure.Messaging.ServiceBus;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Messages.Messages;
using PX.Approval.Domain.Response;
using PX.Library.Common.Extensions;
using PX.Library.Common.Notification.Email;
using PX.Library.Common.ServiceBus.Interfaces;
using System.Net;

namespace PX.Approval.Application.GoalsPlanning.Commands.Handlers;

public class ReproveGoalsPlanningCommandHandler : IRequestHandler<ReproveGoalsPlanningCommand, Response>
{
    private IResponse _response;
    private IGoalsPlanningClient _goalsPlanningClient;
    private IHttpContextAccessor _httpContextAccessor;
    private IElasticSearchServiceClient _elasticSearchClient;
    private readonly IServiceBus _serviceBusClient;
    private readonly ILogger<ReproveGoalsPlanningCommandHandler> _logger;

    public ReproveGoalsPlanningCommandHandler(IResponse response, 
        IGoalsPlanningClient goalsPlanningClient, 
        IHttpContextAccessor httpContextAccessor, 
        IElasticSearchServiceClient elasticSearchClient, 
        IServiceBus serviceBusClient, 
        ILogger<ReproveGoalsPlanningCommandHandler> logger)
    {
        _response = response;
        _goalsPlanningClient = goalsPlanningClient;
        _httpContextAccessor = httpContextAccessor;
        _elasticSearchClient = elasticSearchClient;
        _serviceBusClient = serviceBusClient;
        _logger = logger;
    }

    public async Task<Response> Handle(ReproveGoalsPlanningCommand request, CancellationToken cancellationToken)
    {
        var reproveUserCWID = _httpContextAccessor.HttpContext.GetCwid();
        var result = await _goalsPlanningClient.ReproveGoalsPlanningAsync(reproveUserCWID, request.Reason, request.File, request.GoalsPlanningIntegrationIds);

        foreach (var goalsPlanning in request.GoalsPlanningIntegrationIds)
        {
            var goalsPlanningInfo = await _elasticSearchClient.GetByGoalsPlanningIntegrationId(goalsPlanning);

            var emailPartner = string.Empty;
            var namePartner = string.Empty;
            var content = Translations.EmailReprove.Replace("#PARCEIRO#", namePartner).Replace("#MOTIVO#", request.Reason);

            if (!string.IsNullOrEmpty(emailPartner))
                await _serviceBusClient.SendEmailMessage(new Email(emailPartner, Translations.NoReplyEmail, Translations.DefaultSender, Translations.SubjectReprove, content, true), cancellationToken);
        }

        return await _response.CreateSuccessResponseAsync(result);
    }
}
