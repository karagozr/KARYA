using KARYA.MODEL.Enums.HanelApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Common.HanelApp.PlReport
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
