using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Application.ViewModel;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers
{
    public class GetBrandSeedsGoalsPlanningQueryHandler :  IRequestHandler<GetBrandSeedsGoalsPlanningQuery, Response>
    {
        private IResponse _response;
        private ILogger<GetBrandSeedsGoalsPlanningQueryHandler> _logger;
        private IElasticSearchServiceClient _elasticSearchClient;
        private readonly IMapper _mapper;


        public GetBrandSeedsGoalsPlanningQueryHandler(IResponse response, ILogger<GetBrandSeedsGoalsPlanningQueryHandler> logger, IElasticSearchServiceClient elasticSearchClient, IMapper mapper)
        {
            _response = response;
            _logger = logger;
            _elasticSearchClient = elasticSearchClient;
            _mapper = mapper;
        }


        public async Task<Response> Handle(GetBrandSeedsGoalsPlanningQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var goalsPlannings = await _elasticSearchClient.GetBrandsByGoalsPlanningId(request.GoalsPlanningId.ToString());

                if (goalsPlannings.Brands == null)
                    return await _response.CreateSuccessResponseAsync(new List<ValuedBrandsViewModel>());

                var brands = goalsPlannings.Brands.Where(x => x.Type == Domain.Models.ProductFamilyType.Seeds.ToString());

                var valuedBrands = _mapper.Map<IEnumerable<GetBrandSeedsGoalsPlanningViewModel>>(brands);

                return await _response.CreateSuccessResponseAsync(valuedBrands);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
