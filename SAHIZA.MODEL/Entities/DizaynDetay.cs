using KARYA.CORE.Entities.Abstarct;
using KARYA.CORE.Entities.Concrete;
using SAHIZA.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHIZA.MODEL.Entities
{
    public class DizaynDetay : BaseEntity
    {
        [Required]
        public int DizaynId { get; set; }

        [Required]
        public int Sira { get; set; }

        [Required, StringLength(500)]
        public string Baslik { get; set; }

        [Required]
        public DataTypes DataTipi { get; set; }

        public string Deger { get; set; }

        public Dizayn Dizayn { get; set; }

        public virtual IEnumerable<BelgeDetay> BelgeDetays { get; set; }
    }
}
