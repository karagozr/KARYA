using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Construction.Report
{
    public class ActivityReportDetailDto
    {
		public DateTime ProccessDate { get; set; }
		public string GroupCode { get; set; }
		public string GroupName { get; set; }
		public string SubGroupCode { get; set; }
		public string SubGroupName { get; set; }
		public string MainCode { get; set; }
		public string MainName { get; set; }
		public string RecordCode { get; set; }
		public string Description { get; set; }
		public double Quantity { get; set; }
		public double UnitPrice { get; set; }
		public double Amount { get; set; }
		public double ExchangeRate { get; set; }
		public string UpdateUser { get; set; }
		public string CurrentAccountCode { get; set; }
		public string CurrentAccountName { get; set; }
	}
}
