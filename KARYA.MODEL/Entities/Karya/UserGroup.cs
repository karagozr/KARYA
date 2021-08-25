using KARYA.MODEL.Entities.Base.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KARYA.MODEL.Entities.Karya
{
    public class UserGroup : BaseEntity
    {

        [Required, StringLength(20)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public int Description { get; set; }


    }
}
