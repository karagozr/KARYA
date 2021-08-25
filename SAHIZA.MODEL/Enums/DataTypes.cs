using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHIZA.MODEL.Enums
{
    public enum DataTypes : short
    {
        [Description("Metin")]
        Text = 1,

        [Description("Numara")]
        Number = 2,

        [Description("Sayi")]
        Double = 3,

        [Description("Tarih")]
        DateTime = 4,

        [Description("Mantıksal")]
        Bool = 5,

        [Description("Çoktan Seçim")]
        Selection = 6,
    }
}
