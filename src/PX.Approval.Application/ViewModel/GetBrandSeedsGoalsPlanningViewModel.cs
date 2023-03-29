namespace PX.Approval.Application.ViewModel
{
    public class GetBrandSeedsGoalsPlanningViewModel
    {
        public Guid BrandGoalsPlanningIntegrationId { get; set; }
        public string Name { get; set; }
        public int Sellout { get; set; }
        public int? Bio { get; set; }
        public int? WithoutBio { get; set; }
    }
}
