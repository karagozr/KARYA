using KARYA.CORE.Entities;
using KARYA.MODEL.Entities.Base.Abstarct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KARYA.MODEL.Entities.Base.Concrete
{
    public class BaseEntity : KARYA.CORE.Entities.Concrete.BaseEntity, IBaseEntity
    {
        [Column(Order = 0), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
    }
}
