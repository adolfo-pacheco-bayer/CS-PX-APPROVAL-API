using MediatR;
using Microsoft.Extensions.Logging;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Application.ViewModel;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;
using PX.Crop.Domain.Enum;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers
{
    public class GetGraphicStatusQueryHandler  : IRequestHandler<GetGraphicStatusQuery, Response>
    {
        private IResponse _response;
        private ILogger<GetGraphicStatusQueryHandler> _logger;
        private IElasticSearchServiceClient _elasticSearchClient;

        public GetGraphicStatusQueryHandler(IResponse response, ILogger<GetGraphicStatusQueryHandler> logger, IElasticSearchServiceClient elasticSearchClient)
        {
            _response = response;
            _logger = logger;
            _elasticSearchClient = elasticSearchClient;
        }

        public async Task<Response> Handle(GetGraphicStatusQuery request, CancellationToken cancellationToken)
        {
            var goalsPlannings = await _elasticSearchClient.GetGraphicsByCropIntegrationId(request.CropIntegrationId.ToString());

            goalsPlannings = goalsPlannings.Where(x => x.Status != null).ToList();

            var graphic = new GraphicsStatusViewModel();

            if (goalsPlannings.Any())
            {
                graphic.InApproval = ((double)goalsPlannings.Count(i => i.Status.ToLower().Equals(Enum.GetName(GoalsPlanningStatus.InApproval).ToLower()))) / goalsPlannings.Count() * 100;
                graphic.New = ((double)goalsPlannings.Count(i => i.Status.ToLower().Equals(Enum.GetName(GoalsPlanningStatus.New).ToLower()))) / goalsPlannings.Count() * 100;
                graphic.InPreparation = ((double)goalsPlannings.Count(i => i.Status.ToLower().Equals(Enum.GetName(GoalsPlanningStatus.InPreparation).ToLower()))) / goalsPlannings.Count() * 100;
                graphic.Approved = ((double)goalsPlannings.Count(i => i.Status.ToLower().Equals(Enum.GetName(GoalsPlanningStatus.Approved).ToLower()))) / goalsPlannings.Count() * 100;
                graphic.Canceled = ((double)goalsPlannings.Count(i => i.Status.ToLower().Equals(Enum.GetName(GoalsPlanningStatus.Canceled).ToLower()))) / goalsPlannings.Count() * 100;
                graphic.GoalsPlanningTotal = goalsPlannings.Count();

            }

            return await _response.CreateSuccessResponseAsync(graphic);
        }


    }
}
