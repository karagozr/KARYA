using KARYA.MODEL.Authorize.Karya;
using KARYA.MODEL.Entities.Base.Abstarct;
using KARYA.MODEL.Entities.Base.Concrete;
using KARYA.MODEL.Enums.SahizaWorld;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KARYA.MODEL.Entities.SahizaWorld
{
    public class Stok : BaseEntity, ILogEntity
    {
        [Required, StringLength(20)]
        public string StokKodu { get; set; }

        [Required, StringLength(200)]
        public string StokAdi { get; set; }

        [Required, StringLength(200)]
        public string Birim { get; set; }

        [Required]
        public StokDurum StokDurum { get; set; }
        
        [StringLength(500)]
        public string Aciklama1 { get; set; }
        
        [StringLength(500)]
        public string Aciklama2 { get; set; }

        [StringLength(500)]
        public string GrupKod1 { get; set; }

        [StringLength(500)]
        public string GrupKod2 { get; set; }

        [StringLength(500)]
        public string RaporKod1 { get; set; }

        [StringLength(500)]
        public string RaporKod2 { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }
    }
}
