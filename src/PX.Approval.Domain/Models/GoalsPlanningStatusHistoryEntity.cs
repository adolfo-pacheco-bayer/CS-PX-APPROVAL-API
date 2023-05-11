using PX.Crop.Domain.Enum;

namespace PX.Approval.Domain.Models
{
    public class GoalsPlanningStatusHistory
    {
        public int GoalsPlanningId { get; set; }
        public DateTime StatusChanged { get; set; }
        public string StatusChangedUserCWID { get; set; }
        public string? Reason { get; set; }
        public string IntegrationId { get; set; }
        public string? UrlFile { get; set; }
        public GoalsPlanningStatus Status { get; set; }
        public string? OriginalFileName { get; set; }
    }
}
