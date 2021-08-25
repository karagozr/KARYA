using KARYA.MODEL.Entities.Base.Abstarct;
using KARYA.MODEL.Entities.Base.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KARYA.MODEL.Entities.Finance
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
