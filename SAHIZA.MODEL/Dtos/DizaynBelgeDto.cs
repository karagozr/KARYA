using SAHIZA.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHIZA.MODEL.Dtos
{
    public class DizaynBelgeDto
    {
        public int DizaynId { get; set; }
        public string DizaynKodu { get; set; }
        public string DizaynAdi { get; set; }
        public string DizaynAciklama { get; set; }
        public int BelgeId { get; set; }
        public string BelgeAdi { get; set; }
        public string BelgeAciklama { get; set; }
        public string Not1 { get; set; }
        public string Not2 { get; set; }

        public List<DizaynBelgeDetayDto> BelgeDetayDtos { get; set; }
        
    }
}

