using KARYA.MODEL.Entities.Base.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.Entities.HanelApp
{
    public class Fatura:BaseEntity 
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

        [StringLength(11)]
        public string GonderenTckn { get; set; }

        [StringLength(10)]
        public string GonderenVkn { get; set; }

        [StringLength(50)]
        public string GonderenPosta { get; set; }

        [StringLength(50)]
        public string GonderenIl { get; set; }

        [StringLength(50)]
        public string GonderenIlce { get; set; }

        [StringLength(250)]
        public string GonderenAdres { get; set; }

        [StringLength(50)]
        public string GonderenEPosta { get; set; }

        [StringLength(20)]
        public string GonderenTel { get; set; }

        [StringLength(20)]
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

    }

    public class FaturaVergiKalem : BaseEntity
    {
        public int FaturaId { get; set; }
        public Fatura Fatura { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Kod { get; set; }
        public decimal Matrah { get; set; }
        public decimal Oran { get; set; }
        public decimal VergiTutari { get; set; }

    }
}
