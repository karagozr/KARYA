using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KARYA.MODEL.Enums.Karya
{
    public enum FieldType:short
    {
        [Description("Metin")]
        String=1,

        [Description("Tam Sayı")]
        Integer =2,

        [Description("Ondalıklı Sayı")]
        Double =3,

        [Description("Tarih")]
        DateTime =4,

        [Description("Mantıksal")]
        Boolen =5

    }
}
