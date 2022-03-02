using KARYA.MODEL.Module;
using System;
using System.ComponentModel;

namespace HANEL.MODEL.Module
{
    public class HanelRole : BaseRole
    {

        [Description("Muhasebe Modülü")] public const int AccountinModule = 50000;
        [Description("Fatura Entegre Paneli")] public const int InvoiceIntegPanel = 51000;
        [Description("Fatura Entegre Ekle")] public const int InvoiceIntegAdd = 51001;
        [Description("Fatura Entegre Düzenle")] public const int InvoiceIntegUpdate = 51002;
        [Description("Fatura Entegre Sil")] public const int InvoiceIntegDelete = 51003;
        [Description("Fatura Entegre Ekle/Düzenle")] public const int InvoiceIntegEdit = 51004;
        [Description("Fatura Entegre Önizle")] public const int InvoiceIntegPreview = 51005;
        [Description("Fatura Entegre Yevmiye Fişi")] public const int InvoiceIntegYevmiyeFisPreview = 51006;
        [Description("Finans Modülü")] public const int FinanceModule = 60000;
        [Description("Rapor Paneli")] public const int FinanceReports = 61000;
        [Description("Rapor Nakit Akış Paneli")] public const int CashFlow = 61100;
        [Description("Rapor Nakit Akış Paneli - Ges")] public const int CashFlowGes = 61110;
        [Description("Rapor Nakit Akış Detay - Ges")] public const int CashFlowDetailGes = 61111;
        [Description("Rapor Nakit Akış Paneli - Otel")] public const int CashFlowHotel = 61120;
        [Description("Rapor Nakit Akış Detay - Otel")] public const int CashFlowDetailHotel = 61121;
        [Description("Rapor Nakit Akış Paneli - Otel")] public const int CashFlowConstruction = 61130;
        [Description("Rapor Nakit Akış Detay - Otel")] public const int CashFlowDetailConstruction = 61131;
        [Description("P&L Rapor Paneli")] public const int PLReport = 61200;
        [Description("P&L Rapor Paneli - Ges")] public const int PlReportGes = 61201;
        [Description("P&L Rapor Paneli - Otel")] public const int PlReportHotel = 61202;
        [Description("Bütçe Paneli")] public const int Budget = 62000;
        [Description("Otel Modülü")] public const int HotelModule = 70000;
        [Description("Otel Rapor Paneli")] public const int HotelReports = 71000;
        [Description("Otel Tablo Rapor Paneli")] public const int HotelTableReports = 71100;
        [Description("Otel Tablo Rapor Oda Satış Acente")] public const int HotelRoomSaleForAgentRpt = 71101;
        [Description("Otel Tablo Rapor Oda Gelir Acente")] public const int HotelRoomIncomeForAgentRpt = 71102;
        [Description("Otel Dashboard Paneli")] public const int HotelDashReports = 71200;
        [Description("Otel Dashboard Ana Ekran")] public const int HotelHomeCamDash = 72101;
        [Description("Otel Dashboard Ülke Acenta Gelir Oda Pax Ağaç Dash ")] public const int HotelRoomIprCaTreeDash = 72102;
        [Description("Otel Dashboard Gelir Oda Pax Line Dash  ")] public const int HotelRoomIprLineDash = 72103;

        [Description("İnşaat Modülü")] public const int ConstructionModule = 80000;
        [Description("İnşaat Rapor")] public const int ConstructionReport = 81000;
        [Description("İnşaat Aktivite Rapor")] public const int ConstructionActivityReport = 81001;



    }
}
