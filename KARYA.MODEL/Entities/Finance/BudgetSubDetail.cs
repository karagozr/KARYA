using KARYA.MODEL.Entities.Base.Abstarct;
using KARYA.MODEL.Entities.Base.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KARYA.MODEL.Entities.Finance
{
    public class BudgetSubDetail : BaseEntity, ILogEntity
    {
        [Required]
        public int BudgetId { get; set; }

        [StringLength(200), Required]
        public string Description { get; set; }

        [Required]
        public decimal Ocak { get; set; } = 0;

        [Required]
        public decimal Subat { get; set; } = 0;
        [Required]
        public decimal Mart { get; set; } = 0;
        [Required]
        public decimal Nisan { get; set; } = 0;
        [Required]
        public decimal Mayis { get; set; } = 0;
        [Required]
        public decimal Haziran { get; set; } = 0;
        [Required]
        public decimal Temmuz { get; set; } = 0;
        [Required]
        public decimal Agustos { get; set; } = 0;
        [Required]
        public decimal Eylul { get; set; } = 0;
        [Required]
        public decimal Ekim { get; set; } = 0;
        [Required]
        public decimal Kasim { get; set; } = 0;
        [Required]
        public decimal Aralik { get; set; } = 0;

        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }

        public Budget Budget { get; set; }
    }
}
