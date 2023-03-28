﻿using PX.Crop.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Approval.Application.ViewModel
{
    public class GetInApprovalGoalsPlanningViewModel
    {
        public Guid IntegrationId { get; set; }
        public Guid CropIntegrationId { get; set; }
        public string PartnerGroupCode { get; set; }
        public string Status { get; set; }
        public IEnumerable<GetInApprovalGoalsPlanningBrandsViewModel> Brands { get; set; }
    }
}