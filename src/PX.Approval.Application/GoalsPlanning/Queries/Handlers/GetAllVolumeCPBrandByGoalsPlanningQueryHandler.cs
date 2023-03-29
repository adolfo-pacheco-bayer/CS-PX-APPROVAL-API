using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Application.ViewModel;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Response;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers
{
    public class GetAllVolumeCPBrandByGoalsPlanningQueryHandler : IRequestHandler<GetAllVolumeCPBrandByGoalsPlanningQuery, Response>
    {
        private IResponse _response;
        private ILogger<GetAllVolumeCPBrandByGoalsPlanningQueryHandler> _logger;
        private IElasticSearchServiceClient _elasticSearchClient;
        private readonly IMapper _mapper;


        public GetAllVolumeCPBrandByGoalsPlanningQueryHandler(IResponse response, ILogger<GetAllVolumeCPBrandByGoalsPlanningQueryHandler> logger, IElasticSearchServiceClient elasticSearchClient, IMapper mapper)
        {
            _response = response;
            _logger = logger;
            _elasticSearchClient = elasticSearchClient;
            _mapper = mapper;
        }


        public async Task<Response> Handle(GetAllVolumeCPBrandByGoalsPlanningQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new GetAllVolumeCPBrandByGoalsPlanningViewModel();

                var goalsPlannings = await _elasticSearchClient.GetBrandsByGoalsPlanningId(request.GoalsPlanningId.ToString());

                if (goalsPlannings.Brands == null)
                    return await _response.CreateSuccessResponseAsync(new List<VolumeBrandsViewModel>());

                var brands = goalsPlannings.Brands.Where(x => x.Type == Domain.Models.ProductFamilyType.CP);

                var volumeBrands = _mapper.Map<IEnumerable<VolumeBrandsViewModel>>(brands);

                result.FirstSellinPeriodRequired = goalsPlannings.FirstSellinPeriodRequired;
                result.VolumeBrands = volumeBrands;

                return await _response.CreateSuccessResponseAsync(result);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
