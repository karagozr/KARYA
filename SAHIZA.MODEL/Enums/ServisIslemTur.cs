using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SAHIZA.MODEL.Enums
{
    public enum ServisIslemTur : short
    {
        [Description("Garantili Bakım")]
        GarantiliBakim = 1,

        [Description("Ücretli Bakım")]
        UcretliBakim = 2,

        [Description("Ücretsiz Bakım")]
        UcretsizBakim = 3,

    }
}
