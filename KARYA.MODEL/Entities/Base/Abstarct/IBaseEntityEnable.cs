using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Entities.Base.Abstarct
{
    public interface IBaseEntityEnable : IBaseEntity
    {
        bool Enable { get; set; }
    }
}
