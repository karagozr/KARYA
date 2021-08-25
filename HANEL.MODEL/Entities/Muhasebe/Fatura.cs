using KARYA.CORE.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HANEL.MODEL.Entities.Muhasebe
{
    public class Fatura : BaseEntity
    {
        public int Sira { get; set; }

        public bool TevkifatliFatura { get; set; }

        [StringLength(100), Required]
        public string Guid { get; set; }

        [StringLength(50), Required]
        public string BelgeTipi { get; set; }

        [StringLength(50), Required]
        public string FaturaNo { get; set; }
        public DateTime BelgeTarihi { get; set; }

        [StringLength(50)]
        public string FaturaTarihi { get; set; }

        [StringLength(50)]
        public DateTime GelisTarihi { get; set; }
        public string GonderenAdi { get; set; }
        public string GonderenSoyad { get; set; }

        [StringLength(250)]
        public string GonderenUnvan { get; set; }

        [StringLength(50)]
        public string GonderenTckn { get; set; }

        [StringLength(50)]
        public string GonderenVkn { get; set; }

        [StringLength(100)]
        public string GonderenPosta { get; set; }

        [StringLength(250)]
        public string GonderenIl { get; set; }

        [StringLength(250)]
        public string GonderenIlce { get; set; }

        [StringLength(500)]
        public string GonderenAdres { get; set; }

        [StringLength(250)]
        public string GonderenEPosta { get; set; }

        [StringLength(40)]
        public string GonderenTel { get; set; }

        [StringLength(40)]
        public string GonderenFax { get; set; }

        [StringLength(250)]
        public string AlanUnvan { get; set; }

        [StringLength(11)]
        public string AlanTckn { get; set; }

        [StringLength(10)]
        public string AlanVkn { get; set; }

        [StringLength(50)]
        public string AlanPosta { get; set; }
        public decimal ToplamFiyat { get; set; }
        public decimal ToplamVergi { get; set; }
        public decimal ToplamTutar { get; set; }
        public decimal OdenecekTutar { get; set; }
        public string DefaultNote { get; set; }
        public string UserNotes { get; set; }
        public IEnumerable<FaturaKalem> FaturaKalems { get; set; }
        public IEnumerable<FaturaVergiKalem> FaturaVergiKalems { get; set; }


    }

    public class FaturaKalem : BaseEntity
    {
        public int FaturaId { get; set; }
        public Fatura Fatura { get; set; }

        [Required]
        public string Sira { get; set; }

        [StringLength(250), Required]
        public string Ad { get; set; }

        [StringLength(5)]
        public string ParaBirimi { get; set; }

        [StringLength(10)]
        public string Birim { get; set; }

        [Required]
        public decimal Miktar { get; set; }

        [Required]
        public decimal Fiyat { get; set; }

        [Required]
        public decimal Tutar { get; set; }

        [Required]
        public decimal ToplamVergi { get; set; }

        public IEnumerable<FaturaKalemVergi> FaturaKalemVergis { get; set; }

    }

    public class FaturaKalemVergi : BaseEntity
    {
        public int FaturaKalemId { get; set; }
        public FaturaKalem FaturaKalem { get; set; }

        [StringLength(100)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Kod { get; set; }
        public decimal Matrah { get; set; }
        public decimal Oran { get; set; }
        public decimal VergiTutari { get; set; }

    }

    public class FaturaVergiKalem : BaseEntity
    {
        public int FaturaId { get; set; }
        public Fatura Fatura { get; set; }

        [StringLength(100)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Kod { get; set; }
        public decimal Matrah { get; set; }
        public decimal Oran { get; set; }
        public decimal VergiTutari { get; set; }

    }
}
