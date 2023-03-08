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

            return JsonConvert.DeserializeObject<IEnumerable<GetAllActiveCropsViewModel>>(result.Data);
        }
    }
}
