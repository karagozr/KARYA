using KARYA.CORE.Entities;
using KARYA.CORE.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dto.Muhasebe
{
    public class CariDto 
    {
        public string CariKodu { get; set; }
        public string CariUnvan { get; set; }
        public string Vkn { get; set; }
        public string Tckn { get; set; }
        public string VergiDairesi { get; set; }
    }
}
