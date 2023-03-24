using MediatR;
using Microsoft.Extensions.Logging;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers
{
    public class GetPlanningTotalQueryHandler : IRequestHandler<GetPlanningTotalQuery, Response>
    {
        private IResponse _response;
        private ILogger<GetPlanningTotalQueryHandler> _logger;
        private IElasticSearchServiceClient _elasticSearchClient;

        public GetPlanningTotalQueryHandler(IResponse response, ILogger<GetPlanningTotalQueryHandler> logger, IElasticSearchServiceClient elasticSearchClient)
        {
            _response = response;
            _logger = logger;
            _elasticSearchClient = elasticSearchClient;
        }


        public async Task<Response> Handle(GetPlanningTotalQuery request, CancellationToken cancellationToken)
        {
            if (request.CropIntegrationId == null)
                return await _response.CreateErrorResponseAsync(new { message = "CropIntegrationId Obrigatorio" }, System.Net.HttpStatusCode.BadRequest);

            var result = await _elasticSearchClient.GetTotal(request.CropIntegrationId);

            return await _response.CreateSuccessResponseAsync(result);

        }
    }
}
