using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Dtos
{
    public class PlReportDetailForBudgetOrCost
    {
        public int Id { get; set; }
        public DateTime PeriodDate { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string SubCode { get; set; }
        public string SubCodeDesc { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public decimal Quantity { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }
    }
}
