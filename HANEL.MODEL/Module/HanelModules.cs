using KARYA.MODEL.Entities.Karya;
using KARYA.MODEL.Module;
using System;

namespace HANEL.MODEL.Module
{
    public class HanelModules: CoreModules
    {
        public HanelModules()
        {
            
            #region BUDGET
            ModuleList.Add(new AppModule() { Id = HanelRole.BudgetModule,      ParentId = 0,                          Name = "Budget Module",     DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            #region BuDGET ENTRY                          
            ModuleList.Add(new AppModule() { Id = HanelRole.BudgetEntry,       ParentId = HanelRole.BudgetModule,     Name = "Budget Entry",      DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = HanelRole.BudgetEntryEdit,   ParentId = HanelRole.BudgetEntry,      Name = "Budget Entry Edit", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            #endregion
            #endregion

            #region REPORT
            ModuleList.Add(new AppModule() { Id = HanelRole.ReportModule,      ParentId = 0,                          Name = "Report Module",     DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            #region P&L REPORT                          
            ModuleList.Add(new AppModule() { Id = HanelRole.PlReport,          ParentId = HanelRole.ReportModule,     Name = "P&L Report",        DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = HanelRole.PlDashboard,       ParentId = HanelRole.ReportModule,     Name = "P&L Dashboard",     DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = HanelRole.PlPivot,           ParentId = HanelRole.ReportModule,     Name = "P&L Pivot",         DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = HanelRole.PlPivotAdd,        ParentId = HanelRole.PlPivot,          Name = "P&L Pivot Add",     DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = HanelRole.PlPivotEdit,       ParentId = HanelRole.PlPivot,          Name = "P&L Pivot Edit",    DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = HanelRole.PlPivotDelete,     ParentId = HanelRole.PlPivot,          Name = "P&L Pivot Delete",  DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            #endregion
            #endregion
            #region CARI REPORT                          
            ModuleList.Add(new AppModule() { Id = HanelRole.CariReport,        ParentId = HanelRole.ReportModule,    Name = "Cari Report",        DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            #endregion
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
