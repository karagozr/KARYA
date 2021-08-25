using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Dtos
{
    public class CariReportSubGroup
    {
        public string CariKod { get; set; }
        public string ProjeKod { get; set; }
        public string ProjeAd { get; set; }
        public string RaporGrupAd { get; set; }
        public string RaporHesapKod { get; set; }
        public string RaporHesapAd { get; set; }
        public string ParaBirim { get; set; }
        public double DovizBorc { get; set; }
        public double DovizAlacak { get; set; }
        public double DovizBakiye { get; set; }
    }
}
