namespace PX.Approval.API.Models
{
    public class ReproveRequest
    {
        public string Reason { get; set; }
        public IFormFile? File { get; set; }
        public Guid[] GoalsPlanningIntegrationIds { get; set; }
    }
}
