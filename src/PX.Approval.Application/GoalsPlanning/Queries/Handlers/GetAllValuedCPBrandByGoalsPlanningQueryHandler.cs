using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Application.ViewModel;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;
using PX.Crop.Domain.Enum;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers
{
    public class GetAllValuedCPBrandByGoalsPlanningQueryHandler : IRequestHandler<GetAllValuedCPBrandByGoalsPlanningQuery, Response>
    {
        private IResponse _response;
        private ILogger<GetAllValuedCPBrandByGoalsPlanningQueryHandler> _logger;
        private IElasticSearchServiceClient _elasticSearchClient;
        private readonly IMapper _mapper;


        public GetAllValuedCPBrandByGoalsPlanningQueryHandler(IResponse response, ILogger<GetAllValuedCPBrandByGoalsPlanningQueryHandler> logger, IElasticSearchServiceClient elasticSearchClient, IMapper mapper)
        {
            _response = response;
            _logger = logger;
            _elasticSearchClient = elasticSearchClient;
            _mapper = mapper;
        }


        public async Task<Response> Handle(GetAllValuedCPBrandByGoalsPlanningQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var result = new GetAllValuedCPBrandByGoalsPlanningViewModel();

                var goalsPlannings = await _elasticSearchClient.GetBrandsByGoalsPlanningId(request.GoalsPlanningId.ToString());

                if (goalsPlannings.Brands == null)
                    return await _response.CreateSuccessResponseAsync(new List<ValuedBrandsViewModel>());

                var brands = goalsPlannings.Brands.Where(x => x.Type == Domain.Models.ProductFamilyType.CP.ToString());

                var valuedBrands = _mapper.Map<IEnumerable<ValuedBrandsViewModel>>(brands);

                result.FirstSellinPeriodRequired = goalsPlannings.FirstSellinPeriodRequired;
                result.ValuedBrands = valuedBrands;

                return await _response.CreateSuccessResponseAsync(result);
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
