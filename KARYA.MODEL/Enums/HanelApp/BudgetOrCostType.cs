using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KARYA.MODEL.Enums.HanelApp
{
    public enum BudgetOrCostType : short
    {
        [Description("Bütçe")]
        Budget = 1,

        [Description("Gerçekleşen")]
        Cost = 2

    }
}
