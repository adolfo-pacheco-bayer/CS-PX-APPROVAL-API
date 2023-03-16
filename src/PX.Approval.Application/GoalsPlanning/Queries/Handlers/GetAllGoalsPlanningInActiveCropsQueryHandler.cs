using MediatR;
using Microsoft.Extensions.Logging;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers
{
    public class GetAllGoalsPlanningInActiveCropsQueryHandler : IRequestHandler<GetAllGoalsPlanningInActiveCropsQuery, Response>
    {
        private IResponse _response;
        private ILogger<GetAllGoalsPlanningInActiveCropsQueryHandler> _logger;
        private IElasticSearchServiceClient _elasticSearchClient;

        public GetAllGoalsPlanningInActiveCropsQueryHandler(IElasticSearchServiceClient elasticSearchServiceClient,
                                                            IResponse response,
                                                            ILogger<GetAllGoalsPlanningInActiveCropsQueryHandler> logger)
        {
            _response = response;
            _logger = logger;
            _elasticSearchClient = elasticSearchServiceClient;
        }

        public async Task<Response> Handle(GetAllGoalsPlanningInActiveCropsQuery request, CancellationToken cancellationToken)
        {

            if (request.CropIntegrationId == null)
                return await _response.CreateErrorResponseAsync(new { message = "CropIntegrationId Obrigatorio" }, System.Net.HttpStatusCode.BadRequest);

            var result = await _elasticSearchClient.Get(request.CropIntegrationId);

            return await _response.CreateSuccessResponseAsync(result);
        }
    }
}
