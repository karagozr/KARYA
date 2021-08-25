using SAHIZA.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHIZA.MODEL.Dtos
{
    public class ServisListDto
    {
        public int Id { get; set; }
        public ServisDurum ServisDurum { get; set; }
        public ServisIslemTur ServisIslemTur { get; set; }
        public string MusteriBilgisi { get; set; }
        public string UrunBilgisi { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? SonGuncellemeTarihi { get; set; }
        public string DurumAciklama { get; set; }
    }
}
