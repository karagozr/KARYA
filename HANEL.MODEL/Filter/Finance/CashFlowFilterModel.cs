using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Filter.Finance
{
    public class CashFlowFilterModel
    {
        public string CurrencyCode { get; set; }

        public string RefCode { get; set; }

        public short Month { get; set; }

        public string SectorName { get; set; }

        public string ReportCode { get; set; }

        public short Year { get; set; }

        public DateTime Date1 { get; set; }

        public DateTime Date2 { get; set; }
    }
}
