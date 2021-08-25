using KARYA.MODEL.Enums.HanelApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KARYA.MODEL.DataTransferModels.HanelApp.Finance
{
    public class BudgetModel
    {
        public int Id { get; set; }
        public BudgetType BudgetType { get; set; }
        public string BudgetMainGroup { get; set; }
        public string BudgetSubGroup { get; set; } 
        public string BudgetMainCode { get; set; }
        public string BudgetSubCode { get; set; }
        public string BudgetCurrencyCode { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string DescriptionDetail { get; set; }
        public string SiteCode { get; set; }
        public string BranchCode { get; set; }
        public string CurrencyCode { get; set; }
        public decimal BudgetOcak { get; set; }
        public decimal BudgetSubat { get; set; }
        public decimal BudgetMart { get; set; }
        public decimal BudgetNisan { get; set; }
        public decimal BudgetMayis { get; set; }
        public decimal BudgetHaziran { get; set; }
        public decimal BudgetTemmuz { get; set; }
        public decimal BudgetAgustos { get; set; }
        public decimal BudgetEylul { get; set; }
        public decimal BudgetEkim { get; set; }
        public decimal BudgetKasim { get; set; }
        public decimal BudgetAralik { get; set; }
        public int BudgetOcakId { get; set; }
        public int BudgetSubatId { get; set; }
        public int BudgetMartId { get; set; }
        public int BudgetNisanId { get; set; }
        public int BudgetMayisId { get; set; }
        public int BudgetHaziranId { get; set; }
        public int BudgetTemmuzId { get; set; }
        public int BudgetAgustosId { get; set; }
        public int BudgetEylulId { get; set; }
        public int BudgetEkimId { get; set; }
        public int BudgetKasimId { get; set; }
        public int BudgetAralikId { get; set; }
    }
}
