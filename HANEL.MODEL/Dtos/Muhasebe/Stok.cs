using KARYA.CORE.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dto.Muhasebe
{
    public class StokDto
    {
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string GrupKodu { get; set; }
        public string Kod1 { get; set; }
        public string Kod2 { get; set; }
        public string AlisHesapKodu { get; set; }
        public string AlisHesapAdi { get; set; }
        public string SatisHesapKodu { get; set; }
        public string SatisHesapAdi { get; set; }
        public double KdvOrani { get; set; }
        public string SubeKodu { get; set; }
    }
}
