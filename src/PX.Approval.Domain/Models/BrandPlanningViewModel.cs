namespace PX.Approval.Domain.Models
{
    public class BrandPlanningViewModel
    {
        public int GoalsPlanningId { get; set; }
        public Guid BrandCropIntegrationId { get; set; }

        public string Name { get; set; }
        public decimal? Price { get; set; }
        public ProductFamilyType Type { get; set; }

        /// <summary>
        /// Biotechnology. Used only for seeds type
        /// </summary>
        public bool? Bio { get; set; }

        public decimal? FirstSellinPeriod { get; set; }
        public decimal? SecondSellinPeriod { get; set; }
        public decimal Sellout { get; set; }
        public decimal? ClassificationCPMargin { get; set; }
    }
}
