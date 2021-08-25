using KARYA.MODEL.Entities.Base.Abstarct;
using KARYA.MODEL.Entities.Base.Concrete;
using KARYA.MODEL.Enums.SahizaWorld;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.Entities.SahizaWorld
{
    public class StokHaraket : BaseEntity, ILogEntity
    {
        [Required]
        public int StokId { get; set; }

        [Required]
        public int CariId { get; set; }

        [Required]
        public StokHaraketTur StokHaraketTur { get; set; }

        [Required]
        public double Miktar { get; set; }

        [Required]
        public double Fiyat { get; set; }

        [Required]
        public double KdvOrani { get; set; }

        [Required,StringLength(250)]
        public string Aciklama { get; set; }

        public double Tutar { get; set; }
        public Stok Stok { get; set; }
        public Cari Cari { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }
    }
}
