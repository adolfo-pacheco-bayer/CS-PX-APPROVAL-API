using PX.Approval.Application.ViewModel;
using PX.Approval.Domain.Models;

namespace PX.Approval.Application.Common.Interfaces
{
    public interface IElasticSearchServiceClient
    {
        Task<List<PlanningElasticViewModel>> Get(Guid cropIntegrationId);
        Task<IEnumerable<GoalsPlanningStatusHistoryViewModel>> GetHistory(Guid goalsPlanningIntegrationId);

        Task<List<PlanningElasticViewModel>> GetGraphicsByCropIntegrationId(string cropIntegrationId);

        Task<TotalViewModel> GetTotal(Guid cropIntegrationId);

        Task<PlanningElasticViewModel> GetByGoalsPlanningIntegrationId(Guid goalsPlanningIntegrationId);
        Task<PlanningElasticViewModel> GetBrandsByGoalsPlanningId(string goalsPlanningId);

        Task<List<PlanningElasticEntity>> GetByFilter(Guid cropIntegrationId, string name);
    }
}


