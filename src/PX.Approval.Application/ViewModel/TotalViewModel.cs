using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Approval.Application.ViewModel
{
    public class TotalViewModel
    {
        public int Id { get; set; }
        public Guid CropIntegrationId { get; set; }
        public double FirstPeriod { get; set; }
        public double SecondPeriod { get; set; }
        public double Sellout { get; set; }
        public double Price { get; set; }
        public double Quimio { get; set; }
        public double Seeds { get; set; }
    }
}
