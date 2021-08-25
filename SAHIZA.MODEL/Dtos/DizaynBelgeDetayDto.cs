using SAHIZA.MODEL.Entities;
using SAHIZA.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHIZA.MODEL.Dtos
{
    public class DizaynBelgeDetayDto
    {
        public int BelgeDetayId { get; set; }
        public int BelgeId { get; set; }

        public int? DizaynDetayId { get; set; }
        public int Sira { get; set; }

        public string Baslik { get; set; }

        public DataTypes DataTipi { get; set; }

        public string Text { get; set; }

        public int Number { get; set; }

        public string Deger { get; set; }

        public double DecimalNumber { get; set; }

        public DateTime DateTime { get; set; }

        public bool Bool { get; set; }
        public string Not1 { get; set; }

    }
}



