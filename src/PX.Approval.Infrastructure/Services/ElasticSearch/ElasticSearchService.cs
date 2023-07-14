using AutoMapper;
using Elastic.Clients.Elasticsearch;
using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Nest;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Domain.Models;

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


        public ElasticSearchService(IConfiguration configuration, IMapper mapper)
        {
            _cloudId = configuration.GetSection("ElasticConfiguration:ElasticSearchCloudId").Value;
            _apiKey = configuration.GetSection("ElasticConfiguration:ElasticSearchApiKey").Value;
            _goalsPlanningIndex = configuration.GetSection("ElasticConfiguration:ElasticSearchIndexApproval").Value;
            _totalsIndex = configuration.GetSection("ElasticConfiguration:ElasticSearchIndexTotalApproval").Value;
            _Uri = configuration.GetSection("ElasticConfiguration:Uri").Value;
            _mapper = mapper;

            _settings = new ElasticsearchClientSettings(cloudId, new Elastic.Transport.ApiKey(apiKey))
                
                .DisableDirectStreaming(false)
                .EnableDebugMode();

        }

        /// <summary>
        /// get values for graphic by percent
        /// </summary>
        /// <param name="cropIntegrationId"></param>
        /// <returns></returns>
        public async Task<List<PlanningElasticViewModel>> Get(Guid cropIntegrationId)
        {
            _settings.DefaultIndex(_goalsPlanningIndexName);
            var client = new ElasticsearchClient(_settings);

            var settings = new ElasticsearchClientSettings(_cloudId, new Elastic.Transport.ApiKey(_apiKey))
                .DefaultIndex(_goalsPlanningIndex)
                .DisableDirectStreaming(false)
                .EnableDebugMode();

            var client = new ElasticsearchClient(settings);

            var response = await client.SearchAsync<PlanningElasticViewModel>(s => s.Query(
                                                                                        q => q.Match(
                                                                                        m => m.Field("cropIntegrationId.keyword")
                                                                                       .Query(cropIntegrationId.ToString()))));

            return response.Documents.ToList();
        }

        /// <summary>
        /// get values for graphic by percent
        /// </summary>
        /// <param name="goalsPlanningIntegrationId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<GoalsPlanningStatusHistoryViewModel>> GetHistory(Guid goalsPlanningIntegrationId)
        {
            _settings.DefaultIndex(_goalsPlanningIndexName);
            var client = new ElasticsearchClient(_settings);

            var settings = new ElasticsearchClientSettings(_cloudId, new ApiKey(_apiKey))
                .DefaultIndex(_goalsPlanningIndex);
            var client = new ElasticsearchClient(settings);

            var response = await client.SearchAsync<PlanningElasticViewModel>(s => s.Query(
                                                                                        q => q.Match(
                                                                                        m => m.Field("goalsPlanningIntegrationId.keyword")
                                                                                       .Query(goalsPlanningIntegrationId.ToString()))));

            var history = response.Documents
                                    .Where(x => x.GoalsPlanningIntegrationId == goalsPlanningIntegrationId.ToString())
                                    .First().StatusHistory
                                    .OrderBy(x => x.StatusChanged);

            return _mapper.Map<IEnumerable<GoalsPlanningStatusHistoryViewModel>>(history);
        }

        /// <summary>
        /// get values for total
        /// </summary>
        /// <param name="cropIntegrationId"></param>
        /// <returns></returns>
        public async Task<PlanningTotalElasticViewModel> GetTotal(Guid cropIntegrationId)
        {
            var settings = new ElasticsearchClientSettings(_cloudId, new ApiKey(_apiKey))
                 .DefaultIndex(_totalsIndex);
            var client = new ElasticsearchClient(settings);

            var response = await client.SearchAsync<PlanningTotalElasticViewModel>(s => s.Query(
                                                                                        q => q.Match(
                                                                                        m => m.Field("cropIntegrationId.keyword")
                                                                                              .Query(cropIntegrationId.ToString())))
                                                                                              .Size(1000));

            return response.Documents.LastOrDefault();
        }

        public async Task<List<PlanningElasticViewModel>> GetGraphicsByCropIntegrationId(string cropIntegrationId)
        {
            var settings = new ElasticsearchClientSettings(_cloudId, new ApiKey(_apiKey))
              .DefaultIndex(_goalsPlanningIndex);
            var client = new ElasticsearchClient(settings);


            var response = await client.SearchAsync<PlanningElasticViewModel>(s => s.Query(
                                                                                    q => q.Match(
                                                                                    m => m.Field("cropIntegrationId.keyword")
                                                                                          .Query(cropIntegrationId)))
                                                                                          .Size(1000));
            return response.Documents.ToList();
        }

        public async Task<PlanningElasticViewModel> GetByGoalsPlanningIntegrationId(Guid goalsPlanningIntegrationId)
        {

            var settings = new ElasticsearchClientSettings(_cloudId, new Elastic.Transport.ApiKey(_apiKey))
                .DefaultIndex(_goalsPlanningIndex);
            var client = new ElasticsearchClient(settings);

            var response = await client.SearchAsync<PlanningElasticViewModel>(s => s.Query(
                                                                                        q => q.Match(
                                                                                        m => m.Field("goalsPlanningIntegrationId.keyword")
                                                                                              .Query(goalsPlanningIntegrationId.ToString()))));

            return response.Documents.FirstOrDefault();
        }


        public async Task<PlanningElasticViewModel> GetBrandsByGoalsPlanningId(string goalsPlanningId)
        {
            var settings = new ElasticsearchClientSettings(_cloudId, new ApiKey(_apiKey))
              .DefaultIndex(_goalsPlanningIndex);
            var client = new ElasticsearchClient(settings);


            var response = await client.SearchAsync<PlanningElasticViewModel>(s =>
                                                                             s.Query(
                                                                               q => q.Match(
                                                                               m => m.Field("goalsPlanningIntegrationId.keyword")
                                                                                     .Query(goalsPlanningId))));
            return response.Documents.FirstOrDefault();
        }


        public async Task<List<PlanningElasticEntity>> GetByFilter(Guid cropIntegrationId, string name)
        {
            //try
            //{
                var uri = new Uri(_Uri);
                var apikey = new ApiKeyAuthenticationCredentials(_apiKey);                
                var client = new ElasticClient(new ConnectionSettings(_cloudId, apikey).DisableDirectStreaming(false)
                .EnableDebugMode());


                QueryContainer query = new QueryContainerDescriptor<PlanningElasticViewModel>();

                if (!string.IsNullOrEmpty(name))
                {
                    query = query && new QueryContainerDescriptor<PlanningElasticViewModel>()
                            .MatchPhrasePrefix(qs => qs.Field(fs => fs.PartnerName).Query(name));
                }

                query = query && new QueryContainerDescriptor<PlanningElasticViewModel>()
                     .Match(qs =>qs.Field("cropIntegrationId.keyword").Query(cropIntegrationId.ToString()));

               var result = await client.SearchAsync<PlanningElasticEntity>(s => s.Index(_goalsPlanningIndex)
                                                                                    .Query(q => q
                                                                                        .Bool(b => b
                                                                                            .Should(
                                                                                                bs => query
                                                                                            )
                                                                                           .MinimumShouldMatch(1)
                                                                                        )
                                                                                     )
                                                                                     .Size(10000)
                                                                                     .From(0));

                return result.Documents.ToList();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

        }
    }
}
