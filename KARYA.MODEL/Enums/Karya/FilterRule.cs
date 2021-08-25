using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KARYA.MODEL.Enums.Karya
{
    public enum FilterRule : short
    {
        [Description("İçerir")]
        Contains = 1,

        [Description("İçermez")]
        NotContains = 2,
        
        [Description("Eşittir")]
        Equal = 3,
        
        [Description("Eşit Değildir")]
        NotEqual = 4,

        [Description("Vardır")]
        IsAnyOf = 5,

        [Description("Yoktur")]
        IsNoneOf = 6,

        [Description("İle Başlar")]
        StartWith = 7,

        [Description("İle Biter")]
        EndWith = 8,

        [Description("Küçüktür")]
        IsLessThan = 9,

        [Description("Küçük Eşittir")]
        IsLessThanOrEqual = 10,

        [Description("Büyüktür")]
        IsGreaterThan = 11,

        [Description("Büyük Eşittir")]
        IsGreaterThanOrEqual = 12,

        [Description("Arasında")]
        Between = 13

    }
}
