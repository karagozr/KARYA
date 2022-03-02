using KARYA.CORE.Entities.Abstarct;
using KARYA.CORE.Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HANEL.MODEL.Entities
{
    public class Company : BaseEntityEnableCode
    {
        [StringLength(200),Required]
        public string Name { get; set; }

        [StringLength(11), Required]
        public string Vkn { get; set; }

        [StringLength(100)]
        public string Parameter1 { get; set; }

        [StringLength(100)]
        public string Parameter2 { get; set; }

        [StringLength(100)]
        public string Parameter3 { get; set; }

        [StringLength(100)]
        public string Parameter4 { get; set; }
    }
}
