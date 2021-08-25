using KARYA.CORE.Entities;
using KARYA.MODEL.Entities.Base.Abstarct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KARYA.MODEL.Entities.Base.Concrete
{
    public class BaseEntityEnableCode : BaseEntityEnable,IBaseEntityEnableCode
    {
        [Column(Order = 2), Required, StringLength(30)]
        public string Code { get; set; }
    }
}
