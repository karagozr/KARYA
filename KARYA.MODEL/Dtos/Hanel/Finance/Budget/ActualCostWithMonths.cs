using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Dtos.Hanel.Finance.Budget
{
    public class ActualCostWithMonths
    {
        public string ForeingId { get {
                return BudgetSubCode + "-" + BranchCode+(SiteCode!=null?("-"+SiteCode):"");
            } set { } } 
        public string BudgetMainGroup { get; set; } = "";
        public string BudgetSubGroup { get; set; } = "";
        public string BudgetMainCode { get; set; } = "";
        public string BudgetMainCodeDesc { get; set; } = "";
        public string BudgetSubCode { get; set; } = "";
        public string BudgetSubCodeDesc { get; set; } = "";
        public string ProjectCode { get; set; } = "";
        public string BranchCode { get; set; } = "0";
        public string BranchName { get; set; } = "";
        public string SiteCode { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Ocak { get; set; }
        public int OcakId { get; set; }
        public decimal Subat { get; set; }
        public int SubatId { get; set; }
        public decimal Mart { get; set; }
        public int MartId { get; set; }
        public decimal Nisan { get; set; }
        public int NisanId { get; set; }
        public decimal Mayis { get; set; }
        public int MayisId { get; set; }
        public decimal Haziran { get; set; }
        public int HaziranId { get; set; }
        public decimal Temmuz { get; set; }
        public int TemmuzId { get; set; }
        public decimal Agustos { get; set; }
        public int AgustosId { get; set; }
        public decimal Eylul { get; set; }
        public int EylulId { get; set; }
        public decimal Ekim { get; set; }
        public int EkimId { get; set; }
        public decimal Kasim { get; set; }
        public int KasimId { get; set; }
        public decimal Aralik { get; set; }
        public int AralikId { get; set; }
    }
}
