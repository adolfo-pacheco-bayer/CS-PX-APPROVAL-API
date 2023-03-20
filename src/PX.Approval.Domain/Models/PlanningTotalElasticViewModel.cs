namespace PX.Approval.Domain.Models
{
    public class PlanningTotalElasticViewModel
    {
        public Guid CropIntegrationId { get; set; }
        public double FirstPeriod { get; set; }

        public double SecondPeriod { get; set; }

        public double Sellout { get; set; }

        public double Price { get; set; }

        public ProductFamilyType Type { get; set; }

        public double Quimio { get; set; }

        public double Seeds { get; set; }
    }
}
