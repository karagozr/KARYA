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

        public string Guid { get; set; }

        public string BelgeTipi { get; set; }

        public string FaturaNo { get; set; }

        public string AboneNo { get; set; }
        public DateTime BelgeTarihi { get; set; }

        public string FaturaTarihi { get; set; }

        public DateTime GelisTarihi { get; set; }
        public string GonderenAdi { get; set; }
        public string GonderenSoyad { get; set; }

        public string GonderenUnvan { get; set; }

        public string GonderenTckn { get; set; }

        public string GonderenVkn { get; set; }

        public string GonderenPosta { get; set; }

        public string GonderenIl { get; set; }

        public string GonderenIlce { get; set; }

        public string GonderenAdres { get; set; }

        public string GonderenEPosta { get; set; }

        public string GonderenTel { get; set; }

        public string GonderenFax { get; set; }

        public string AlanUnvan { get; set; }

        public string AlanTckn { get; set; }

        public string AlanVkn { get; set; }

        public string AlanPosta { get; set; }
        public decimal ToplamFiyat { get; set; }
        public decimal ToplamVergi { get; set; }
        public decimal ToplamTutar { get; set; }
        public decimal OdenecekTutar { get; set; }
        public decimal Mahsup { get; set; }
        public decimal Yuvarlama { get; set; }
        public string DefaultNote { get; set; }
        public string UserNotes { get; set; }
        public int? UpdatetedIndex { get; set; }
        public IEnumerable<FaturaKalem> FaturaKalems { get; set; }
        public IEnumerable<FaturaVergiKalem> FaturaVergiKalems { get; set; }


    }

    public class FaturaKalem : BaseEntity
    {
        public int FaturaId { get; set; }
        public Fatura Fatura { get; set; }

        [Required]
        public string Sira { get; set; }

        [StringLength(1000), Required]
        public string Ad { get; set; }

        [StringLength(10)]
        public string ParaBirimi { get; set; }

        [StringLength(20)]
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

        [StringLength(80)]
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


    public class OtoFatura : BaseEntity
    {
        public bool Aktif { get; set; }
        public string OzelAd { get; set; }
        public string Aciklama { get; set; }
        public string AboneNo { get; set; }
        public string CariKodu { get; set; }
        public string GonderenTckn { get; set; }
        public string GonderenVkn { get; set; }
        public string ProjeKodu { get; set; }
        public string IsletmeKodu { get; set; }
        public string SubeKodu { get; set; }
        public string AlanVkn { get; set; }
        public string RefGuid { get; set; }
        public string Aciklama1 { get; set; }
        public string Aciklama2 { get; set; }
    }

    public class OtoFaturaDetay : BaseEntity
    {
        public int OtoFaturaId { get; set; }
        public string HashKalem { get; set; }
        public string StokKodu { get; set; }
        public string MuhasebeKodu { get; set; }
        public string ReferansKodu { get; set; }
        public double Kdv { get; set; }
        public double Fiyat { get; set; }
        public string ProjeKodu { get; set; }
        public string KalemAciklama { get; set; }
        //public DateTime FaturaTarihi { get; set; }

    }
}
