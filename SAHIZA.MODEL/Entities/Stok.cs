
using KARYA.CORE.Entities.Abstarct;
using KARYA.CORE.Entities.Concrete;
using SAHIZA.MODEL.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SAHIZA.MODEL.Entities
{
    public class Stok : BaseEntity, ILogEntity
    {
        [Required, StringLength(20)]
        public string StokKodu { get; set; }

        [Required, StringLength(200)]
        public string StokAdi { get; set; }

        [Required, StringLength(200)]
        public string Birim { get; set; }

        [Required]
        public StokDurum StokDurum { get; set; }
        
        [StringLength(500)]
        public string Aciklama1 { get; set; }
        
        [StringLength(500)]
        public string Aciklama2 { get; set; }

        [StringLength(500)]
        public string GrupKod1 { get; set; }

        [StringLength(500)]
        public string GrupKod2 { get; set; }

        [StringLength(500)]
        public string RaporKod1 { get; set; }

        public int GarantiSuresiAy { get; set; }

        public ParaBirimi SatisParaBirimi { get; set; }

        public double SatisFiyati { get; set; }

        public double VergiOrani { get; set; }

        [StringLength(500)]
        public string RaporKod2 { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }
    }
}
