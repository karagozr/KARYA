
using KARYA.CORE.Entities.Abstarct;
using KARYA.CORE.Entities.Concrete;
using SAHIZA.MODEL.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SAHIZA.MODEL.Entities
{
    public class StokHaraket : BaseEntity, ILogEntity
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Stok seçmelisiniz !")]
        public int StokId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Cari seçmelisiniz !")]
        public int CariId { get; set; }

        [Required]
        public StokHaraketTur StokHaraketTur { get; set; }

        public ParaBirimi ParaBirimi { get; set; } = ParaBirimi.TL;

        [Required]
        [Range(0.0000001, double.MaxValue, ErrorMessage = "Miktar sıfırdan (0) büyük olmalı !")]
        public double Miktar { get; set; }

        [Required]
        public double Fiyat { get; set; }

        [Required]
        public double VergiOrani { get; set; }

        [Required(ErrorMessage = "Açıklama giriniz !"),StringLength(250)]
        public string Aciklama { get; set; }

        public double Tutar { get; set; }

        public bool GarantiVar { get; set; } = true;
        public DateTime GarantiBaslangic { get; set; } = DateTime.Now;
        public Stok Stok { get; set; }
        public Cari Cari { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }
    }
}
