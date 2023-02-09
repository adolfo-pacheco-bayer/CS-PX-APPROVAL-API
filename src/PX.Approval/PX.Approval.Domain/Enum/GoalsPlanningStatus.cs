using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Crop.Domain.Enum
{
    public enum GoalsPlanningStatus
    {
        New = 1,
        InPreparation = 2,
        InApproval = 3,
        Canceled = 4,
        Approved = 5
    }
}
