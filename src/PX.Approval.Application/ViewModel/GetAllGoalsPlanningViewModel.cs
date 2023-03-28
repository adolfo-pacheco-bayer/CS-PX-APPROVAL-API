using PX.Approval.Domain.Enum;
using PX.Crop.Domain.Enum;

namespace PX.Approval.Application.ViewModel;

public class GetAllGoalsPlanningViewModel
{
    public Guid IntegrationId { get; set; }
    public string PartnerGroupCode { get; set; }
    public GoalsPlanningStatus Status { get; set; }
    public ICollection<StatusHistoryViewModel> StatusHistory { get; set; }
    public ICollection<DocumentApprovalHistory> DocumentApprovalHistory { get; set; }
}

public class StatusHistoryViewModel
{
    public int GoalsPlanningId { get; set; }    
    public DateTime StatusChanged { get; set; }
    public GoalsPlanningStatus Status { get; set; }
    public string StatusChangedUserCWID { get; set; }
    public string? Reason { get; set; }
}

public class DocumentApprovalHistory
{
    public Guid DocumentCropIntegrationId { get; set; }
    public int GoalsPlanningId { get; set; }
    public DocumentAcceptanceStatus Status { get; set; }
    public DateTime StatusChanged { get; set; }
    public string StatusChangedUserCWID { get; set; }
    public string StatusChangedUserName { get; set; }
    public string? StatusChangedUserCPF { get; set; }
    public string? DisapprovedReason { get; set; }
}
