using HANEL.BUSINESS.Abstract;
using HANEL.BUSINESS.Abstract.Accounting;
using HANEL.BUSINESS.Concrete;
using HANEL.BUSINESS.Concrete.Accounting;
using HANEL.DATAACCESS.Concrete.EntityFramework;
using HANEL.DATAACCESS.Concrete.EntityFramework.Accounting;
using HANEL.MODEL.DataTransferModels.EServisEntegrator;
using HANEL.MODEL.Entities;
using HANEL.MODEL.Entities.Muhasebe;
using HANEL.SERVICE.EINVOICE.Abstract;
using HANEL.SERVICE.EINVOICE.Concrete.EFinansService;
using KARYA.CORE.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HANEL.APP.CONSOLE
{
    public class InvoiceServiceWorker
    {

        ICompanyManager _companyManager;
        IInvoiceManager _invoiceManager;
        IIncomingInvoiceUtility _incomingInvoiceUtility;
        IServiceAuthUtility _serviceAuthUtility;

        private string _Username = AppsettingHelper.GetSingleValue("EInvoiceService", "Username");
        private string _Password = AppsettingHelper.GetSingleValue("EInvoiceService", "Password");
        private string _Language = AppsettingHelper.GetSingleValue("EInvoiceService", "Language");

        public InvoiceServiceWorker()
        {
            _companyManager = new CompanyManager(new CompanyDal());
            _invoiceManager = new InvoiceManager(new InvoiceDal());

        }

        public void FaturaUpdate()
        {
            try
            {
                //Console.WriteLine(" == TRY START == ");
                var res = _invoiceManager.GetAll().Result;
                if(!res.Success)
                    MyConsole.Error(new ConsoleInputModel
                    {
                        Text = DateTime.Now.ToString(),
                        Length = 20
                    }, new ConsoleInputModel
                    {
                        Text = "INVOICE MANAGER",
                        Length = 20
                    },new ConsoleInputModel
                    {
                        Text = "ERROR MESSAGE",
                        Length = 14
                    }, new ConsoleInputModel
                    {
                        Text = res.Message,
                        Length = 30
                    });

                


                var allData = res.Data.ToList();
                var maxId = 0;
                if (allData.Any(x => x.UpdatetedIndex != null))
                    maxId = allData.Max(x => x.UpdatetedIndex).Value;

                var faturas = allData.Where(x=>Convert.ToDateTime(x.FaturaTarihi).Year == 2022 && string.IsNullOrEmpty(x.AboneNo) && (x.GonderenVkn == "1090046353" )).ToList();

                MyConsole.Normal(new ConsoleInputModel
                {
                    Text = DateTime.Now.ToString(),
                    Length = 20
                }, new ConsoleInputModel
                {
                    Text = "INVOICE COUNT",
                    Length = 10
                }, new ConsoleInputModel
                {
                    Text = allData.Count.ToString(),
                    Length = 10
                }, new ConsoleInputModel
                {
                    Text = "UPDATE INVOICE COUNT",
                    Length = 20
                }, new ConsoleInputModel
                {
                    Text = faturas.Count.ToString(),
                    Length = 10
                });

                foreach (var item in faturas)
                {
                    using (_serviceAuthUtility = new EFinansAuthServiceUtility())
                    {

                        var loginResult = _serviceAuthUtility.Login(
                            new EntegratorLoginModel
                            {
                                UserName = _Username,
                                Password = _Password,
                                Language = _Language
                            }).Result;

                        if (loginResult.Success)
                        {
                            using (_incomingInvoiceUtility = new EFinansIncommingInvoiceUtility())
                            {
                                //var resultData = _incomingInvoiceUtility.GetInvoiceSubscribeNo(item.Guid, "FATURA", item.AlanVkn).Result;
                                var resultXML = _incomingInvoiceUtility.GetInvoiceXML(item.Guid, "FATURA", item.AlanVkn).Result;
                               

                                if (!resultXML.Success)
                                {
                                    MyConsole.Error( new ConsoleInputModel { 
                                        Text= DateTime.Now.ToString(),
                                        Length=20
                                    },new ConsoleInputModel
                                    {
                                        Text= "INVOICE ERROR",
                                        Length= 20
                                    },new ConsoleInputModel{
                                        Text = "GÖNDEREN",
                                        Length = 10
                                    },new ConsoleInputModel
                                    {
                                        Text = item.GonderenUnvan,
                                        Length = 25
                                    }, new ConsoleInputModel
                                    {
                                        Text = "ERROR MESSAGE",
                                        Length = 14
                                    }, new ConsoleInputModel
                                    {
                                        Text = resultXML.Message,
                                        Length = 30
                                    });

                                }
                                else if (resultXML.Success && resultXML.Data == null)
                                {
                                    MyConsole.Warning(new ConsoleInputModel
                                    {
                                        Text = DateTime.Now.ToString(),
                                        Length = 20
                                    }, new ConsoleInputModel
                                    {
                                        Text = "INVOICE WARNING",
                                        Length = 20
                                    }, new ConsoleInputModel
                                    {
                                        Text = "GÖNDEREN",
                                        Length = 10
                                    }, new ConsoleInputModel
                                    {
                                        Text = item.GonderenUnvan,
                                        Length = 25
                                    }, new ConsoleInputModel
                                    {
                                        Text = "ABONE/HIZMET/TESIRAT NO",
                                        Length = 25
                                    });
                                }
                                else
                                {
                                    item.AboneNo = _incomingInvoiceUtility.GetInvoiceSubscribeNo(resultXML.Data).Result.Data;
                                    item.Mahsup = Convert.ToDecimal(_incomingInvoiceUtility.GetInvoiceMahsupDetail(resultXML.Data).Result.Data);
                                    item.Yuvarlama = Convert.ToDecimal(_incomingInvoiceUtility.GetInvoiceRoundingDetail(resultXML.Data).Result.Data);

                                    item.UpdatetedIndex = item.Id;
                                    string[] arr = { "Yuvarlama", "UpdatetedIndex","Mahsup","AboneNo" };
                                    var updateRes = _invoiceManager.PatchUpdate(new MODEL.Dtos.Muhasebe.FaturaUpdateDto {
                                        Fatura=item,
                                        UpdateColumns = arr
                                    });

                                    if(updateRes.Result.Success)
                                        MyConsole.Success(new ConsoleInputModel
                                            {
                                                Text = DateTime.Now.ToString(),
                                                Length = 20
                                            }, new ConsoleInputModel
                                            {
                                                Text = "INVOICE SAVE SUCCESS",
                                                Length = 20
                                            }, new ConsoleInputModel
                                            {
                                                Text = "GÖNDEREN",
                                                Length = 10
                                            }, new ConsoleInputModel
                                            {
                                                Text = item.GonderenUnvan,
                                                Length = 25
                                            }, new ConsoleInputModel
                                            {
                                                Text = "ABONE/HIZMET/TESIRAT NO",
                                                Length = 25
                                            }, new ConsoleInputModel
                                            {
                                                Text = resultXML.Data.ToString(),
                                                Length = 20
                                            }
                                        );
                                    else
                                        MyConsole.Danger(new ConsoleInputModel
                                        {
                                            Text = DateTime.Now.ToString(),
                                            Length = 20
                                        }, new ConsoleInputModel
                                        {
                                            Text = "INVOICE SAVE DANGER",
                                            Length = 20
                                        }, new ConsoleInputModel
                                        {
                                            Text = "GÖNDEREN",
                                            Length = 10
                                        }, new ConsoleInputModel
                                        {
                                            Text = item.GonderenUnvan,
                                            Length = 25
                                        }, new ConsoleInputModel
                                        {
                                            Text = "ABONE/HIZMET/TESIRAT NO",
                                            Length = 25
                                        }, new ConsoleInputModel
                                        {
                                            Text = resultXML.Data.ToString(),
                                            Length = 20
                                        }, new ConsoleInputModel
                                        {
                                            Text = "ERROR MESSAGE",
                                            Length = 14
                                        }, new ConsoleInputModel
                                        {
                                            Text = updateRes.Result.Message,
                                            Length = 30
                                        }

                                        );



                                }

                            }

                        }
                        else
                        {
                            MyConsole.Error(new ConsoleInputModel
                            {
                                Text = DateTime.Now.ToString(),
                                Length = 20
                            }, new ConsoleInputModel
                            {
                                Text = "SESSION ERROR",
                                Length = 20
                            }, new ConsoleInputModel
                            {
                                Text = loginResult.Message,
                                Length = 35
                            });

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyConsole.Error(new ConsoleInputModel
                {
                    Text = DateTime.Now.ToString(),
                    Length = 20
                }, new ConsoleInputModel
                {
                    Text = "EXCEPTION ERROR",
                    Length = 20
                }, new ConsoleInputModel
                {
                    Text = ex.Message,
                    Length = 200
                },new ConsoleInputModel
                {
                    Text = ex.StackTrace.ToString(),
                    Length = 200
                }, new ConsoleInputModel
                {
                    Text = ex.InnerException != null? ex.InnerException.Message:"",
                    Length = 200
                }, new ConsoleInputModel
                {
                    Text = ex.InnerException != null ? ex.InnerException.Source.ToString():"",
                    Length = 200
                }
                );
            }
            

        }

    }  
}



