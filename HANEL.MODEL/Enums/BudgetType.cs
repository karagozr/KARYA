using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HANEL.MODEL.Enums
{
    public enum BudgetType : short
    {
        [Description("Gelir Bütçesi")]
        IncomeBudget = 1,

        [Description("Gider Bütçesi")]
        ExpenditureBudget = 2,

        [Description("Faiz Bütçesi")]
        InterestBudget = 3,

        [Description("Kredi Bütçesi")]
        CreditBudget = 4

    }
}
