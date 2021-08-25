using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Entities.Base.Abstarct
{
    public interface IBaseEntityEnableCode : IBaseEntityEnable
    {
        string Code { get; set; }
    }
}
