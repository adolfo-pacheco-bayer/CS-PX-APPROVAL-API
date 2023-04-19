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
            // var result = await _elasticSearchClient.Get(request.CropIntegrationId);


            //TO DO REFACTORY

            //TO DO REFACTORY
            var History = new GoalsPlanningStatusHistoryViewModel()
            {
                GoalsPlanningId = 34,
                Status = 1,
                StatusChanged = new DateTime(),
                StaStatusChangedUserCWID = "atacadista.seeds@gmail.com",
                Reason = null,
                IntegrationId = "C02C2176-5DB2-483B-9C72-D0132F242D6A",
                UrlFile = null,
            };


            return await _response.CreateSuccessResponseAsync(History);
         
            
        }

        public class GoalsPlanningStatusHistoryViewModel
        {
            public int GoalsPlanningId { get; set; }
            public int Status { get; set; }
            public DateTime StatusChanged { get; set; }
            public string StaStatusChangedUserCWID { get; set; }
            public string? Reason { get; set; }
            public string IntegrationId { get; set; }
            public string? UrlFile { get; set; }
        }
    }
}
