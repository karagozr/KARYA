using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Dtos
{
    public class ActualRawData
    {
        public string CariKod { get; set; }
        public string RGrupKod { get; set; }
        public string RGrupAd { get; set; }
        public string RHesapKod { get; set; }
        public string RHesapAd { get; set; }
        public string ProjeKod { get; set; }
        public string ProjeAd { get; set; }
        public string YilAy { get; set; }
        public string ParaBirimi { get; set; }
        public double DovizBakiye { get; set; }
        public double TlBakiye { get; set; }
        public double UsdBakiye { get; set; }
        public double EuroBakiye { get; set; }
        public double Miktar { get; set; }
        public string NakitAkisKod { get; set; }
        public string NakitAkisAd { get; set; }
        public DateTime Tarih { get; set; }
        public string FisNo { get; set; }
        public string MuhasebeHesapKod { get; set; }
        public string MuhasebeHesapAd { get; set; }
        public string Aciklama { get; set; }
        public string Aciklama2 { get; set; }
        public string Aciklama3 { get; set; }
        public string SubeKod { get; set; }
        public string SubeAd { get; set; }
        public double DovizBorc { get; set; }
        public double TlBorc { get; set; }
        public double UsdBorc { get; set; }
        public double EuroBorc { get; set; }
        public double DovizAlacak { get; set; }
        public double TlAlacak { get; set; }
        public double UsdAlacak { get; set; }
        public double EuroAlacak { get; set; }
        public string KayitYapanKullanici { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}
