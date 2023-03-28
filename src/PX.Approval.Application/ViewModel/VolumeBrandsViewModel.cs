using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Approval.Application.ViewModel
{
    public class VolumeBrandsViewModel
    {
        public Guid BrandGoalsPlanningIntegrationId { get; set; }

        /// <summary>
        /// As  Marca
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// As Escoamento KG/L/Sc
        /// </summary>
        public decimal Sellout { get; set; }

        /// <summary>
        /// As 1º Período KG/L/Sc
        /// </summary>
        public decimal? FirstSellinPeriod { get; set; }

        /// <summary>
        /// As 2º Período KG/L/Sc
        /// </summary>
        public decimal? SecondSellinPeriod { get; set; }

        /// <summary>
        /// As Total de Compras KG/L/Sc
        /// When FirstSellinPeriod is null, total will be: TotalSellin = null + SecondSellinPeriod
        /// </summary>
        public decimal TotalSellin { get; set; }
    }
}
