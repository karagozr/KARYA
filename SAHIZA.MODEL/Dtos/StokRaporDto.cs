using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHIZA.MODEL.Dtos
{
    public class StokRaporDto
    {
        public int StokId { get; set; }
        public string StokAdi { get; set; }
        public string Birim { get; set; }
        public double Miktar { get; set; }
        public double UyariKota { get; set; }
    }
}
