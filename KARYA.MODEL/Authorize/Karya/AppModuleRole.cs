using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KARYA.MODEL.Authorize.Karya
{
    [Flags]
    public enum AppRole:int
    {
        [Description("Admin Modülü")] AdminModule = 10000,
        [Description("Kullanıcı Paneli")] UserPanel = 11000,
        [Description("Kullanıcı Ekle/Düzenle")] UserEdit = 11004,
        [Description("Yetki Grubu Paneli")] AuthGroupPanel = 12000,
        [Description("Yetki Grubu Sil")] AuthGroupDelete = 12003,
        [Description("Yetki Grubu Ekle/Düzenle")] AuthGroupEdit = 12004,
        
        [Description("Muhasebe Modülü")] AccountinModule = 50000,
        [Description("Fatura Entegre Paneli")] InvoiceIntegPanel = 51000,
        [Description("Fatura Entegre Ekle")] InvoiceIntegAdd = 51001,
        [Description("Fatura Entegre Düzenle")] InvoiceIntegUpdate = 51002,
        [Description("Fatura Entegre Sil")] InvoiceIntegDelete = 51003,
        [Description("Fatura Entegre Ekle/Düzenle")] InvoiceIntegEdit = 51004,
        [Description("Fatura Entegre Önizle")] InvoiceIntegPreview = 51005,
        [Description("Fatura Entegre Yevmiye Fişi")] InvoiceIntegYevmiyeFisPreview = 51006,
        
        [Description("Finans Modülü")] FinanceModule = 60000,
        [Description("Rapor Paneli")] FinanceReports = 61000,
        [Description("Rapor Nakit Akış Paneli")] CashFlow = 61100,
        [Description("Rapor Nakit Akış Paneli -Ges")] CashFlowGes = 61101,
        [Description("Rapor Nakit Akış Paneli - Otel")] CashFlowHotel = 61102,
        [Description("P&L Rapor Paneli")] PLReport = 61200,
        [Description("P&L Rapor Paneli - Ges")] PlReportGes = 61201,
        [Description("P&L Rapor Paneli - Otel")] PlReportHotel = 61202,
        
        [Description("Bütçe Paneli ")] Budget = 62000,
        
        [Description("Otel Modülü")] HotelModule = 70000,
        [Description("Otel Rapor Paneli")] HotelReports = 71000,
        [Description("Otel Tablo Rapor Paneli")] HotelTableReports = 71100,
        [Description("Otel Tablo Rapor Oda Satış Acente")] HotelRoomSaleForAgentRpt = 71101,
        [Description("Otel Tablo Rapor Oda Gelir Acente")] HotelRoomIncomeForAgentRpt = 71102,
        [Description("Otel Dashboard Paneli")] HotelDashReports = 71200,
        [Description("Otel Dashboard Ana Ekran")] HotelHomeCamDash = 72101,
        [Description("Otel Dashboard Ülke Acenta Gelir Oda Pax Ağaç Dash ")] HotelRoomIprCaTreeDash = 72102,
        [Description("Otel Dashboard Gelir Oda Pax Line Dash  ")] HotelRoomIprLineDash = 72103,


    }
}
