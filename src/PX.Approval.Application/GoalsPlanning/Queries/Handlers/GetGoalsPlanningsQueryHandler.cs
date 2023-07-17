using AutoMapper;
using MassTransit.Initializers;
using MediatR;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.Extensions.Logging;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Domain.DomainObjects;
using PX.Approval.Domain.Messages.Messages;
using PX.Approval.Domain.Models;
using PX.Approval.Domain.Response;
using PX.Crop.Domain.Enum;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers
{
    public class GetGoalsPlanningsQueryHandler : IRequestHandler<GetGoalsPlanningsQuery, Response>
    {
        private IResponse _response;
        private ILogger<GetGoalsPlanningsQuery> _logger;
        private IElasticSearchServiceClient _elasticSearchClient;
        private readonly IMapper _mapper;


        public GetGoalsPlanningsQueryHandler(IResponse response, ILogger<GetGoalsPlanningsQuery> logger, IElasticSearchServiceClient elasticSearchClient, IMapper mapper)
        {
            _response = response;
            _logger = logger;
            _elasticSearchClient = elasticSearchClient;
            _mapper = mapper;
        }


        public async Task<Response> Handle(GetGoalsPlanningsQuery request, CancellationToken cancellationToken)
        {
            var result = await _elasticSearchClient.GetByFilter(request.CropIntegrationId, request.Name);

            if (result == null)
                return await _response.CreateErrorResponseAsync(System.Net.HttpStatusCode.BadRequest);

            var model = _mapper.Map<List<PlanningElasticViewModel>>(result);
            model = await ApplyFilters(model, request);
                                    
            return await _response.CreateSuccessResponseAsync(model);

        }

        private async Task<List<PartnerType>> ConvertToPartnerType(string partnerType)
        {
            List<PartnerType> partnerTypes = new List<PartnerType>();

            if (!string.IsNullOrEmpty(partnerType))
            {
                foreach (var item in partnerType.Split(",").ToList())
                {
                    try
                    {
                        partnerTypes.Add((PartnerType)(Convert.ToInt16(item)));
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

            return partnerTypes;
        }


        private async Task<List<GoalsPlanningStatus>> ConvertToStatusType(string status)
        {
            List<GoalsPlanningStatus> planningStatus = new List<GoalsPlanningStatus>();

            if (!string.IsNullOrEmpty(status))
            {
                foreach (var item in status.Split(",").ToList())
                {
                    try
                    {
                        planningStatus.Add((GoalsPlanningStatus)(Convert.ToInt16(item)));
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

            return planningStatus;
        }

        private async Task<List<PlanningElasticViewModel>> ApplyFilters(List<PlanningElasticViewModel> listResult, GetGoalsPlanningsQuery request)
        {
            var listStatus = ConvertToStatusType(request.Status).Result.Select(x => Enum.GetName(x));
            var listPartnerType = ConvertToPartnerType(request.PartnerType).Result.Select(x => Enum.GetName(x));


            if (listStatus.Any() && listPartnerType.Any())
            {
                listResult = listResult.Where(x => listStatus.Contains(x.Status) && listPartnerType.Contains(x.PartnerType)).ToList();
            }
            else if (!listStatus.Any() && listPartnerType.Any())
            {
                listResult = listResult.Where(x => listPartnerType.Contains(x.PartnerType)).ToList();
            }
            else if (listStatus.Any() && !listPartnerType.Any())
            {
                listResult = listResult.Where(x => listStatus.Contains(x.Status)).ToList();
            }

            return listResult;
        }
    }
}
