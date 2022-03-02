using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Finance.Budget
{
    public class BudgetAddDto
    {
        public short Year { get; set; }
        public string ProjectCode { get; set; }
        public string BranchCode { get; set; }
        public string SiteCode { get; set; }
        public string CurrencyCode { get; set; }
        public string Description { get; set; }
        public double BudgetJanuary { get; set; }
        public double BudgetFebruary { get; set; }
        public double BudgetMarch { get; set; }
        public double BudgetApril { get; set; }
        public double BudgetMay { get; set; }
        public double BudgetJune { get; set; }
        public double BudgetJuly { get; set; }
        public double BudgetAugust { get; set; }
        public double BudgetSeptember { get; set; }
        public double BudgetOctober { get; set; }
        public double BudgetNovember { get; set; }
        public double BudgetDecember { get; set; }
        public string BudgetCode { get; set; }
    }
}
