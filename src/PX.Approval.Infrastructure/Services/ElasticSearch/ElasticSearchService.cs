using AutoMapper;
using Elastic.Clients.Elasticsearch;
using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Nest;
using Newtonsoft.Json;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Application.ViewModel;
using PX.Approval.Domain.Models;
using PX.Approval.Domain.Response;
using PX.Approval.Infrastructure.Services.Accomplashiment;
using PX.Library.Common.Tools.Http;
using System.Net.Http;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace PX.Approval.Infrastructure.Services.ElasticSearch
{
    public class ElasticSearchService : IElasticSearchServiceClient
    {
        private string _cloudId;
        private string _apiKey;
        private string _goalsPlanningIndex;
        private string _totalsIndex;
        private string _Uri;
        private IMapper _mapper;
        private ElasticsearchClientSettings _settings;
        private readonly IOptions<AccomplashimentClientConfiguration> _options;
        private readonly HttpClient _httpClient;


        public ElasticSearchService(IConfiguration configuration, IOptions<AccomplashimentClientConfiguration> options, IMapper mapper)
        {
            _cloudId = configuration.GetSection("ElasticConfiguration:ElasticSearchCloudId").Value;
            _apiKey = configuration.GetSection("ElasticConfiguration:ElasticSearchApiKey").Value;
            _goalsPlanningIndex = configuration.GetSection("ElasticConfiguration:ElasticSearchIndexApproval").Value;
            _totalsIndex = configuration.GetSection("ElasticConfiguration:ElasticSearchIndexTotalApproval").Value;
            _Uri = configuration.GetSection("ElasticConfiguration:Uri").Value;
            _options = options;
            _mapper = mapper;
        }

        /// <summary>
        /// get values for graphic by percent
        /// </summary>
        /// <param name="cropIntegrationId"></param>
        /// <returns></returns>
        public async Task<List<PlanningElasticViewModel>> Get(Guid cropIntegrationId)
        {
            
            var endpoint = string.Format(_options.Value.PlanningGetServiceEndPoint, cropIntegrationId);
            var address = $"{_options.Value.PlanningBaseAddress}{endpoint}";
            var result = await RequestHandler.GetAsync(_httpClient, address);

            var content = await result.Content.ReadAsStringAsync();

            var response = JsonConvert
                                            .DeserializeObject<RequestContextResponse<List<PlanningElasticViewModel>>>(content);

            if (response is null || response.StatusCode != 200)
                return null;

            var planning = response?.Data;

            return planning;

            //return response.Documents.ToList();
        }

        /// <summary>
        /// get values for graphic by percent
        /// </summary>
        /// <param name="goalsPlanningIntegrationId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<GoalsPlanningStatusHistoryViewModel>> GetHistory(Guid goalsPlanningIntegrationId)
        {
            var endpoint = string.Format(_options.Value.PlanningGetHistoryServiceEndPoint, goalsPlanningIntegrationId);
            var address = $"{_options.Value.PlanningBaseAddress}{endpoint}";
            var result = await RequestHandler.GetAsync(_httpClient, address);
           

            var content = await result.Content.ReadAsStringAsync();

            var response = JsonConvert
                                            .DeserializeObject<RequestContextResponse<IEnumerable<GoalsPlanningStatusHistoryViewModel>>>(content);

            if (response is null || response.StatusCode != 200)
                return null;

            var planning = response?.Data;

            return planning;
         
        }

        /// <summary>
        /// get values for total
        /// </summary>
        /// <param name="cropIntegrationId"></param>
        /// <returns></returns>
        public async Task<TotalViewModel> GetTotal(Guid cropIntegrationId)
        {
            var endpoint = string.Format(_options.Value.PlanningGetTotalServiceEndPoint, cropIntegrationId);
            var address = $"{_options.Value.PlanningBaseAddress}{endpoint}";

            var result = await RequestHandler.GetAsync(_httpClient, address);

            var content = await result.Content.ReadAsStringAsync();

            var response = JsonConvert
                                            .DeserializeObject<RequestContextResponse<TotalViewModel>>(content);

            if (response is null || response.StatusCode != 200)
                return null;

            var planning = response?.Data;

            return planning;

        }

        public async Task<List<PlanningElasticViewModel>> GetGraphicsByCropIntegrationId(string cropIntegrationId)
        {
            var endpoint = string.Format(_options.Value.PlanningGetGraphicsByCropIntegrationIdServiceEndPoint, cropIntegrationId);
            var address = $"{_options.Value.PlanningBaseAddress}{endpoint}";

            var result = await RequestHandler.GetAsync(_httpClient, address);

            var content = await result.Content.ReadAsStringAsync();

            var response = JsonConvert
                                            .DeserializeObject<RequestContextResponse<List<PlanningElasticViewModel>>>(content);

            if (response is null || response.StatusCode != 200)
                return null;

            var planning = response?.Data;

            return planning;

        
        }

        public async Task<PlanningElasticViewModel> GetByGoalsPlanningIntegrationId(Guid goalsPlanningIntegrationId)
        {

            var endpoint = string.Format(_options.Value.PlanningGetByGoalsPlanningIntegrationIdServiceEndPoint, goalsPlanningIntegrationId);
            var address = $"{_options.Value.PlanningBaseAddress}{endpoint}";
            var result = await RequestHandler.GetAsync(_httpClient, address);

            var content = await result.Content.ReadAsStringAsync();

            var response = JsonConvert
                                            .DeserializeObject<RequestContextResponse<PlanningElasticViewModel>>(content);

            if (response is null || response.StatusCode != 200)
                return null;

            var planning = response?.Data;

            return planning;

           
        }


        public async Task<PlanningElasticViewModel> GetBrandsByGoalsPlanningId(string goalsPlanningId)
        {
            var endpoint = string.Format(_options.Value.PlanningGetBrandsByGoalsPlanningIdServiceEndPoint, goalsPlanningId);
            var address = $"{_options.Value.PlanningBaseAddress}{endpoint}";

            var result = await RequestHandler.GetAsync(_httpClient, address);

            var content = await result.Content.ReadAsStringAsync();

            var response = JsonConvert
                                            .DeserializeObject<RequestContextResponse<PlanningElasticViewModel>>(content);

            if (response is null || response.StatusCode != 200)
                return null;

            var planning = response?.Data;

            return planning;

        }


        public async Task<List<PlanningElasticEntity>> GetByFilter(Guid cropIntegrationId, string name)
        {
            try
            {

                var endpoint = string.Format(_options.Value.PlanningGetByFilterServiceEndPoint, cropIntegrationId, name );
                var address = $"{_options.Value.PlanningBaseAddress}{endpoint}";

                var result = await RequestHandler.GetAsync(_httpClient, address);

                var content = await result.Content.ReadAsStringAsync();

                var response = JsonConvert
                                                .DeserializeObject<RequestContextResponse<List<PlanningElasticEntity>>>(content);

                if (response is null || response.StatusCode != 200)
                    return null;

                var planning = response?.Data;

                return planning;
                //var uri = new Uri(_Uri);
                //var apikey = new ApiKeyAuthenticationCredentials(_apiKey);
                //var client = new ElasticClient(new ConnectionSettings(_cloudId, apikey));


                //QueryContainer query = new QueryContainerDescriptor<PlanningElasticViewModel>();

                //if (!string.IsNullOrEmpty(name))
                //{
                //    query = query && new QueryContainerDescriptor<PlanningElasticViewModel>()
                //            .MatchPhrasePrefix(qs => qs.Field(fs => fs.PartnerName).Query(name));
                //}

                //query = query && new QueryContainerDescriptor<PlanningElasticViewModel>()
                //     .Match(qs => qs.Field("cropIntegrationId.keyword").Query(cropIntegrationId.ToString()));

                //var result = await client.SearchAsync<PlanningElasticEntity>(s => s.Index(_goalsPlanningIndex)
                //                                                                     .Query(q => q
                //                                                                         .Bool(b => b
                //                                                                             .Should(
                //                                                                                 bs => query
                //                                                                             )
                //                                                                            .MinimumShouldMatch(1)
                //                                                                         )
                //                                                                      )
                //                                                                      .Size(10000)
                //                                                                      .From(0));

                //return result.Documents.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
