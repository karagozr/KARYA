using KARYA.MODEL.Entities.SahizaWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.Dtos.SahizaWorld
{
    public class StokHaraketDto : StokHaraket
    {
        public string CariAdi { get; set; }
        public string StokAdi { get; set; }
        public string Birim { get; set; }
    }
}
