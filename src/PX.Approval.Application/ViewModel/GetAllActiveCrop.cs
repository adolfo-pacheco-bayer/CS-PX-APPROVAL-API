namespace PX.Approval.Application.ViewModel
{
    public class GetAllActiveCropsViewModel
    {
        public Guid IntegrationId { get; set; }
        public string Description { get; set; }
        public DateTime EndPeriod { get; set; }
        public DateTime EndPlanningPeriod { get; set; }
        public bool IsGoalPlanningValued { get; set; }
        public string Name { get; set; }
        public DateTime StartPeriod { get; set; }
        public DateTime StartPlanningPeriod { get; set; }
    }
}
