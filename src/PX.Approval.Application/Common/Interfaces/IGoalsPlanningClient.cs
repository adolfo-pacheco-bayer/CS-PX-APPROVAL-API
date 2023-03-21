using PX.Approval.Application.ViewModel;

namespace PX.Approval.Application.Common.Interfaces;

public interface IGoalsPlanningClient
{
    Task<IEnumerable<GetAllGoalsPlanningViewModel>> GetAllGoalsPlanningByCropIntegrationsIdAsync(Guid[] cropIntegrationIds);
    Task<ModifyGoalsPlanningViewModel> ReturnStatusGoalsPlanningAsync(string returnUserCWID, string reason, List<Guid> goalsPlanningIntegrationIds);
    Task<ModifyGoalsPlanningViewModel> ApproveGoalsPlanningAsync(string returnUserCWID, List<Guid> goalsPlanningIntegrationIds);
    Task<ModifyGoalsPlanningViewModel> ReproveGoalsPlanningAsync(string returnUserCWID, string reason, List<Guid> goalsPlanningIntegrationIds);
}

