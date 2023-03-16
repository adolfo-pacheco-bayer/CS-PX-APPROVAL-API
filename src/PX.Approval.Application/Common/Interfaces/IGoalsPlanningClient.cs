using PX.Approval.Application.ViewModel;

namespace PX.Approval.Application.Common.Interfaces;

public interface IGoalsPlanningClient
{
    Task<IEnumerable<GetAllGoalsPlanningViewModel>> GetAllGoalsPlanningByCropIntegrationsIdAsync(Guid[] cropIntegrationIds);
    Task<bool> ReturnStatusGoalsPlanningAsync(string reason, List<Guid> goalsPlanningIntegrationIds);
}

