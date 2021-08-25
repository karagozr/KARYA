using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Dtos
{
    public class CariReportSubGroupDetail
    {
        public DateTime Tarih { get; set; }
        public string FisNo { get; set; }
        public string Aciklama { get; set; }
        public string RaporHesapAd { get; set; }
        public string ReferansKod { get; set; }
        public string ReferansAd { get; set; }
        public string ParaBirim { get; set; }
        public double DovizBorc { get; set; }
        public double DovizAlacak { get; set; }
        public double DovizBakiye { get; set; }
        public string Sube { get; set; }
    }
}
