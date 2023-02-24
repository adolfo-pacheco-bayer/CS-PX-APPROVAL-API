using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Application.ViewModel;
using PX.Planning.GrpcAPI;

namespace PX.Approval.Infrastructure.Services.GoalsPlanning;

public class GoalsPlanningGrpcClient : IGoalsPlanningClient
{
    private ILogger<GoalsPlanningGrpcClient> _logger;
    private IOptions<GoalsPlanningClientConfiguration> _config;

    public GoalsPlanningGrpcClient(IOptions<GoalsPlanningClientConfiguration> config)
    {
        _config = config;
    }

    public async Task<IEnumerable<GetAllGoalsPlanningViewModel>> GetAllGoalsPlanningByCropIntegrationsIdAsync(Guid[] cropIntegrationIds)
    {
        using var channel = GrpcChannel.ForAddress(_config.Value.GrpcUrl);
        var client = new GoalsPlanningService.GoalsPlanningServiceClient(channel);

        var request = new Request();
        request.CropIntegrationIds.AddRange(cropIntegrationIds.Select(x => new integrationIdList() { CropIntegrationId = x.ToString() }));

        var result = await client.GetAllGoalsPlanningByCropIdsAsync(request);
        return JsonConvert.DeserializeObject<IEnumerable<GetAllGoalsPlanningViewModel>>(result.Data);
    }
}
