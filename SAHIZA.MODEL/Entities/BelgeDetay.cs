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
    public class BelgeDetay : BaseEntity
    {
        [Required]
        public int BelgeId { get; set; }

        public int? DizaynDetayId { get; set; }
        
        [StringLength(250)]
        public string Not1 { get; set; }

        public string Text { get; set; }

        public int Number { get; set; }

        public double DecimalNumber { get; set; }

        public DateTime DateTime { get; set; }

        public bool Bool { get; set; }

        public Belge Belge { get; set; }

        public virtual DizaynDetay DizaynDetay { get; set; }

    }
}
