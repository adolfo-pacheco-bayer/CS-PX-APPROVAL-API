using PX.Approval.Application.ViewModel;

namespace PX.Approval.Application.Common.Interfaces;

public interface IGoalsPlanningClient
{
    Task<IEnumerable<GetAllGoalsPlanningViewModel>> GetAllGoalsPlanningByCropIntegrationsIdAsync(Guid[] cropIntegrationIds);    
}

