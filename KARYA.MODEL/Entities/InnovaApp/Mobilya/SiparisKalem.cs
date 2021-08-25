using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Entities.InnovaApp.Mobilya
{
    public class SiparisKalem
    {
        public string DbName { get; set; }
        public string SubeKodu { get; set; }
        public string SiparisGuidId { get; set; }
        public string KalemGuidId { get; set; }
        public string BelgeNo { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public string CariKodu { get; set; }
        public string FtirSip { get; set; }
        public int Sira { get; set; }
        public string StokKodu { get; set; }
        public decimal Miktar { get; set; }
        public decimal Fiyat { get; set; }
        public string KalemAciklama1 { get; set; }
        public string KalemAciklama2 { get; set; }
        public string KalemAciklama3 { get; set; }
        public string KalemAciklama4 { get; set; }
        public string UstAciklama1 { get; set; }
        public string UstAciklama2 { get; set; }
        public string UstAciklama3 { get; set; }
        public string UstAciklama4 { get; set; }
        public string UstAciklama5 { get; set; }
        public string UstAciklama6 { get; set; }
        public int SiparisRef { get; set; }
        public string SiparisNo { get; set; }
        public int Versiyon { get; set; }
        public string CreateUserName { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateTime { get; set; }
        public int Tip { get; set; }
        public string TipAciklama { get; set; }
    }
}
