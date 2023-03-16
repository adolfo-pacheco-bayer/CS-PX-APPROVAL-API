using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Application.ViewModel;
using CropGrpcApi = PX.Crop.GrpcApi;

namespace PX.Approval.Infrastructure.Services.Crop
{
    public class CropGrpcClient : ICropServiceClient
    {
        private IOptions<CropClientConfiguration> _config;

        public CropGrpcClient(IOptions<CropClientConfiguration> config)
        {
            _config = config;
        }

        public async Task<IEnumerable<GetAllActiveCropsViewModel>> GetAllActiveCrops()
        {
            using var channel = GrpcChannel.ForAddress(_config.Value.GrpcUrl);
            var client = new CropGrpcApi.CropServices.CropServicesClient(channel);
            var result = await client.GetAllActiveCropsAsync(new CropGrpcApi.Request()
            {
                 UserName = "USER"
            });
            
            var crops = result.Crops.ToList();

            return crops.Select(x => new GetAllActiveCropsViewModel()
            {
                Description = x.Description,
                EndPeriod = x.EndPeriod.ToDateTime(),
                EndPlanningPeriod = x.EndPlanningPeriod.ToDateTime(),
                IsGoalPlanningValued = x.IsGoalPlanningValued,
                IntegrationId = new Guid(x.IntegrationId),
                Name = x.Name,
                StartPeriod = x.StartPeriod.ToDateTime(),
                StartPlanningPeriod = x.StartPlanningPeriod.ToDateTime()
            });
        }
    }
}
