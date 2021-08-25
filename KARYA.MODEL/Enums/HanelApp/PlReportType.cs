using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KARYA.MODEL.Enums.HanelApp
{
    public enum PlReportType:short
    {
        [Description("Toplam Gelir")]
        TotalIncome = 1,

        [Description("Personel")]
        Personel = 2,

        [Description("İşletme")]
        Operation = 3,

        [Description("Tesis")]
        Plant = 4,

        [Description("Toplam Gider")]
        TotalExpenditure = 5,

        [Description("EBITDA")]
        Ebitda = 6

    }
}
