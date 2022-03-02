using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.API.REST.Models.CashFlow
{
    public class CashFlowListFilter
    {
        public string SectorName { get; set; }
        public string CurrencyCode { get; set; }
        public short Year { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
    }
    public class CashFlowDetailFilter
    {
        public string SectorName { get; set; }
        public string CurrencyCode { get; set; }

        public string RefCode { get; set; }

        public short Month { get; set; }
        public short Year { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }

    }
}
