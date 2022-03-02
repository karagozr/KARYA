using HANEL.MODEL.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Finance.Budget
{
    public class BudgetExchangeRateMonthlyDto
    {
        public string CurrencyCode { get; set; }
        public double RateJanuary { get; set; }
        public double RateFebruary { get; set; }
        public double RateMarch { get; set; }
        public double RateApril { get; set; }
        public double RateMay { get; set; }
        public double RateJune { get; set; }
        public double RateJuly { get; set; }
        public double RateAugust { get; set; }
        public double RateSeptember { get; set; }
        public double RateOctober { get; set; }
        public double RateNovember { get; set; }
        public double RateDecember { get; set; }
    }
}
