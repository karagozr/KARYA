using HANEL.BUSINESS.Abstract;
using HANEL.BUSINESS.Abstract.Accounting;
using HANEL.MODEL.DataTransferModels.EServisEntegrator;
using HANEL.MODEL.Entities;
using HANEL.MODEL.Entities.Muhasebe;
using HANEL.SERVICE.EINVOICE.Abstract;
using HANEL.SERVICE.EINVOICE.Concrete.EFinansService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HANEL.API.REST
{
    public class InvoiceServiceWorker : IWorker
    {
        private readonly ILogger<InvoiceServiceWorker> _logger;
 
        private Timer _timer;

        ICompanyManager _companyManager;
        IInvoiceManager _invoiceManager;
        IIncomingInvoiceUtility _incomingInvoiceUtility;
        IServiceAuthUtility _serviceAuthUtility;
        IConfiguration _configuration;

        public InvoiceServiceWorker(ILogger<InvoiceServiceWorker> logger, 
            IConfiguration configuration,
            ICompanyManager companyManager, IInvoiceManager invoiceManager
            )
        {
            _companyManager = companyManager;
            _invoiceManager = invoiceManager;
            _configuration = configuration;

            _logger = logger;
            _timer = new Timer(async o => await RunService(), null, TimeSpan.Zero, TimeSpan.FromMinutes(10)); //TimeSpan.FromHours(1)

        }


        public List<Company> SirketListesi()
        {
            var result = _companyManager.GetAll();
            if (result.Result.Success) return result.Result.Data.ToList();
            else return null;
        }

        public int FaturaSayisi(string vkn)
        {
            var result = _invoiceManager.CountInvoices(vkn);
            if (result.Result.Success) return result.Result.Data;
            else return 0;
        }

        public async Task<List<Fatura>> ServistenGelenFaturalar(int sira, string vkn)
        {
            using (_serviceAuthUtility = new EFinansAuthServiceUtility())
            {
                var loginResult = await _serviceAuthUtility.Login(
                    new EntegratorLoginModel { 
                        UserName = _configuration["EInvoiceService:Username"], 
                        Password = _configuration["EInvoiceService:Password"], 
                        Language = _configuration["EInvoiceService:Language"] });

                if (loginResult.Success)
                {
                    using (_incomingInvoiceUtility = new EFinansIncommingInvoiceUtility())
                    {
                        var resultData = await _incomingInvoiceUtility.ListInvoiceWithDetail(new FaturaFiltreModel { BelgeTipi = "FATURA", SonBelgeSiraNo = sira, VergiNo = vkn });
                        _logger.LogInformation($"{DateTime.Now.ToString()} : INVOICE SERVICE INFO  :: " + resultData.Message);
                        return resultData.Data == null ? new List<Fatura>() : resultData.Data.ToList();
                    }
                  
                }
                else
                {
                    _logger.LogError($"{DateTime.Now.ToString()} : INVOICE SERVICE SESSION ERROR  :: " + loginResult.Message);
                    return new List<Fatura>();
                }
            }

                
        }

        public async Task<string> InvoiceDocument(string vkn, string ett, string docType)
        {
            using (_serviceAuthUtility = new EFinansAuthServiceUtility())
            {
                var loginResult = await _serviceAuthUtility.Login(
                    new EntegratorLoginModel { UserName = _configuration["EInvoiceService:Username"], 
                    Password = _configuration["EInvoiceService:Password"], 
                    Language = _configuration["EInvoiceService:Language"] });
                
                if (loginResult.Success)
                {
                    using (_incomingInvoiceUtility = new EFinansIncommingInvoiceUtility())
                    {
                        var resultData = await _incomingInvoiceUtility.GetInvoiceDocument(
                            new FaturaFiltreModel { BelgeTipi = "FATURA", Guid = ett, VergiNo = vkn, BelgeFormati = docType });
                        _logger.LogError($"{DateTime.Now.ToString()} : INVOICE SERVICE ERROR  :: " + resultData.Message);
                        return resultData.Data;
                    }
                }
                else
                {
                    _logger.LogError($"{DateTime.Now.ToString()} : INVOICE SERVICE SESSION ERROR  :: " + loginResult.Message);
                    return "";
                }
            }
        }

        public async Task RunService()
        {
            foreach (var item in SirketListesi())
            {
                _logger.LogInformation($"{DateTime.Now.ToString()} : INVOICE START ::{item.Vkn} - {item.Name}");

                var ftrCount = FaturaSayisi(item.Vkn);
                var gelenFaturaList = await ServistenGelenFaturalar(ftrCount, item.Vkn);


                if (gelenFaturaList.Count > 0)
                {
                    var sonuc = await _invoiceManager.AddComplex(gelenFaturaList);

                    if (sonuc.Success == false)
                    {
                        _logger.LogError($"{DateTime.Now.ToString()} : INVOICE SAVING ERROR  :: {item.Vkn} - {sonuc.Message}");
                    }
                    else
                    {
                        _logger.LogInformation($"{DateTime.Now.ToString()} : INVOICE SAVING SUCCESS :: {item.Vkn} - Saved {gelenFaturaList.Count} invoice");
                    }
                }
                else
                {
                    _logger.LogWarning($"{DateTime.Now.ToString()} : INVOICE RESULT :: {item.Vkn} - hasn't new invoice");
                }

            }
            /*
             * Update Data Cde Block in here
             */
        } 

        public async Task DoWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested) ;
        }
    }
}



