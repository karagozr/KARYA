//using KARYA.MODEL.Enums.SahizaWorld;
using SAHIZA.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHIZA.MODEL.Dtos
{
    public class StokFilterDto
    {
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public StokDurum StokDurum { get; set; }
        public string Birim { get; set; }
    }
}
