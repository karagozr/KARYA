using KARYA.CORE.Entities.Abstarct;
using KARYA.CORE.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHIZA.MODEL.Entities
{
    public class Belge : BaseEntity, ILogEntity
    {
        public int DizaynId { get; set; }

        [Required, StringLength(100)]
        public string Adi { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        [StringLength(500)]
        public string Not1 { get; set; }

        [StringLength(500)]
        public string Not2 { get; set; }

        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }
        public IEnumerable<BelgeDetay> BelgeDetays { get; set; }
        public Dizayn Dizayn { get; set; }
    }
 
}