using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Muhasebe
{
    public class FaturaDto
    {
        public int Id { get; set; }
        public bool OtoMod { get; set; }
        public bool Kayitli { get; set; }
        public string Guid { get; set; }
        public string AboneNo { get; set; }
        public string AlanUnvan { get; set; }
        public string DefaultNote { get; set; }
        public string UserNotes { get; set; }
        public string GonderenUnvan { get; set; }
        public string FaturaNo { get; set; }
        public string CariVkn { get; set; }
        public string CariTckn { get; set; }
        public string CariKodu { get; set; }
        public string CariUnvan { get; set; }
        public string Vkn { get; set; }
        public string ProjeKodu { get; set; }
        public string ProjeAdi { get; set; }
        public int SubeKodu { get; set; }
        public string SubeAdi { get; set; }
        public string Aciklama { get; set; }
        public string Aciklama1 { get; set; }
        public string Aciklama2 { get; set; }
        public decimal ToplamFiyat { get; set; }
        public decimal ToplamVergi { get; set; }
        public decimal ToplamTutar { get; set; }
        public decimal OdenecekTutar { get; set; }
        public decimal Yuvarlama { get; set; }
        public DateTime FaturaTarihi{ get; set; }
        public string KayitTarihi { get; set; }
        public string DuzenlemeTarihi { get; set; }
        public bool Guncelleme { get; set; }
        public IEnumerable<FaturaDetayDto> FaturaDetays { get; set; }
        public string Aciklama15 { get; set; }
        public bool ReturnYevmiyeFisi { get; set; }
        public double YuvarlamaTutari { get; set; }
        public bool RetryKdv { get; set; }
        public bool RetryTutar { get; set; }
        public bool OtoAvaible { get; set; }
    }

    public class FaturaDetayDto
    {
        public int Int { get; set; }
        public int FaturaId { get; set; }
        public string Guid { get; set; }
        public string HashKalem { get; set; }
        public string FaturaNo { get; set; }
        public string StokKodu { get; set; }
        public decimal Miktar { get; set; }
        public decimal Fiyat { get; set; }
        public decimal Kdv { get; set; }
        public decimal KdvTutar { get; set; }
        public decimal Tutar { get; set; }
        public string  KalemAciklama { get; set; }
        public string MuhasebeKodu { get; set; }
        public string MuhasebeKoduAciklama { get; set; }
        public string ProjeKodu { get; set; }
        public string ProjeAdi { get; set; }
        public string ReferansKodu { get; set; }
        public string ReferansAdi { get; set; }


    }
}
