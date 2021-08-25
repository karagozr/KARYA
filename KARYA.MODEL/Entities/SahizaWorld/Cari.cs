using KARYA.MODEL.Authorize.Karya;
using KARYA.MODEL.Entities.Base.Abstarct;
using KARYA.MODEL.Entities.Base.Concrete;
using KARYA.MODEL.Enums.SahizaWorld;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KARYA.MODEL.Entities.SahizaWorld
{
    public class Cari : BaseEntity, ILogEntity
    {
        [Required, StringLength(20)]
        public string CariKodu { get; set; }

        [Required, StringLength(200)]
        public string CariAdi { get; set; }

        [Required]
        public CariTip CariTip { get; set; }

        [Required, StringLength(30)]
        public string VergiDairesi { get; set; }

        [Required, StringLength(10)]
        public string VergiNo { get; set; }

        [Required, StringLength(11)]
        public string TcNo { get; set; }
        
        [StringLength(500)]
        public string Aciklama1 { get; set; }
        
        [StringLength(500)]
        public string Aciklama2 { get; set; }

        [StringLength(100)]
        public string Il { get; set; }

        [StringLength(100)]
        public string Ilce { get; set; }

        [StringLength(500)]
        public string Adres { get; set; }

        [StringLength(50)]
        public string Eposta { get; set; }

        [StringLength(50)]
        public string Tel1 { get; set; }

        [StringLength(50)]
        public string Tel2 { get; set; }

        [StringLength(50)]
        public string GrupKod1 { get; set; }

        [StringLength(50)]
        public string GrupKod2 { get; set; }

        [StringLength(50)]
        public string RaporKod1 { get; set; }

        [StringLength(50)]
        public string RaporKod2 { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }
    }
}
