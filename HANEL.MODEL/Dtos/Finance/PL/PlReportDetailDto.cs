using System;
using System.Collections.Generic;
using System.Text;

namespace HANEL.MODEL.Dtos.Finance.PL
{
    public class PlReportDetailDto
	{
		public DateTime ProccessDate { get; set; }
		public string RecordCode { get; set; }
		public string ProjectCode { get; set; }
		public string ProjectName { get; set; }
		public string BranchCode { get; set; }
		public string BranchName { get; set; }
		public string IntegrationDesc { get; set; }
		public string IntegrationCode { get; set; }
		public string Description { get; set; }
		public double Amount { get; set; }
		public double ExchangeRate { get; set; }
		public string UpdateUser { get; set; }
	}
}
