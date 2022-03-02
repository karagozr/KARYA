using KARYA.CORE.Entities.Abstarct;
using KARYA.CORE.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Entities.Finance
{
    public class ReportCode : BaseEntityEnable, ILogEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get => base.Id; set => base.Id = value; }
        
        [Required]
        public int ParentId { get; set; }

        [Required, StringLength(250)]
        public string OrderCode { get; set; }

        [Required, StringLength(250)]
        public string Name { get; set; }

        [Required]
        public bool IsReportCode { get; set; }

        [StringLength(100)]
        public string IntegrationCode1 { get; set; }

        [StringLength(100)]
        public string IntegrationCode2 { get; set; }

        [StringLength(100)]
        public string IntegrationCode3 { get; set; }

        [StringLength(20)]
        public string ColorCode { get; set; }

        [Required]
        public bool IsExpanded { get; set; }

        public DateTime? CreatedTime {get; set;}
        public DateTime? UpdatedTime {get; set;}
        public int? CreatedUserId {get; set;}
        public int? UpdatedUserId {get; set;}
    }
}
