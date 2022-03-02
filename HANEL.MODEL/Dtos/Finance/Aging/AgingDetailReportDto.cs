using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Finance.Aging
{
    public class AgingDetailReportDto
    {
        
        public string BelgeNo { get; set; }
        public string IslemTipi { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime VadeTarih { get; set; }
        public int VadeGun { get; set; }
        public int VadeFark { get; set; }
        public decimal Borc { get; set; }
        public decimal Alacak { get; set; }
        public decimal Bakiye { get; set; }
        public decimal AlacakKapama { get; set; }
        public decimal BorcKapama { get; set; }
        public string SubeKodu { get; set; }
        public string SubeAdi { get; set; }
        public string ProjeKodu { get; set; }
        public string ProjeAdi { get; set; }
        public int IncKey { get; set; }

    }
}
