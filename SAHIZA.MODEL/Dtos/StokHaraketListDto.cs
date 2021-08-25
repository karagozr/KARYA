using SAHIZA.MODEL.Entities;

namespace SAHIZA.MODEL.Dtos
{
    public class StokHaraketListDto : StokHaraket
    {
        public string CariAdi { get; set; }
        public string StokAdi { get; set; }
        public string Birim { get; set; }
    }
}
