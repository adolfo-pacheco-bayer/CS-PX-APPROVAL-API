namespace PX.Approval.Application.ViewModel
{
    public  class ValuedBrandsViewModel
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

    public class GetAllValuedCPBrandByGoalsPlanningViewModel
    {
        public bool FirstSellinPeriodRequired { get; set; }
        public decimal? TotalFirstPeriod { get => ValuedBrands.Sum(b => b.FirstSellinPeriod); }
        public decimal? TotalSecondPeriod { get => ValuedBrands.Sum(b => b.SecondSellinPeriod); }
        public decimal TotalSellout { get => ValuedBrands.Sum(b => b.Sellout); }
        public decimal TotalSellin { get => ValuedBrands.Sum(b => b.TotalSellin); }

        public IEnumerable<ValuedBrandsViewModel> ValuedBrands { get; set; }

        public GetAllValuedCPBrandByGoalsPlanningViewModel()
        {
            ValuedBrands = new List<ValuedBrandsViewModel>();
        }
    }

}
