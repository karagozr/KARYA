using KARYA.CORE.Entities.Abstarct;
using KARYA.CORE.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.Entities.Karya
{
    public class AppParameter : BaseEntity, ILogEntity
    {
        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(100)]
        public string GroupName { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; } = "";

        [Required]
        public string DataType { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }
    }
}
