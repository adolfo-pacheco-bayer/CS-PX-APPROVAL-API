namespace PX.Approval.Domain.Models
{
    public class GoalsPlanningStatusHistory
    {
        public int GoalsPlanningId { get; set; }
        public int Status { get; set; }
        public DateTime StatusChanged { get; set; }
        public string StaStatusChangedUserCWID { get; set; }
        public string? Reason { get; set; }
        public string IntegrationId { get; set; }
        public string? UrlFile { get; set; }
    }
}
