using MediatR;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers
{
    public class GetAllApprovedGoalsPlanQueryHandlercs : IRequestHandler<GetInApprovalGoalsPlanningQuery, Response>
    {
        private IResponse _response;
        private IGoalsPlanningClient _goalsPlanningClient;

        public GetAllApprovedGoalsPlanQueryHandlercs(IResponse response, IGoalsPlanningClient goalsPlanningClient)
        {
            _response = response;
            _goalsPlanningClient = goalsPlanningClient;
        }

        public async Task<Response> Handle(GetInApprovalGoalsPlanningQuery request, CancellationToken cancellationToken)
        {
            var result = await _goalsPlanningClient.GetInApprovalGoalsPlanning(request.CropIntegrationIds.ToArray());

            return await _response.CreateSuccessResponseAsync(result);
            
        }
    }
}
