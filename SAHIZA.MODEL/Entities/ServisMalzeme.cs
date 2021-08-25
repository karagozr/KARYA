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
    public class ServisMalzeme : BaseEntity, ILogEntity
    {
        public int ServisId { get; set; }
        public int? StokId { get; set; }

        [Required(ErrorMessage ="Malzeme adı boş geçilmez!")]
        public string MalzemeAdi { get; set; }
        public string Birim { get; set; }
        public double Miktar { get; set; }
        public double Fiyat { get; set; }
        public double VergiOrani { get; set; }
        public double Tutar { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }
        public Servis Servis { get; set; }
        public Stok Stok { get; set; }
    }
}
