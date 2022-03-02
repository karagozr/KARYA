using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Finance.Aging
{
    public class AgingReportDto
    {
        public string CariKodu { get; set; }
        public string CariAdi { get; set; }
        public string CariTipi { get; set; }
        public decimal TotalBorc { get; set; }
        public string Sektor { get; set; }
        public string ProjeKodu { get; set; }
        public string ProjeAdi { get; set; }
        public string SubeKodu { get; set; }
        public string SubeAdi { get; set; }
        public decimal TotalAlacak { get; set; }
        public decimal Bakiye { get; set; }
        public decimal LastBakiye4 { get; set; }
        public decimal LastBakiye3 { get; set; }
        public decimal LastBakiye2 { get; set; }
        public decimal LastBakiye1 { get; set; }
        public decimal NextBakiye1 { get; set; }
        public decimal NextBakiye2 { get; set; }
        public decimal NextBakiye3 { get; set; }
        public decimal NextBakiye4 { get; set; }

    }
}
