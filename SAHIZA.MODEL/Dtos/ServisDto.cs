using SAHIZA.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHIZA.MODEL.Dtos
{
    public class ServisDto : Servis
    {
        public string StokAdi { get; set; }
        public string CariAdi { get; set; }
    }
}
