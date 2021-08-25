using KARYA.MODEL.Entities.Base.Abstarct;
using KARYA.MODEL.Entities.Base.Concrete;
using KARYA.MODEL.Enums.HanelApp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KARYA.MODEL.Entities.Finance
{
    public class Budget : BaseEntityEnable, ILogEntity
    {
        [Required]
        public BudgetType BudgetType { get; set; }

        [StringLength(20),Required]
        public string BranchCode { get; set; }

        [StringLength(20), Required]
        public string ProjectCode { get; set; }

        [Column(Order = 5), StringLength(20)]
        public string SiteCode { get; set; }

        [StringLength(20), Required]
        public string BudgetMainCode { get; set; }

        [StringLength(20), Required]
        public string BudgetSubCode { get; set; }

        [Required]
        public short BudgetYear { get; set; }
        [Required]
        public double BudgetTaxMultiplier { get; set; } = 1;
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string DescriptionDetail { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }

        //public IEnumerable<Budget> BudgetDetails { get; set; }
    }
}
