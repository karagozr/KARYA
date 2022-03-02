using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Finance.CashFlow
{
    public class CashFlowDetailDto
    {
        public DateTime Tarih { get; set; }
        public string ProjeKodu { get; set; }
        public string ProjeAdi { get; set; }
        public string HesapKodu { get; set; }
        public string HesapAdi { get; set; }
        public string FisNo { get; set; }
        public string Aciklama { get; set; }
        public string CariKodu { get; set; }
        public string CariAdi { get; set; }
        public Decimal Tutar { get; set; }
        public string Kullanici { get; set; }

    }
}
