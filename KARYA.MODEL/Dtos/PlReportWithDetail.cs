using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Dtos
{
    public class PlReportWithDetail
    {
        public int Id { get; set; }
        public string ParentId { get; set; }
        public string RootId { get; set; }
        public bool IsExpanded { get; set; }
        public string MainGroup { get; set; }
        public string SubGroup { get; set; }
        public string MainCode { get; set; }
        public string MainCodeDesc { get; set; }
        public string SubCode { get; set; }
        public string SubCode2 { get; set; }
        public string SubCodeDesc { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public double MonthBudget { get; set; }
        public double ActualCost { get; set; }
        public double Differance { get; set; }
        public double Rate { get; set; }
        public double TotalBudget { get; set; }
        public double TotalActualCost { get; set; }
        public double TotalDifferance { get; set; }
        public double TotalRate { get; set; }
        public double LastActualCost { get; set; }
        public double TotalLastActualCost { get; set; }
    }
}
