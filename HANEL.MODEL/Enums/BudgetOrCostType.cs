using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HANEL.MODEL.Enums
{
    public enum BudgetOrCostType : short
    {
        [Description("Bütçe")]
        Budget = 1,

        [Description("Gerçekleşen")]
        Cost = 2

    }
}
