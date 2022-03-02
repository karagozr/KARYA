using HANEL.MODEL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Finance.Budget
{
    public class BudgetReportDto: BudgetReportAccessDto
    {
        public int? BudgetId { get; set; }
        public string Name { get; set; }
        public string IntegrationCode { get; set; }
        public string BudgetCode { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string SiteCode { get; set; }
        public string DefaultCurrencyCode { get; set; }
        public string CurrencyCode { get; set; }
        public string Description { get; set; }

        public string DetailCodes { get { return
            DetailIdJanuary.ToString()  + "-" +
            DetailIdFebruary.ToString() + "-" +
            DetailIdMarch.ToString()    + "-" +
            DetailIdApril.ToString()    + "-" +
            DetailIdMay.ToString()      + "-" +
            DetailIdJune.ToString()     + "-" +
            DetailIdJuly.ToString()     + "-" +
            DetailIdAugust.ToString()   + "-" +
            DetailIdSeptember.ToString()+ "-" +
            DetailIdOctober.ToString()  + "-" +
            DetailIdNovember.ToString() + "-" +
            DetailIdDecember.ToString(); } set {
            } }
        public int? DetailIdJanuary { get; set; }
        public int? DetailIdFebruary { get; set; }
        public int? DetailIdMarch { get; set; }
        public int? DetailIdApril { get; set; }
        public int? DetailIdMay { get; set; }
        public int? DetailIdJune { get; set; }
        public int? DetailIdJuly { get; set; }
        public int? DetailIdAugust { get; set; }
        public int? DetailIdSeptember { get; set; }
        public int? DetailIdOctober { get; set; }
        public int? DetailIdNovember { get; set; }
        public int? DetailIdDecember { get; set; }

        

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
    }
}
