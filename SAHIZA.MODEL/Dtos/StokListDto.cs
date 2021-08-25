using KARYA.MODEL.Entities.SahizaWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHIZA.MODEL.Dtos
{
    public class StokListDto:Stok
    {
        public string StokDurumAdi { get; set; }
    }
}
