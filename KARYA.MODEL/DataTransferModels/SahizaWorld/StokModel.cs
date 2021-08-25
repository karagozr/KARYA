using KARYA.MODEL.Enums.SahizaWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.DataTransferModels.SahizaWorld
{
    public class StokModel
    {
        public int Id { get; set; }
        public string StokKodu { get; set; }

        public string StokAdi { get; set; }
        public string Birim { get; set; }

        public StokDurum StokDurum { get; set; }

        public string Aciklama1 { get; set; }

        public string Aciklama2 { get; set; }

        public string GrupKod1 { get; set; }

        public string GrupKod2 { get; set; }

        public string RaporKod1 { get; set; }
    }
}
