using MediatR;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Application.ViewModel;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;
using System.Collections.Generic;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers
{
    public class GetAllGoalsPlanningInActiveCropsQueryHandler : IRequestHandler<GetAllGoalsPlanningInActiveCropsQuery, Response>
    {
        private IGoalsPlanningClient _goalsPlanningClient;
        private ICropServiceClient _cropClient;
        private IResponse _response;

        public GetAllGoalsPlanningInActiveCropsQueryHandler(IGoalsPlanningClient goalsPlanningClient,
                                                            ICropServiceClient cropClient, 
                                                            IResponse response)
        {
            _goalsPlanningClient = goalsPlanningClient;
            _cropClient = cropClient;
            _response = response;
        }

        public async Task<Response> Handle(GetAllGoalsPlanningInActiveCropsQuery request, CancellationToken cancellationToken)
        {
            var allActiveCrops = await _cropClient.GetAllActiveCrops();

            var allActiveCropIds = allActiveCrops.Select(x => x.IntegrationId).ToArray();

            var allGoalsPlanning = await _goalsPlanningClient.GetAllGoalsPlanningByCropIntegrationsIdAsync(allActiveCropIds);

            var allGoalsPlanningComplete = new List<GetAllGoalsPlanningViewModel>();

            foreach (var item in allGoalsPlanning)
            {
                var crop = allActiveCrops.FirstOrDefault(x => x.IntegrationId == item.CropIntegrationId);

                allGoalsPlanningComplete.Add(new GetAllGoalsPlanningViewModel()
                {
                    CropIntegrationId = item.CropIntegrationId,
                    Name = crop.Name,
                    CropPeriod = $"{crop.StartPeriod.ToShortDateString()} a {crop.EndPeriod.ToShortDateString()}",
                    PlanningPeriod = $"{crop.StartPlanningPeriod.ToShortDateString()} a {crop.EndPlanningPeriod.ToShortDateString()}",
                    IntegrationId = item.IntegrationId,
                    PartnerGroupCode = item.PartnerGroupCode,
                    Status = item.Status,
                    StatusHistory = item.StatusHistory,
                    DocumentApprovalHistory = item.DocumentApprovalHistory,
                });
            }

            return await _response.CreateSuccessResponseAsync(allGoalsPlanningComplete);
        }
    }
}
