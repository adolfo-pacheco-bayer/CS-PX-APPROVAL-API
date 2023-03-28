using PX.Approval.Application.ViewModel;

namespace PX.Approval.Application.Common.Interfaces;

public interface IGoalsPlanningClient
{
    Task<IEnumerable<GetAllGoalsPlanningViewModel>> GetAllGoalsPlanningByCropIntegrationsIdAsync(Guid[] cropIntegrationIds);
    Task<ReturnStatusViewModel> ReturnStatusGoalsPlanningAsync(string returnUserCWID, string reason, List<Guid> goalsPlanningIntegrationIds);
    Task<GetInApprovalGoalsPlanningViewModel> GetInApprovalGoalsPlanning(Guid[] cropIntegrationIds);

}

