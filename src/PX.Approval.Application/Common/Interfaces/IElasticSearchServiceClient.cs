using PX.Approval.Domain.Models;

namespace PX.Approval.Application.Common.Interfaces
{
    public interface IElasticSearchServiceClient
    {
        Task<List<PlanningElasticViewModel>> Get(Guid cropIntegrationId);
    }
}
