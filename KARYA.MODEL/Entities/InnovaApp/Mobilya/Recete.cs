using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Entities.InnovaApp.Mobilya
{
    public class Recete
    {
        public int Id { get; set; }
        public int TempId { get; set; }
        public string GuidId { get; set; }
        public string AnaStokKodu { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string MamulKodu { get; set; }
        public string MamulAdi { get; set; }
        public decimal Miktar { get; set; }
        public int OzellikId { get; set; }
        public string OzellikAciklama { get; set; }
    }
}
