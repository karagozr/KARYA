using KARYA.CORE.Entities.Abstarct;
using KARYA.CORE.Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HANEL.MODEL.Entities.Finance
{
    public class PivotReportTemplate : BaseEntityEnable, ILogEntity
    {
        [StringLength(100), Required]
        public string ReportName { get; set; }

        [Required]
        public string JsonData { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }

    }
}
