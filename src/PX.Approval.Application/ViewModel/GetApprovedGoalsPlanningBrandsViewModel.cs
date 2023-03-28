using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Approval.Application.ViewModel
{
    public class GetInApprovalGoalsPlanningBrandsViewModel
    {
        public Guid BrandCropIntegrationId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Type { get; set; }
        public bool? Bio { get; set; }
        public decimal? FirstSellinPeriod { get; set; }
        public decimal? SecondSellinPeriod { get; set; }
        public decimal Sellout { get; set; }
        public decimal? ClassificationCPMargin { get; set; }
    }
}
