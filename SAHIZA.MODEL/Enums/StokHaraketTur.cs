using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SAHIZA.MODEL.Enums
{
    public enum StokHaraketTur : short
    {
        [Description("Stok Giriş")]
        StokGiris=1,

        [Description("Stok Çıkış")]
        StokCikis = 2,

        [Description("Teklif")]
        Teklif = 3,

    }
}
