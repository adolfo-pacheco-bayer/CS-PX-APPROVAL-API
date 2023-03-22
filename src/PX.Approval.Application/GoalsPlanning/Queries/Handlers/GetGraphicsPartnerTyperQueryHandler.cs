using MediatR;
using Microsoft.Extensions.Logging;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Application.ViewModel;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;
using PX.Crop.Domain.Enum;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers
{
    public class GetGraphicsPartnerTyperQueryHandler : IRequestHandler<GetGraphicsPartnerTyperQuery, Response>
    {
        private IResponse _response;
        private ILogger<GetGraphicsPartnerTyperQueryHandler> _logger;
        private IElasticSearchServiceClient _elasticSearchClient;

        public GetGraphicsPartnerTyperQueryHandler(IResponse response, ILogger<GetGraphicsPartnerTyperQueryHandler> logger, IElasticSearchServiceClient elasticSearchClient)
        {
            _response = response;
            _logger = logger;
            _elasticSearchClient = elasticSearchClient;
        }

        public async Task<Response> Handle(GetGraphicsPartnerTyperQuery request, CancellationToken cancellationToken)
        {
            var goalsPlannings = await _elasticSearchClient.GetGraphicsByCropIntegrationId(request.CropIntegrationId.ToString());
            var graphic = new GraphicPartnerType();
            graphic.Distributor = ((double)goalsPlannings.Count(i => i.PartnerType.ToLower().Equals(Enum.GetName(PartnerType.Distributor).ToLower()))) / goalsPlannings.Count() * 100;
            graphic.Wholesaler = ((double)goalsPlannings.Count(i => i.PartnerType.ToLower().Equals(Enum.GetName(PartnerType.Wholesaler).ToLower()))) / goalsPlannings.Count() * 100;
            graphic.Cooperative = ((double)goalsPlannings.Count(i => i.PartnerType.ToLower().Equals(Enum.GetName(PartnerType.Cooperative).ToLower()))) / goalsPlannings.Count() * 100;
            return await _response.CreateSuccessResponseAsync(graphic);
        }
    }
}
