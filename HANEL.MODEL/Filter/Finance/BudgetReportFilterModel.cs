using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Filter.Finance
{
    public class BudgetReportFilterModel
    {
        public int BudgetId { get; set; }
        public string ProjectCode { get; set; }
        public short Year { get; set; }
        public string CurrencyCode { get; set; }
    }
}
