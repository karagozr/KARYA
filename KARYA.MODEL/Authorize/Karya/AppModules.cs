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
            ModuleList.Add(new AppModule() { Id = (int)AppRole.AdminModule, ParentId = (int)0, Name = "Admin Modülü", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.UserPanel, ParentId = (int)AppRole.AdminModule, Name = "Kullanıcı Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.UserEdit, ParentId = (int)AppRole.UserPanel, Name = "Kullanıcı Ekle/Düzenle", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.AuthGroupPanel, ParentId = (int)AppRole.AdminModule, Name = "Yetki Grubu Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.AuthGroupDelete, ParentId = (int)AppRole.AuthGroupPanel, Name = "Yetki Grubu Sil", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.AuthGroupEdit, ParentId = (int)AppRole.AuthGroupPanel, Name = "Yetki Grubu Ekle/Düzenle", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.AccountinModule, ParentId = (int)0, Name = "Muhasebe Modülü", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.InvoiceIntegPanel, ParentId = (int)AppRole.AccountinModule, Name = "Fatura Entegre Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.InvoiceIntegAdd, ParentId = (int)AppRole.InvoiceIntegPanel, Name = "Fatura Entegre Ekle", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.InvoiceIntegUpdate, ParentId = (int)AppRole.InvoiceIntegPanel, Name = "Fatura Entegre Düzenle", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.InvoiceIntegDelete, ParentId = (int)AppRole.InvoiceIntegPanel, Name = "Fatura Entegre Sil", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.InvoiceIntegEdit, ParentId = (int)AppRole.InvoiceIntegPanel, Name = "Fatura Entegre Ekle/Düzenle", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.InvoiceIntegPreview, ParentId = (int)AppRole.InvoiceIntegPanel, Name = "Fatura Entegre Önizle", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.InvoiceIntegYevmiyeFisPreview, ParentId = (int)AppRole.InvoiceIntegPanel, Name = "Fatura Entegre Yevmiye Fişi", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.FinanceModule, ParentId = (int)0, Name = "Finans Modülü", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.FinanceReports, ParentId = (int)AppRole.FinanceModule, Name = "Rapor Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.CashFlow, ParentId = (int)AppRole.FinanceReports, Name = "Rapor Nakit Akış Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.CashFlowGes, ParentId = (int)AppRole.CashFlow, Name = "Rapor Nakit Akış Paneli -Ges", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.CashFlowHotel, ParentId = (int)AppRole.CashFlow, Name = "Rapor Nakit Akış Paneli - Otel", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.PLReport, ParentId = (int)AppRole.FinanceReports, Name = "P&L Rapor Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.PlReportGes, ParentId = (int)AppRole.PLReport, Name = "P&L Rapor Paneli - Ges", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.PlReportHotel, ParentId = (int)AppRole.PLReport, Name = "P&L Rapor Paneli - Otel", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.Budget, ParentId = (int)AppRole.FinanceModule, Name = "Bütçe Paneli ", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.HotelModule, ParentId = (int)0, Name = "Otel Modülü", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.HotelReports, ParentId = (int)AppRole.HotelModule, Name = "Otel Rapor Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.HotelTableReports, ParentId = (int)AppRole.HotelReports, Name = "Otel Tablo Rapor Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.HotelRoomSaleForAgentRpt, ParentId = (int)AppRole.HotelTableReports, Name = "Otel Tablo Rapor Oda Satış Acente", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.HotelRoomIncomeForAgentRpt, ParentId = (int)AppRole.HotelTableReports, Name = "Otel Tablo Rapor Oda Gelir Acente", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.HotelDashReports, ParentId = (int)AppRole.HotelReports, Name = "Otel Dashboard Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.HotelHomeCamDash, ParentId = (int)AppRole.HotelDashReports, Name = "Otel Dashboard Ana Ekran", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.HotelRoomIprCaTreeDash, ParentId = (int)AppRole.HotelDashReports, Name = "Otel Dashboard Ülke Acenta Gelir Oda Pax Ağaç Dash ", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.HotelRoomIprLineDash, ParentId = (int)AppRole.HotelDashReports, Name = "Otel Dashboard Gelir Oda Pax Line Dash  ", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });

        }


        public IList<AppModule> ModuleList { get ; set ; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
