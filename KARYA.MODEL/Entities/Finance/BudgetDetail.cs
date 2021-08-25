using KARYA.MODEL.Entities.Base.Abstarct;
using KARYA.MODEL.Entities.Base.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KARYA.MODEL.Entities.Finance
{
    public class BudgetDetail : BaseEntityEnable, ILogEntity
    {
        [Required]
        public int BudgetId { get; set; }

        [Required]
        public DateTime PeriodDate { get; set; }

        [Required]
        public short BudgetYear { get; set; }

        [Required]
        public short BudgetMonth { get; set; }

        [StringLength(10), Required]
        public string CurrencyCode { get; set; }

        [Required]
        public decimal Amount { get; set; } = 0;

        [StringLength(10)]
        public string UnitCode { get; set; }

        public double Quantity { get; set; } = 0;

        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }

        public Budget Budget { get; set; }
    }
}
