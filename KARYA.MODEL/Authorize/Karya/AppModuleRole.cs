using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KARYA.MODEL.Authorize.Karya
{
    [Flags]
    public enum AppRole:int
    {
        [Description("Admin Panel")]         AdminPanel         = 1,
        [Description("User Control")]        UserControl        = 2,
        [Description("User Add")]            UserAdd            = 3,
        [Description("User Edit")]           UserEdit           = 4,
        [Description("User Delete")]         UserDelete         = 5,
        [Description("Authorize Control")]   AuthorizeModul     = 20,
        [Description("Authorize Add")]       AuthorizeAdd       = 21,
        [Description("Authorize Edit")]      AuthorizeEdit      = 22,
        [Description("Authorize Delete")]    AuthorizeDelete    = 23,

        [Description("Budget Module")]       BudgetModule       = 100,
        [Description("Budget Entry")]        BudgetEntry        = 101,
        [Description("Budget Entry Edit")]   BudgetEntryEdit    = 102,
        [Description("Budget Entry Report")] BudgetEntryReport  = 103,

        [Description("Report Module")]       ReportModule       = 200,
        [Description("P&L Report")]          PlReport           = 201,
        [Description("P&L Dashboard")]       PlDashboard        = 202,
        [Description("P&L Pivot")]           PlPivot            = 203,
        [Description("P&L Pivot Add")]       PlPivotAdd         = 2031,
        [Description("P&L Pivot Edit")]      PlPivotEdit        = 2032,
        [Description("P&L Pivot Delete")]    PlPivotDelete      = 2033,
        [Description("Cari Report")]         CariReport         = 210,
       
    }
}
