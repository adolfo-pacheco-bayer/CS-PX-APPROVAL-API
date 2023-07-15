namespace PX.Approval.Domain.Models
{
    public class PlanningTotalViewModel
    {
        public Guid CropIntegrationId { get; set; }
        public double FirstPeriodVolume { get; set; }

        public double SecondPeriodVolume { get; set; }

        public double SelloutVolume { get; set; }

        public double FirstPeriodValue { get; set; }

        public double SecondPeriodValue { get; set; }

        public double SelloutValue { get; set; }

        public double Price { get; set; }

        public ProductFamilyType Type { get; set; }

        public double CPTotalVolume { get; set; }

        public double SeedsTotalVolume { get; set; }

        public double CPTotalValue { get; set; }

        public DateTime LastUpdatedAt { get; private set; }
        public PlanningTotalViewModel()
        {
            LastUpdatedAt = System.DateTime.Now.ToUniversalTime();
        }
    }
}
