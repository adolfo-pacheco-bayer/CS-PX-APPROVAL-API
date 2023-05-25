using Google.Protobuf;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PX.Approval.Application.Common.Interfaces;
using PX.Approval.Application.ViewModel;
using PX.Planning.GrpcAPI;
using System.Collections;

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
        request.CropIntegrationIds.AddRange(cropIntegrationIds.Select(x => new cropIntegrationIdList() { CropIntegrationId = x.ToString() }));

        var result = await client.GetAllGoalsPlanningByCropIdsAsync(request);
        return JsonConvert.DeserializeObject<IEnumerable<GetAllGoalsPlanningViewModel>>(result.Data);
    }

    public async Task<ModifyGoalsPlanningViewModel> ReturnStatusGoalsPlanningAsync(string returnUserCWID, string reason, List<Guid> goalsPlanningIntegrationIds)
    {
        using var channel = GrpcChannel.ForAddress(_config.Value.GrpcUrl);
        var client = new GoalsPlanningService.GoalsPlanningServiceClient(channel);

        var request = new ReturnStatusRequest();

        request.ReturnUserCWID = returnUserCWID;
        request.Reason = reason;
        request.GoalsPlanningIntegrationIds.AddRange(goalsPlanningIntegrationIds.Select(x => new goalsPlanningIntegrationIdList() { GoalsPlanningIntegrationId = x.ToString() }));

        var result = await client.ReturnStatusGoalsPlanningAsync(request);

        return new ModifyGoalsPlanningViewModel() { Data = result.Data, Message = result.Message };
    }

    public async Task<ModifyGoalsPlanningViewModel> CancelPlanningAsync(string cancelUserCWID, string reason, List<Guid> goalsPlanningIntegrationIds)
    {
        using var channel = GrpcChannel.ForAddress(_config.Value.GrpcUrl);
        var client = new GoalsPlanningService.GoalsPlanningServiceClient(channel);

        var request = new CancelRequest();

        request.CancelUserCWID = cancelUserCWID;
        request.Reason = reason;
        request.GoalsPlanningIntegrationIds.AddRange(goalsPlanningIntegrationIds.Select(x => new goalsPlanningIntegrationIdList() { GoalsPlanningIntegrationId = x.ToString() }));

        var result = await client.CancelGoalsPlanningAsync(request);

        return new ModifyGoalsPlanningViewModel() { Data = result.Data, Message = result.Message };
    }

    public async Task<ModifyGoalsPlanningViewModel> ApproveGoalsPlanningAsync(string returnUserCWID, List<Guid> goalsPlanningIntegrationIds)
    {
        using var channel = GrpcChannel.ForAddress(_config.Value.GrpcUrl);
        var client = new GoalsPlanningService.GoalsPlanningServiceClient(channel);

        var request = new ApproveRequest();

        request.ReturnUserCWID = returnUserCWID;
        request.GoalsPlanningIntegrationIds.AddRange(goalsPlanningIntegrationIds.Select(x => new goalsPlanningIntegrationIdList() { GoalsPlanningIntegrationId = x.ToString() }));

        var result = await client.ApproveGoalsPlanningAsync(request);

        return new ModifyGoalsPlanningViewModel() { Data = result.Data, Message = result.Message };
    }

    public async Task<ModifyGoalsPlanningViewModel> ReproveGoalsPlanningAsync(string returnUserCWID, string reason, byte[] file, string fileName, List<Guid> goalsPlanningIntegrationIds)
    {
        using var channel = GrpcChannel.ForAddress(_config.Value.GrpcUrl);
        var client = new GoalsPlanningService.GoalsPlanningServiceClient(channel);

        var request = new ReproveRequest();

        request.ReturnUserCWID = returnUserCWID;
        request.Reason = reason;
        request.File = ByteString.CopyFrom(file);
        request.FileName = fileName;
        request.GoalsPlanningIntegrationIds.AddRange(goalsPlanningIntegrationIds.Select(x => new goalsPlanningIntegrationIdList() { GoalsPlanningIntegrationId = x.ToString() }));

        var result = await client.ReproveGoalsPlanningAsync(request);

        return new ModifyGoalsPlanningViewModel() { Data = result.Data, Message = result.Message };
    }

    public async Task<IEnumerable<GetInApprovalGoalsPlanningViewModel>> GetInApprovalGoalsPlanning(Guid[] cropIntegrationIds)
    {
        using var channel = GrpcChannel.ForAddress(_config.Value.GrpcUrl);
        var client = new GoalsPlanningService.GoalsPlanningServiceClient(channel);

        var request = new GetInApprovalGoalsPlanningRequest();
        request.CropIntegrationIds.AddRange(cropIntegrationIds.Select(x => new cropIntegrationIdList() { CropIntegrationId = x.ToString() }));

        var result = await client.GetInApprovalGoalsPlanningByCropIdsAsync(request);
        var list = new List<GetInApprovalGoalsPlanningViewModel>();
        foreach(var item in result.Data)
        {
            var viewModel = new GetInApprovalGoalsPlanningViewModel()
            {
                CropIntegrationId = new Guid(item.CropIntegrationId),
                IntegrationId = new Guid(item.IntegrationId),
                PartnerGroupCode = item.PartnerGroupCode,
                Status = item.Status
            };
            
            foreach(var itemBrand in item.Brands)
            {
                viewModel.Brands.Add(new GetInApprovalGoalsPlanningBrandsViewModel()
                {
                    Bio = itemBrand.Bio,
                    BrandCropIntegrationId = new Guid(itemBrand.BrandCropIntegrationId),
                    ClassificationCPMargin = decimal.Parse(itemBrand.ClassificationCPMargin.ToString()),
                    FirstSellinPeriod = decimal.Parse(itemBrand.FirstSellinPeriod.ToString()),
                    Name = itemBrand.Name,
                    Price = decimal.Parse(itemBrand.Price.ToString()),
                    SecondSellinPeriod = decimal.Parse(itemBrand.SecondSellinPeriod.ToString()),
                    Sellout = decimal.Parse(itemBrand.Sellout.ToString()),
                    Type = itemBrand.Type
                });
            }

            list.Add(viewModel);
        }

        return list;
    }
}
