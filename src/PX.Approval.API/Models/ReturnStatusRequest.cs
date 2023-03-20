namespace PX.Approval.API.Models
{
    public class ReturnStatusRequest
    {
        public string Reason { get; set; }
        public Guid[] GoalsPlanningIntegrationIds { get; set; }
    }
}
