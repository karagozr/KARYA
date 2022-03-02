using KARYA.MODEL.Entities.Karya;
using KARYA.MODEL.Module;
using System;
using System.Collections.Generic;

namespace HANEL.MODEL.Module
{
    public class HanelModules: CoreModules
    {
        public HanelModules()
        {

            ModuleList = new List<AppModule>();
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.AdminModule, ParentId = 0, Name = "Admin Modülü", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.UserPanel, ParentId = (int)HanelRole.AdminModule, Name = "Kullanıcı Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.UserEdit, ParentId = (int)HanelRole.UserPanel, Name = "Kullanıcı Ekle/Düzenle", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.UserResetPassword, ParentId = (int)HanelRole.UserPanel, Name = "Parola Sıfırla", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.AuthGroupPanel, ParentId = (int)HanelRole.AdminModule, Name = "Yetki Grubu Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.AuthGroupDelete, ParentId = (int)HanelRole.AuthGroupPanel, Name = "Yetki Grubu Sil", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.AuthGroupEdit, ParentId = (int)HanelRole.AuthGroupPanel, Name = "Yetki Grubu Ekle/Düzenle", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });

            ModuleList.Add(new AppModule() { Id = (int)HanelRole.AccountinModule, ParentId = 0, Name = "Muhasebe Modülü", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.InvoiceIntegPanel, ParentId = (int)HanelRole.AccountinModule, Name = "Fatura Entegre Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.InvoiceIntegAdd, ParentId = (int)HanelRole.InvoiceIntegPanel, Name = "Fatura Entegre Ekle", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.InvoiceIntegUpdate, ParentId = (int)HanelRole.InvoiceIntegPanel, Name = "Fatura Entegre Düzenle", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.InvoiceIntegDelete, ParentId = (int)HanelRole.InvoiceIntegPanel, Name = "Fatura Entegre Sil", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.InvoiceIntegEdit, ParentId = (int)HanelRole.InvoiceIntegPanel, Name = "Fatura Entegre Ekle/Düzenle", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.InvoiceIntegPreview, ParentId = (int)HanelRole.InvoiceIntegPanel, Name = "Fatura Entegre Önizle", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.InvoiceIntegYevmiyeFisPreview, ParentId = (int)HanelRole.InvoiceIntegPanel, Name = "Fatura Entegre Yevmiye Fişi", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.FinanceModule, ParentId = 0, Name = "Finans Modülü", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.FinanceReports, ParentId = (int)HanelRole.FinanceModule, Name = "Rapor Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.CashFlow, ParentId = (int)HanelRole.FinanceReports, Name = "Rapor Nakit Akış Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.CashFlowGes, ParentId = (int)HanelRole.CashFlow, Name = "Rapor Nakit Akış Paneli - Ges", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.CashFlowDetailGes, ParentId = (int)HanelRole.CashFlowGes, Name = "Rapor Nakit Akış Detay - Ges", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.CashFlowHotel, ParentId = (int)HanelRole.CashFlow, Name = "Rapor Nakit Akış Paneli - Otel", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.CashFlowDetailHotel, ParentId = (int)HanelRole.CashFlowHotel, Name = "Rapor Nakit Akış Detay - Otel", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });

            ModuleList.Add(new AppModule() { Id = (int)HanelRole.CashFlowConstruction, ParentId = (int)HanelRole.CashFlow, Name = "Rapor Nakit Akış Paneli - İnşaat", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.CashFlowDetailConstruction, ParentId = (int)HanelRole.CashFlowConstruction, Name = "Rapor Nakit Akış Detay - İnşaat", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.PLReport, ParentId = (int)HanelRole.FinanceReports, Name = "P&L Rapor Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.PlReportGes, ParentId = (int)HanelRole.PLReport, Name = "P&L Rapor Paneli - Ges", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.PlReportHotel, ParentId = (int)HanelRole.PLReport, Name = "P&L Rapor Paneli - Otel", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.Budget, ParentId = (int)HanelRole.FinanceModule, Name = "Bütçe Paneli ", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.HotelModule, ParentId = 0, Name = "Otel Modülü", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.HotelReports, ParentId = (int)HanelRole.HotelModule, Name = "Otel Rapor Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.HotelTableReports, ParentId = (int)HanelRole.HotelReports, Name = "Otel Tablo Rapor Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.HotelRoomSaleForAgentRpt, ParentId = (int)HanelRole.HotelTableReports, Name = "Otel Tablo Rapor Oda Satış Acente", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.HotelRoomIncomeForAgentRpt, ParentId = (int)HanelRole.HotelTableReports, Name = "Otel Tablo Rapor Oda Gelir Acente", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.HotelDashReports, ParentId = (int)HanelRole.HotelReports, Name = "Otel Dashboard Paneli", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.HotelHomeCamDash, ParentId = (int)HanelRole.HotelDashReports, Name = "Otel Dashboard Ana Ekran", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.HotelRoomIprCaTreeDash, ParentId = (int)HanelRole.HotelDashReports, Name = "Otel Dashboard Ülke Acenta Gelir Oda Pax Ağaç Dash ", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.HotelRoomIprLineDash, ParentId = (int)HanelRole.HotelDashReports, Name = "Otel Dashboard Gelir Oda Pax Line Dash  ", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });

            ModuleList.Add(new AppModule() { Id = (int)HanelRole.ConstructionModule, ParentId = (int)0, Name = "İnşaat Modülü", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.ConstructionReport, ParentId = (int)HanelRole.ConstructionModule, Name = "İnşaat Raporları", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = (int)HanelRole.ConstructionActivityReport, ParentId = (int)HanelRole.ConstructionReport, Name = "İnşaat Aktivite Raporu", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
