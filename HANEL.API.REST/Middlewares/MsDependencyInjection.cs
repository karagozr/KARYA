using HANEL.BUSINESS.Abstract;
using HANEL.BUSINESS.Abstract.Accounting;
using HANEL.BUSINESS.Abstract.Finance;
using HANEL.BUSINESS.Abstract.General;
using HANEL.BUSINESS.Abstract.Hotel;
using HANEL.BUSINESS.Abstract.PlReport;
using HANEL.BUSINESS.Concrete;
using HANEL.BUSINESS.Concrete.Accounting;
using HANEL.BUSINESS.Concrete.Accounting.Netsis;
using HANEL.BUSINESS.Concrete.Finance;
using HANEL.BUSINESS.Concrete.General;
using HANEL.BUSINESS.Concrete.Hotel;
using HANEL.BUSINESS.Concrete.PlReports;
using HANEL.DATAACCESS.Abstract;
using HANEL.DATAACCESS.Abstract.Accounting;
using HANEL.DATAACCESS.Abstract.Finance;
using HANEL.DATAACCESS.Concrete.EntityFramework;
using HANEL.DATAACCESS.Concrete.EntityFramework.Accounting;
using HANEL.DATAACCESS.Concrete.EntityFramework.Finance;
using HANEL.MODEL.Module;
using HANEL.SERVICE.EINVOICE.Abstract;
using HANEL.SERVICE.EINVOICE.Concrete.EFinansService;
using KARYA.MODEL.Module;
using Microsoft.Extensions.DependencyInjection;

namespace HANEL.API.REST.Middlewares
{
    public static class MsDependencyInjection
    {
        public static void AddMsDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICoreModules, HanelModules>();

            services.AddScoped<IPlReportManager, PlReportManager>();
            services.AddScoped<ICariReportManager, CariReportManager>();
            services.AddScoped<IActualCostManager, ActualCostManager>();

            services.AddScoped<IBudgetDal, BudgetDal>();
            services.AddScoped<IBudgetManager, BudgetManager>();

            services.AddScoped<IInvoiceDal, InvoiceDal>();
            services.AddScoped<IInvoiceManager, InvoiceManager>();

            services.AddScoped<IBudgetExchangeRateDal, BudgetExchangeRateDal>();
            services.AddScoped<IBudgetExchangeRateManager, BudgetExchangeRateManager>();

            services.AddScoped<IBudgetDetailDal, BudgetDetailDal>();
            services.AddScoped<IBudgetDetailManager, BudgetDetailManager>();
            services.AddScoped<IBudgetSubDetailDal, BudgetSubDetailDal>();
            services.AddScoped<IBudgetSubDetailManager, BudgetSubDetailManager>();
            services.AddScoped<IBudgetCodeNameManager, BudgetCodeNameManager>();
            services.AddScoped<IBudgetActualCostManager, BudgetActualCostManager>();

            services.AddScoped<INakitAkisManager, NetsisNakitAkisManager>();

            services.AddScoped<ICariManager, NetCariManager>();
            services.AddScoped<IStokManager, NetStokManager>();
            services.AddScoped<IMuhasebeManager, NetMuhasebeManager>();

            services.AddScoped<IManagmentManager, NetManagmentManager>();
            services.AddScoped<IErpInvoiceManager, NetInvoiceManager>();

            services.AddScoped<IPivotReportTemplateDal, PivotReportTemplateDal>();
            services.AddScoped<IPivotReportTemplateManager, PivotReportTemplateManager>();

            services.AddSingleton<IWorker, InvoiceServiceWorker>();

            services.AddSingleton<ICompanyDal, CompanyDal>();
            services.AddSingleton<ICompanyManager, CompanyManager>();

            services.AddSingleton<IInvoiceDal, InvoiceDal>();
            services.AddSingleton<IInvoiceManager, InvoiceManager>();

            services.AddSingleton<IServiceAuthUtility, EFinansAuthServiceUtility>();
            services.AddSingleton<IIncomingInvoiceUtility, EFinansIncommingInvoiceUtility>();

            services.AddSingleton<IHotelReportManager, HotelReportManager>();


        }
    }
}
