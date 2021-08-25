
using HANEL.BUSINESS.Abstract;
using HANEL.BUSINESS.Abstract.Accounting;
using HANEL.BUSINESS.Concrete;
using HANEL.BUSINESS.Concrete.Accounting;
using HANEL.COM.INVOICE_SERVICE.Utilities;
using HANEL.DATAACCESS.Concrete.EntityFramework;
using HANEL.DATAACCESS.Concrete.EntityFramework.Accounting;
using HANEL.MODEL.DataTransferModels.EServisEntegrator;
using HANEL.MODEL.Entities;
using HANEL.MODEL.Entities.Muhasebe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.COM.INVOICE_SERVICE
{
    public class ProgramService
    {
        ICompanyManager _companyManager;
        IInvoiceManager _invoiceManager;
        public ProgramService()
        {
            _companyManager = new CompanyManager(new CompanyDal());
            _invoiceManager = new InvoiceManager(new InvoiceDal());
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

        public async Task<List<Fatura>> ServistenGelenFaturalar(int sira , string vkn)
        {
            var userUtility = new UserUtility();
            var res = await userUtility.Login(new EntegratorLoginModel { UserName = "hanelwebservice", Password = "Hanel1q2w3e4r", Language = "tr" });
            
            userUtility.Dispose();

            if (res.Success)
            {
                var gelenFaturaUtility = new GelenFaturaUtility();
                var resultData = await gelenFaturaUtility.FaturaDetayliListele(new FaturaFiltreModel { BelgeTipi = "FATURA", SonBelgeSiraNo = sira, VergiNo = vkn });

                return resultData.Data == null ? new List<Fatura>() : resultData.Data.ToList();


            }
            else
            {
                Console.WriteLine("SESSION ERROR  :: " + res.Message);
                return new List<Fatura>();
            }
        }

        /*"3850620268", arr, "FATURA", "HTML"*/
        public async Task<string> InvoiceDocument(string vkn, string ett, string docType)
        {
            var userUtility = new UserUtility();
            var res = await userUtility.Login(new EntegratorLoginModel { UserName = "hanelwebservice", Password = "Hanel1q2w3e", Language = "tr" });

            userUtility.Dispose();

            if (res.Success)
            {
                var gelenFaturaUtility = new GelenFaturaUtility();
                var resultData = await gelenFaturaUtility.FaturaBelgeGetir(new FaturaFiltreModel { BelgeTipi = "FATURA", Guid = ett, VergiNo = vkn,BelgeFormati= docType });

                return resultData.Data;


            }
            else
            {
                Console.WriteLine("SESSION ERROR  :: " + res.Message);
                return "";
            }
        }

        public async void RunService()
        {
            foreach (var item in SirketListesi())
            {
                Console.WriteLine($"\n=====>        :: ({item.Vkn}) {item.Name}");
                

                var ftrCount = FaturaSayisi(item.Vkn);
                var gelenFaturaList = await ServistenGelenFaturalar(ftrCount, item.Vkn);

                //while (gelenFaturaList.Count >= 100)
                //{
                //    ftrCount += 100;
                //    var eklenecekGelenler = await ServistenGelenFaturalar(ftrCount, item.Vkn);
                //    gelenFaturaList.AddRange(eklenecekGelenler);

                //    if (eklenecekGelenler.Count < 100) break;

                //}

                

                if (gelenFaturaList.Count> 0)
                {
                    var sonuc = await _invoiceManager.AddComplex(gelenFaturaList);

                    if (sonuc.Success == false)
                    {
                        Console.WriteLine($"SAVING ERROR  :: ({item.Vkn}) {sonuc.Message}");
                    }
                    else
                    {
                        Console.WriteLine($"SAVING SUCCESS:: ({item.Vkn})");
                    }
                }
                else
                {
                    Console.WriteLine($"SAVING RESULT :: ({item.Vkn}) - hasn't new invoice");
                }
                
            }
        }

    }
}
