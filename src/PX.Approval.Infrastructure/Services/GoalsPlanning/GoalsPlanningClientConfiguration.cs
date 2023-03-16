using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Approval.Infrastructure.Services.GoalsPlanning
{
    public class GoalsPlanningClientConfiguration
    {

        public const string GoalsPlanningOptions = "GoalsPlanningClientOptions";

        public string GrpcUrl { get; set; } = string.Empty;
        public string ReturnStatusGoalsPlanningUrl { get; set; } = string.Empty;

    }
}
