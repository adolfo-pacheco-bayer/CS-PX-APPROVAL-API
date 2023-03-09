using MediatR;
using Microsoft.Extensions.Logging;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers
{
    public class GetAllGoalsPlanningInActiveCropsQueryHandler : IRequestHandler<GetAllGoalsPlanningInActiveCropsQuery, Response>
    {
        private IGoalsPlanningClient _goalsPlanningClient;
        private ICropServiceClient _cropClient;
        private IResponse _response;
        private ILogger<GetAllGoalsPlanningInActiveCropsQueryHandler> _logger;

        public GetAllGoalsPlanningInActiveCropsQueryHandler(IGoalsPlanningClient goalsPlanningClient,
                                                            ICropServiceClient cropClient, 
                                                            IResponse response,
                                                            ILogger<GetAllGoalsPlanningInActiveCropsQueryHandler> logger)
        {
            _goalsPlanningClient = goalsPlanningClient;
            _cropClient = cropClient;
            _response = response;
            _logger = logger;
        }

        public async Task<Response> Handle(GetAllGoalsPlanningInActiveCropsQuery request, CancellationToken cancellationToken)
        {            
            var allActiveCrops = await _cropClient.GetAllActiveCrops();

            var allActiveCropIds = allActiveCrops.Select(x => x.IntegrationId).ToArray();

            var allGoalsPlanning = await _goalsPlanningClient.GetAllGoalsPlanningByCropIntegrationsIdAsync(allActiveCropIds);
            return await _response.CreateSuccessResponseAsync(allGoalsPlanning);
        }
    }
}
