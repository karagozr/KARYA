using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SAHIZA.MODEL.Enums
{
    public enum GarantiDurum : short
    {
        [Description("Hepsi")]
        Hepsi=0,

        [Description("Garanti Devam")]
        DevamEden =1,

        [Description("Garanti Biten")]
        SonaEren = 2,

    }
}
