using Newtonsoft.Json.Converters;
using PX.Crop.Domain.Enum;
using System.Text.Json.Serialization;

namespace PX.Approval.Domain.Models
{
    public class PlanningElasticViewModel
    {
        public int Id { get; set; }
        public string GoalsPlanningIntegrationId { get; set; }
        public string PartnerName { get; set; }
        public string RtvName { get; set; }
        public List<string> Classifications { get; set; }
        public decimal Total { get; set; }
        public decimal SelloutCp { get; set; }
        public decimal SelloutSeeds { get; set; }

        public string Status { get; set; }
        public string Details { get; set; }
        public bool IsGoalPlanningValued { get; set; }
        public List<BrandPlanningViewModel> Brands { get; set; }

        public string PartnerType { get; set; }

        public string CropIntegrationId { get; set; }

        public DateTime LastUpdate { get; set; }

        public string EmailGoalsPlanning { get; set; }
        public string CWIDCPApprover { get; set; }
        public string CWIDSeedsApprover { get; set; }
    }
}
