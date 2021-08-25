using KARYA.MODEL.Module;
using System.ComponentModel;

namespace HANEL.MODEL.Module
{
    public class HanelRole:BaseRole
    {
        [Description("Budget Module")]
        public const int BudgetModule = 100;

        [Description("Budget Entry")]
        public const int BudgetEntry = 101;

        [Description("Budget Entry Edit")]
        public const int BudgetEntryEdit = 102;

        [Description("Budget Entry Report")]
        public const int BudgetEntryReport = 103;

        [Description("Report Module")]
        public const int ReportModule = 200;

        [Description("P&L Report")]
        public const int PlReport = 201;

        [Description("P&L Dashboard")]
        public const int PlDashboard = 202;

        [Description("P&L Pivot")]
        public const int PlPivot = 203;

        [Description("P&L Pivot Add")]
        public const int PlPivotAdd = 2031;

        [Description("P&L Pivot Edit")]
        public const int PlPivotEdit = 2032;

        [Description("P&L Pivot Delete")]
        public const int PlPivotDelete = 2033;

        [Description("Cari Report")]
        public const int CariReport = 210;


    }
}
