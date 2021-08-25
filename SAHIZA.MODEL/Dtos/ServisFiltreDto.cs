using SAHIZA.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHIZA.MODEL.Dtos
{
    public class ServisFiltreDto
    {
        public DateTime Tarih1 { get; set; }
        public DateTime Tarih2 { get; set; }
        public StokDurum StokDurum { get; set; }
        public string Cari { get; set; }
        public GarantiDurum GarantiDurum { get; set; }
        public string Stok { get; set; }
    }
}
