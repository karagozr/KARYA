using KARYA.CORE.Entities;
using KARYA.MODEL.Entities.Base.Abstarct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KARYA.MODEL.Entities.Base.Concrete
{
    public class BaseEntityEnable : BaseEntity, IBaseEntityEnable
    {
        [Column(Order = 1), Required]
        public bool Enable { get; set; }
    }
}
