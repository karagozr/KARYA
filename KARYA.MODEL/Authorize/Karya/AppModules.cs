using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Authorize.Karya
{
    public class AppModules: IAppModules
    {
        public AppModules()
        {
            ModuleList = new List<AppModule>();
            #region ADMIN PANEL
            ModuleList.Add(new AppModule() { Id = (int)AppRole.AdminPanel,        ParentId = 0,                                   Name = "Admin Panel",       DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            #region USER CONTROL                                                                                                
            ModuleList.Add(new AppModule() { Id = (int)AppRole.UserControl,       ParentId = (int)AppRole.AdminPanel,       Name = "User Control",      DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.UserAdd,           ParentId = (int)AppRole.UserControl,      Name = "User Add",          DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.UserEdit,          ParentId = (int)AppRole.UserControl,      Name = "User Edit",         DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.UserDelete,        ParentId = (int)AppRole.UserControl,      Name = "User Delete",       DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.AuthorizeModul,    ParentId = (int)AppRole.AdminPanel,       Name = "Authorize Module",  DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.AuthorizeAdd,      ParentId = (int)AppRole.AuthorizeModul,   Name = "Authorize Add",     DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.AuthorizeEdit,     ParentId = (int)AppRole.AuthorizeModul,   Name = "Authorize Edit",    DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.AuthorizeDelete,   ParentId = (int)AppRole.AuthorizeModul,   Name = "Authorize Edit",    DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            #endregion
            #endregion

            #region BUDGET
            ModuleList.Add(new AppModule() { Id = (int)AppRole.BudgetModule,      ParentId = 0,                                   Name = "Budget Module",     DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            #region BuDGET ENTRY                          
            ModuleList.Add(new AppModule() { Id = (int)AppRole.BudgetEntry,       ParentId = (int)AppRole.BudgetModule,     Name = "Budget Entry",      DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.BudgetEntryEdit,   ParentId = (int)AppRole.BudgetEntry,      Name = "Budget Entry Edit", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            #endregion
            #endregion

            #region REPORT
            ModuleList.Add(new AppModule() { Id = (int)AppRole.ReportModule,      ParentId = 0,                                   Name = "Report Module",     DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            #region P&L REPORT                          
            ModuleList.Add(new AppModule() { Id = (int)AppRole.PlReport,          ParentId = (int)AppRole.ReportModule,     Name = "P&L Report",        DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.PlDashboard,       ParentId = (int)AppRole.ReportModule,     Name = "P&L Dashboard",     DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.PlPivot,           ParentId = (int)AppRole.ReportModule,     Name = "P&L Pivot",         DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.PlPivotAdd,        ParentId = (int)AppRole.PlPivot,          Name = "P&L Pivot Add",     DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.PlPivotEdit,       ParentId = (int)AppRole.PlPivot,          Name = "P&L Pivot Edit",    DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.PlPivotDelete,     ParentId = (int)AppRole.PlPivot,          Name = "P&L Pivot Delete",  DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            #endregion
            #endregion
            #region CARI REPORT                          
            ModuleList.Add(new AppModule() { Id = (int)AppRole.CariReport,        ParentId = (int)AppRole.ReportModule,    Name = "Cari Report",        DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            #endregion
        }


        public IList<AppModule> ModuleList { get ; set ; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
