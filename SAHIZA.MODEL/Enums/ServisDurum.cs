using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SAHIZA.MODEL.Enums
{
    public enum ServisDurum : short
    {
        [Description("Kayıt Alındı")]
        KayitAlindi = 0,

        [Description("Beklemede")]
        Beklemede = 10,

        [Description("İşlem Aşamasında")]
        Islemde = 20,

        [Description("Tamamlandı")]
        Tamamlandi = 30,

        [Description("Teslim edildi")]
        TeslimEdildi = 40,

    }
}
