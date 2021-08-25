using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Dtos.Hanel.Finance.Budget
{
    public class BudgetWithMonthsDto : Entities.Finance.Budget
    {
        public string ForeingId 
        { 
            get 
            {
                return BudgetSubCode + "-" + (BudgetType!=Enums.HanelApp.BudgetType.IncomeBudget?"0": (BranchCode==null?"0":BranchCode) + "-" + SiteCode);
            }
            set { } 
        } 
        public string BudgetMainCodeDesc { get; set; }

        public string BudgetSubCodeDesc { get; set; }

        public decimal Ocak       {get;set;}
        public decimal Subat      {get;set;}
        public decimal Mart       {get;set;}
        public decimal Nisan      {get;set;}
        public decimal Mayis      {get;set;}
        public decimal Haziran    {get;set;}
        public decimal Temmuz     {get;set;}
        public decimal Agustos    {get;set;}
        public decimal Eylul      {get;set;}
        public decimal Ekim       {get;set;}
        public decimal Kasim      {get;set;}
        public decimal Aralik     {get;set;}
        public int OcakId     {get;set;}
        public int SubatId    {get;set;}
        public int MartId     {get;set;}
        public int NisanId    {get;set;}
        public int MayisId    {get;set;}
        public int HaziranId  {get;set;}
        public int TemmuzId   {get;set;}
        public int AgustosId  {get;set;}
        public int EylulId    {get;set;}
        public int EkimId     {get;set;}
        public int KasimId    {get;set;}
        public int AralikId { get; set; }
    }
}
