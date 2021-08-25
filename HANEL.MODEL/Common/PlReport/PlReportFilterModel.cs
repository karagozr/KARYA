using HANEL.MODEL.Enums;
using System.Collections.Generic;

namespace HANEL.MODEL.Common.PlReport
{
    public class PlReportFilterModel
    {
        public bool Moment { get; set; }

        public PlReportType PlReportType { get; set; }

        public BudgetOrCostType BudgetOrCostType { get; set; }

        public List<string> ProjectCode { get; set; }

        public string BranchCode { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }

        public string SubCode { get; set; }

        public string Currency { get; set; }

    }
}
