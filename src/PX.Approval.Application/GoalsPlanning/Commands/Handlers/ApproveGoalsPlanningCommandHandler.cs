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

namespace PX.Approval.Application.GoalsPlanning.Commands.Handlers;

public class ApproveGoalsPlanningCommandHandler : IRequestHandler<ApproveGoalsPlanningCommand, Response>
{
    private IResponse _response;
    private IGoalsPlanningClient _goalsPlanningClient;
    private IHttpContextAccessor _httpContextAccessor;
    private IElasticSearchServiceClient _elasticSearchClient;
    private readonly IServiceBus _serviceBusClient;
    private readonly ILogger<ApproveGoalsPlanningCommandHandler> _logger;

    public ApproveGoalsPlanningCommandHandler(IResponse response, 
        IGoalsPlanningClient goalsPlanningClient, 
        IHttpContextAccessor httpContextAccessor, 
        IElasticSearchServiceClient elasticSearchClient, 
        IServiceBus serviceBusClient,
        ILogger<ApproveGoalsPlanningCommandHandler> logger)
    {
        _response = response;
        _goalsPlanningClient = goalsPlanningClient;
        _httpContextAccessor = httpContextAccessor;
        _elasticSearchClient = elasticSearchClient;
        _serviceBusClient = serviceBusClient;
        _logger = logger;
    }

    public async Task<Response> Handle(ApproveGoalsPlanningCommand request, CancellationToken cancellationToken)
    {
        var approveUserCWID = _httpContextAccessor.HttpContext.GetCwid();
        var result = await _goalsPlanningClient.ApproveGoalsPlanningAsync(approveUserCWID, request.GoalsPlanningIntegrationIds);

        if (result.Data)
        {
            foreach (var goalsPlanning in request.GoalsPlanningIntegrationIds)
            {
                var goalsPlanningInfo = await _elasticSearchClient.GetByGoalsPlanningIntegrationId(goalsPlanning);

                if (goalsPlanningInfo is not null)
                {
                    var emailPartner = goalsPlanningInfo.PartnerName;
                    var namePartner = goalsPlanningInfo.EmailGoalsPlanning;
                    var content = Translations.EmailApprove.Replace("#PARCEIRO#", namePartner);

                    if (!string.IsNullOrEmpty(emailPartner))
                        await _serviceBusClient.SendEmailMessage(new Email(emailPartner, Translations.NoReplyEmail, Translations.DefaultSender, Translations.SubjectApprove, content, true), cancellationToken);
                }
                else
                    _logger.LogError($"GetByGoalsPlanningIntegrationId não retornou dados do elastic - GoalsPlanningIntegrationId: {goalsPlanning}");
            } 
        }

        return await _response.CreateSuccessResponseAsync(result);
    }
}
