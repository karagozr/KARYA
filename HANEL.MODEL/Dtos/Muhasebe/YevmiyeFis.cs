using KARYA.CORE.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dto.Muhasebe
{
    public class YevmiyeFisDto
    {
        public int Id { get; set; }
        public string EntegreKey { get; set; }
        public string HesapKodu { get; set; }
        public string HesapAdi { get; set; }
        public string Aciklama { get; set; }
        public double Borc { get; set; }
        public double Alacak { get; set; }
        public string ProjeKodu { get; set; }
        public string ProjeAdi { get; set; }
        public string ReferansKodu { get; set; }
        public string ReferansAdi { get; set; }
        public string Aciklama2 { get; set; }
        public string Aciklama3 { get; set; }
    }
}
