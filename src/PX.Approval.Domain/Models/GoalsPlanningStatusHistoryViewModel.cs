using PX.Crop.Domain.Enum;

namespace PX.Approval.Domain.Models
{
    public class GoalsPlanningStatusHistoryViewModel
    {
        public int GoalsPlanningId { get; set; }
        public string Status { get; set; }
        public DateTime StatusChanged { get; set; }
        public string StatusChangedUserCWID { get; set; }
        public string? Reason { get; set; }
        public string IntegrationId { get; set; }
        public string? UrlFile { get; set; }        
    }
}
