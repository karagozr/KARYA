using System;
using System.Collections.Generic;
using System.Text;

namespace HANEL.MODEL.Dtos.Finance.PL
{
    public class PlReportDto
    {
		public string OrderCode { get; set; }
		public bool	IsExpanded { get; set; }
		public string ColorCode { get; set; }
		public string Id { get; set; }
		public string ParentId { get; set; }
		public string Descript { get; set; }
		public string ProjectCode { get; set; }
		public string ProjectName { get; set; }
		public string BranchCode { get; set; }
		public string BranchName { get; set; }
		public string IntegrationCode { get; set; }
		public double Actual { get; set; }
		public double TotalActual { get; set; }
		public double LastYearActual { get; set; }
		public double LastYearTotalActual { get; set; }
		public double Budget { get; set; }
		public double TotalBudget { get; set; }
	}
}
