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

public class ReturnStatusGoalsPlanningCommandHandler : IRequestHandler<ReturnStatusGoalsPlanningCommand, Response>
{
    private IResponse _response;
    private IGoalsPlanningClient _goalsPlanningClient;
    private IHttpContextAccessor _httpContextAccessor;
    private IElasticSearchServiceClient _elasticSearchClient;
    private readonly IServiceBus _serviceBusClient;
    private readonly ILogger<ReturnStatusGoalsPlanningCommandHandler> _logger;

    public ReturnStatusGoalsPlanningCommandHandler(IResponse response,
        IGoalsPlanningClient goalsPlanningClient,
        IHttpContextAccessor httpContextAccessor,
        IElasticSearchServiceClient elasticSearchClient,
        IServiceBus serviceBusClient,
        ILogger<ReturnStatusGoalsPlanningCommandHandler> logger)
    {
        _response = response;
        _goalsPlanningClient = goalsPlanningClient;
        _httpContextAccessor = httpContextAccessor;
        _elasticSearchClient = elasticSearchClient;
        _serviceBusClient = serviceBusClient;
        _logger = logger;
    }

    public async Task<Response> Handle(ReturnStatusGoalsPlanningCommand request, CancellationToken cancellationToken)
    {
        var user = _httpContextAccessor.HttpContext.GetUser();

        if (user is not null)
        {
            var role = user.Roles.Where(x => x.Name.ToUpper().Contains("CS-PLANOMETAS_ADMINISTRADOR")).Any();

            if (!role)
                return await _response.CreateErrorResponseAsync(new { message = "Usuário não tem permissão para executar essa ação." }, System.Net.HttpStatusCode.Unauthorized);
        }

        var returnUserCWID = _httpContextAccessor.HttpContext.GetCwid();
        var result = await _goalsPlanningClient.ReturnStatusGoalsPlanningAsync(returnUserCWID, request.Reason, request.File, request.FileName, request.GoalsPlanningIntegrationIds);

        if (result.Data)
        {
            foreach (var goalsPlanning in request.GoalsPlanningIntegrationIds)
            {
                var goalsPlanningInfo = await _elasticSearchClient.GetByGoalsPlanningIntegrationId(goalsPlanning);

                if (goalsPlanningInfo is not null)
                {
                    var emailPartner = goalsPlanningInfo.EmailGoalsPlanning;
                    var namePartner = goalsPlanningInfo.PartnerName;
                    var content = Translations.EmailReturn.Replace("#PARCEIRO#", namePartner).Replace("#MOTIVO#", request.Reason);

                    if (!string.IsNullOrEmpty(emailPartner))
                        await _serviceBusClient.SendEmailMessage(new Email(emailPartner, Translations.NoReplyEmail, Translations.DefaultSender, Translations.SubjectReturn, content, true), cancellationToken);
                }
                else
                    _logger.LogError($"GetByGoalsPlanningIntegrationId não retornou dados do elastic - ReturnStatusGoalsPlanningCommand - GoalsPlanningIntegrationId: {goalsPlanning}");
            }
        }

        return await _response.CreateSuccessResponseAsync(result);
    }
}
