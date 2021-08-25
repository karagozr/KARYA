using KARYA.CORE.Entities.Abstarct;
using KARYA.CORE.Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;

namespace HANEL.MODEL.Entities.Finance
{
    public class BudgetExchangeRate : BaseEntityEnable, ILogEntity
    {

        [Required]
        public DateTime PeriodDate { get; set; }

        [StringLength(10), Required]
        public string MainCurrencyCode { get; set; }

        [StringLength(10), Required]
        public string CurrencyCode { get; set; }

        [Required]
        public double ExchangeRate { get; set; } = 0;

        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }
    }
}
