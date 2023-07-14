using MediatR;
using Microsoft.Extensions.Logging;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers
{
    public class GetAllApprovedGoalsPlanQueryHandlercs : IRequestHandler<GetInApprovalGoalsPlanningQuery, Response>
    {
        private IResponse _response;
        private ILogger<GetAllApprovedGoalsPlanQueryHandlercs> _logger;
        private IElasticSearchServiceClient _elasticSearchClient;

        public GetAllApprovedGoalsPlanQueryHandlercs(IElasticSearchServiceClient elasticSearchServiceClient,
                                                            IResponse response,
                                                            ILogger<GetAllApprovedGoalsPlanQueryHandlercs> logger)
        {
            _response = response;
            _logger = logger;
            _elasticSearchClient = elasticSearchServiceClient;
        }



        public async Task<Response> Handle(GetInApprovalGoalsPlanningQuery request, CancellationToken cancellationToken)
        {
            var result = await _elasticSearchClient.Get(request.CropIntegrationId);


            //TO DO REFACTORY
            //foreach (var item in result)
            //{
            //    if (item.PartnerType.Equals("Wholesaler"))
            //    {
            //        item.PartnerType = "Atacadista";
            //    }
            //    else if (item.PartnerType.Equals("Distributor"))
            //    {
            //        item.PartnerType = "Distribuidor";
            //    }
            //    else
            //    {
            //        item.PartnerType = "Cooperativa";
            //    }
            //    item.DaysInQueue = DateTime.Now.Subtract(item.LastUpdate).Days;
            //}
            return await _response.CreateSuccessResponseAsync(result.Where(x => x.Status.Equals("InApproval")));
            
        }
    }
}
