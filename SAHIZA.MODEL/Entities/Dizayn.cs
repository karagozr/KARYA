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
    public class Dizayn : BaseEntity, ILogEntity
    {
        [Required, StringLength(10)]
        public string DizaynKodu { get; set; }

        [Required, StringLength(50)]
        public string DizaynAdi { get; set; }

        [Required, StringLength(250)]
        public string Aciklama { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }
        public IEnumerable<DizaynDetay> DizaynDetays { get; set; }

    }
}
