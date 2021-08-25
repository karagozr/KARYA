using KARYA.CORE.Entities.Abstarct;
using KARYA.CORE.Entities.Concrete;
using SAHIZA.MODEL.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SAHIZA.MODEL.Entities
{
    public class Servis : BaseEntity, ILogEntity
    {
        [Required]
        public ServisIslemTur ServisIslemTur { get; set; }

        [Required]
        public ServisDurum ServisDurum { get; set; }
        public int? StokHaraketId { get; set; }

        public int? StokId { get; set; }

        [Required, StringLength(200)]
        public string UrunBilgisi { get; set; }
        public int? CariId { get; set; }

        [Required, StringLength(200)]
        public string MusteriBilgisi { get; set; }

        [StringLength(300)]
        public string MusteriAdres { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }
        
        [StringLength(500)]
        public string Not1 { get; set; }

        [StringLength(500)]
        public string Not2 { get; set; }

        [StringLength(50)]
        public string Tel1 { get; set; }

        public double ToplamFiyat { get; set; }
        public double VergiOrani { get; set; }
        public double ToplamTutar { get; set; }

        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }
        public StokHaraket StokHaraket { get; set; }
        public Stok Stok { get; set; }
        public Cari Cari { get; set; }
    }
}
