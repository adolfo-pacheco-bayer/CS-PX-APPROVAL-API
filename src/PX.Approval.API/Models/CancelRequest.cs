namespace PX.Approval.API.Models
{
    public class CancelRequest
    {
        public string Reason { get; set; }
        public Guid[] GoalsPlanningIntegrationIds { get; set; }
    }
}
