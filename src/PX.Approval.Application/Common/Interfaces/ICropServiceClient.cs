using PX.Approval.Application.ViewModel;

namespace PX.Approval.Application.Common.Interfaces
{
    public interface ICropServiceClient
    {
        Task<IEnumerable<GetAllActiveCropsViewModel>> GetAllActiveCrops();
    }
}
