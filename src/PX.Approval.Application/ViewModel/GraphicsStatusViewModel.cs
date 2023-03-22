namespace PX.Approval.Application.ViewModel
{
    public class GraphicsStatusViewModel
    {
        public double InApproval { get; set; }

        public double New { get; set; }

        public double InPreparation { get; set; }

        public double Approved { get; set; }

        public double Canceled { get; set; }

        public  int GoalsPlanningTotal { get; set; }
    }
}
