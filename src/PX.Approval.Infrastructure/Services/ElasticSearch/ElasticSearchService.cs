using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Bcpg.OpenPgp;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Domain.Models;

namespace PX.Approval.Infrastructure.Services.ElasticSearch
{
    public class ElasticSearchService : IElasticSearchServiceClient
    {
        private string _cloudId;
        private string _apiKey;
        private string _goalsPlanningApproval;
        private string _goalsPlanningApprovalTotal;

        public ElasticSearchService(IConfiguration configuration)
        {
            _cloudId = configuration.GetSection("ElasticConfiguration:ElasticSearchCloudId").Value;
            _apiKey = configuration.GetSection("ElasticConfiguration:ElasticSearchApiKey").Value;
            _goalsPlanningApproval = configuration.GetSection("ElasticConfiguration:ElasticSearchIndexApproval").Value;
            _goalsPlanningApprovalTotal = configuration.GetSection("ElasticConfiguration:ElasticSearchIndexTotalApproval").Value;

        }

        /// <summary>
        /// get values for graphic by percent
        /// </summary>
        /// <param name="cropIntegrationId"></param>
        /// <returns></returns>
        public async Task<List<PlanningElasticViewModel>> Get(Guid cropIntegrationId)
        {

                var settings = new ElasticsearchClientSettings(_cloudId, new Elastic.Transport.ApiKey(_apiKey))
                    .DefaultIndex(_goalsPlanningApproval);
                var client = new ElasticsearchClient(settings);

                var response = await client.SearchAsync<PlanningElasticViewModel>(s => s.Query(
                                                                                            q => q.Match(
                                                                                            m => m.Field(f => f.CropIntegrationId)
                                                                                           .Query(cropIntegrationId.ToString()))));

                return response.Documents.ToList();
        }


        /// <summary>
        /// get values for total
        /// </summary>
        /// <param name="cropIntegrationId"></param>
        /// <returns></returns>
        public async Task<PlanningTotalElasticViewModel> GetTotal(Guid cropIntegrationId)
        {
            var settings = new ElasticsearchClientSettings(_cloudId, new Elastic.Transport.ApiKey(_apiKey))
                 .DefaultIndex(_goalsPlanningApprovalTotal);
            var client = new ElasticsearchClient(settings);

            var response = await client.SearchAsync<PlanningTotalElasticViewModel>(s => s.Query(
                                                                                        q => q.Match(
                                                                                        m => m.Field(f => f.CropIntegrationId)
                                                                                       .Query(cropIntegrationId.ToString()))));

            return response.Documents.FirstOrDefault();
        }

        public async Task<List<PlanningElasticViewModel>> GetGraphicsByCropIntegrationId(string cropIntegrationId)
        {
            var settings = new ElasticsearchClientSettings(_cloudId, new ApiKey(_apiKey))
              .DefaultIndex(_goalsPlanningApproval);
            var client = new ElasticsearchClient(settings);


            var response = await client.SearchAsync<PlanningElasticViewModel>(s =>
                                                                             s.Query(
                                                                               q => q.Match(
                                                                                 m => m.Field(f => f.CropIntegrationId)
                                                                                  .Query(cropIntegrationId)
                                                                                          ))
                                                                                     );
            return response.Documents.ToList();
        }

        public async Task<PlanningElasticViewModel> GetByGoalsPlanningIntegrationId(Guid goalsPlanningIntegrationId)
        {

            var settings = new ElasticsearchClientSettings(_cloudId, new Elastic.Transport.ApiKey(_apiKey))
                .DefaultIndex(_goalsPlanningApproval);
            var client = new ElasticsearchClient(settings);

            var response = await client.SearchAsync<PlanningElasticViewModel>(s => s.Query(
                                                                                        q => q.Match(
                                                                                        m => m.Field(f => f.GoalsPlanningIntegrationId)
                                                                                       .Query(goalsPlanningIntegrationId.ToString()))));

            return response.Documents.FirstOrDefault();
        }
    }
}
