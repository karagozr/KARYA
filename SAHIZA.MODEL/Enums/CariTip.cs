using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHIZA.MODEL.Enums
{
    public enum CariTip : short
    {
        [Description("Ticari")]
        Ticari = 1,

        [Description("Şahıs")]
        Sahis = 2,
    }
   
}
