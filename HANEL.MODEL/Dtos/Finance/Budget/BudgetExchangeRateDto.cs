using HANEL.MODEL.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Finance.Budget
{
    public class BudgetExchangeRateDto
    {
        public int Id { get; set; }
        public bool Enable { get; set; }
        public DateTime PeriodDate { get; set; }

        public string CurrencyCode { get; set; }

        public double ExchangeRate { get; set; }
    }
}
