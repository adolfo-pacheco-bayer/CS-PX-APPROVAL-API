using MediatR;
using Microsoft.Extensions.Logging;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers
{
    public class GetApprovalHistoryQueryHandlercs : IRequestHandler<GetApprovalHistoryQuery, Response>
    {
        private IResponse _response;
        private ILogger<GetAllApprovedGoalsPlanQueryHandlercs> _logger;
        private IElasticSearchServiceClient _elasticSearchClient;

        public GetApprovalHistoryQueryHandlercs(IElasticSearchServiceClient elasticSearchServiceClient,
                                                            IResponse response,
                                                            ILogger<GetAllApprovedGoalsPlanQueryHandlercs> logger)
        {
            _response = response;
            _logger = logger;
            _elasticSearchClient = elasticSearchServiceClient;
        }



        public async Task<Response> Handle(GetApprovalHistoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _elasticSearchClient.Get(request.GoalsPlanningIntegrationId);

            return await _response.CreateSuccessResponseAsync(result);


        }

    }
}
