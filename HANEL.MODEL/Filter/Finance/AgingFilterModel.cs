using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Filter.Finance
{
    public class AgingFilterModel
    {
        public short Year { get; set; }
        public int RangeDay { get; set; }
        public string CariTip { get; set; }
        public string Sector { get; set; }
        public string CurrencyCode { get; set; }
        public string CariKodu { get; set; }
    }
}
