using SAHIZA.MODEL.Entities;
using System.ComponentModel.DataAnnotations;

namespace SAHIZA.MODEL.Dtos
{
    public class StokHaraketDto : StokHaraket
    {
        [Required]
        public string CariAdi { get; set; }

        [Required]
        public string StokAdi { get; set; }

        [Required]
        public string Birim { get; set; }
    }
}
