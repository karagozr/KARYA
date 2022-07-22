using HANEL.BUSINESS.Abstract.Accounting;
using HANEL.MODEL.DataTransferModels.Accounting;
using HANEL.MODEL.DataTransferModels.EServisEntegrator;
using HANEL.MODEL.Dtos.Muhasebe;
using HANEL.MODEL.Entities.Muhasebe;
using HANEL.MODEL.Module;
using HANEL.SERVICE.EINVOICE.Concrete.EFinansService;
using KARYA.COMMON.Attributes;
using KARYA.COMMON.DirectoryAndFileHelpers;
using KARYA.CORE.API.Controllers;
using KARYA.CORE.Entities.Enum;
using KARYA.CORE.Types.Api;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.API.REST.Controllers.Accounting.v1
{
    [Route("api/v1/Account/Invoice")]
    public class InvoiceController : BaseController
    {
        IInvoiceManager _invoiceManager;
        ICariManager _cariManager;
        IErpInvoiceManager _erpInvoiceManager;
        IConfiguration _configuration;

        public InvoiceController(IErpInvoiceManager erpInvoiceManager, IInvoiceManager invoiceManager, ICariManager cariManager, IConfiguration configuration)
        {
            _cariManager = cariManager;
            _invoiceManager = invoiceManager;
            _erpInvoiceManager = erpInvoiceManager;
            _configuration = configuration;

        }

        [HttpPost("List")]
        [KaryaAuthorize(Role = HanelRole.InvoiceIntegPanel)]
        public async Task<IActionResult> List(InvoiceFilterModel invoiceFilterModel)
        {
            if (invoiceFilterModel.IncomeFirstDate != null && invoiceFilterModel.IncomeFirstDate.Value.Hour == 21) invoiceFilterModel.IncomeFirstDate = Convert.ToDateTime(invoiceFilterModel.IncomeFirstDate).AddHours(3);
            if (invoiceFilterModel.IncomeLastDate != null && invoiceFilterModel.IncomeLastDate.Value.Hour == 21) invoiceFilterModel.IncomeLastDate = Convert.ToDateTime(invoiceFilterModel.IncomeLastDate).AddHours(3);
            if (invoiceFilterModel.FirstDate != null && invoiceFilterModel.FirstDate.Value.Hour == 21) invoiceFilterModel.FirstDate = Convert.ToDateTime(invoiceFilterModel.FirstDate).AddHours(3);
            if (invoiceFilterModel.LastDate != null && invoiceFilterModel.LastDate.Value.Hour == 21) invoiceFilterModel.LastDate = Convert.ToDateTime(invoiceFilterModel.LastDate).AddHours(3);
            var result = await _erpInvoiceManager.ListInvoice(invoiceFilterModel);

            if (result.Success) return Ok(result.Data);
            else return BadRequest(result.Message);
        }

        [HttpPatch("Update/{id:int}")]
        [KaryaAuthorize(Role = HanelRole.InvoiceIntegUpdate)]
        public async Task<IActionResult> Update(int id, [FromBody] JsonPatchDocument<Fatura> faturaUpdate)
        {
            var resultEntity = await _invoiceManager.GetById(id);
            faturaUpdate.ApplyTo(resultEntity.Data, ModelState);
            var result = await _invoiceManager.PatchUpdate(new FaturaUpdateDto { Fatura = resultEntity.Data, UpdateColumns = faturaUpdate.Operations.Select(x => char.ToUpper(x.path[0]) + x.path.Substring(1)).ToArray() });

            return Ok();

            //if (result.Success) return Ok(faturaUpdateDto);
            //else return BadRequest(result.Message);
        }

        [HttpGet("GetDocument")]
        [KaryaAuthorize(Role = HanelRole.InvoiceIntegPreview)]
        public async Task<IActionResult> GetDocument(string ett, string belgeTuru, bool isString = false)
        {
            var resultInvoice = await _invoiceManager.GetById(ett);
            var invoice = resultInvoice.Data;

            if (invoice == null) return BadRequest("Fatura Sistemde Yok");

            if (!resultInvoice.Success) return BadRequest(resultInvoice.Message);

            var checkFile = DirectoryHelper.CheckLocalData(ett + "." + belgeTuru, "Invoices");
            if (checkFile.Success == true)
            {
                if (isString)
                    using (StreamReader sr = new StreamReader(checkFile.Data, Encoding.Default))
                    {
                        string resultTExt = "";
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            resultTExt += s;
                        }

                        return Ok(resultTExt);
                    }
                var stream = new FileStream($"{checkFile.Data}", FileMode.Open);
                return new FileStreamResult(stream, belgeTuru.ToLower() == "pdf" ? "application/pdf" : "text/html");
            }

            using (var serviceAuthUtility = new EFinansAuthServiceUtility())
            {
                var loginResult = await serviceAuthUtility.Login(
                    new EntegratorLoginModel
                    {
                        UserName = _configuration["EInvoiceService:Username"],
                        Password = _configuration["EInvoiceService:Password"],
                        Language = _configuration["EInvoiceService:Language"]
                    });
                if (!loginResult.Success) return BadRequest(loginResult.Message);

                using (var gelen = new EFinansIncommingInvoiceUtility())
                {
                    var resultInvoiceDoc = await gelen.GetInvoiceDocument(new FaturaFiltreModel
                    {
                        Guid = invoice.Guid,
                        BelgeTipi = invoice.BelgeTipi,
                        BelgeFormati = belgeTuru,
                        VergiNo = invoice.AlanVkn
                    });

                    if (!resultInvoiceDoc.Success) BadRequest(resultInvoiceDoc.Message);
                    try
                    {
                        if (isString)
                            using (StreamReader sr = new StreamReader(resultInvoiceDoc.Data, Encoding.Default))
                            {
                                string resultTExt = "";
                                string s = "";
                                while ((s = sr.ReadLine()) != null)
                                {
                                    resultTExt += s;
                                }

                                return Ok(resultTExt);
                            }

                        var stream = new FileStream($"{resultInvoiceDoc.Data}", FileMode.Open);
                        return new FileStreamResult(stream, belgeTuru.ToLower() == "pdf" ? "application/pdf" : "text/html");
                    }
                    catch (Exception ex)
                    {
                        return Ok("");
                        throw;
                    }


                }
            }
        }

        [HttpGet("DownloadInvoice")]
        [KaryaAuthorize(Role = HanelRole.InvoiceIntegPanel)]
        public async Task<IActionResult> DownloadInvoice(string ett, string belgeTuru)
        {
            //Dosya yerelde kayıtlıysa
            var checkFile = DirectoryHelper.CheckLocalData(ett + "." + belgeTuru, "Invoices");
            if (checkFile.Success == true)
            {
                var stream = new FileStream($"{checkFile.Data}", FileMode.Open);
                return File(stream, belgeTuru.ToLower() == "pdf" ? "application/pdf" : "text/html", ett + "." + belgeTuru);
            }

            //html kayıtlı olup pdf kayıtlı değilse
            var checkFile1 = DirectoryHelper.CheckLocalData(ett + ".html", "Invoices");
            if (checkFile1.Success == true)
            {
                if (belgeTuru.ToLower() == "pdf")
                {
                    using (StreamReader sr = new StreamReader(checkFile1.Data, Encoding.Default))
                    {
                        string resultTExt = "";
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            resultTExt += s;
                        }

                        DocumentHelper.HtmltoPdf(resultTExt, DirectoryHelper.GetLocalDataPath("Invoices") + ett);
                    }
                }
                var stream = new FileStream($"{DirectoryHelper.GetLocalDataPath("Invoices") + ett}.pdf", FileMode.Open);
                return File(stream, belgeTuru.ToLower() == "pdf" ? "application/pdf" : "text/html", ett + "." + belgeTuru);
            }

            //yerelde yoksa kaydı ara
            var resultInvoice = await _invoiceManager.GetById(ett);
            var invoice = resultInvoice.Data;

            if (invoice == null) return BadRequest("Fatura Sistemde Yok");

            if (!resultInvoice.Success) return BadRequest(resultInvoice.Message);


            using (var serviceAuthUtility = new EFinansAuthServiceUtility())
            {
                var loginResult = await serviceAuthUtility.Login(
                    new EntegratorLoginModel
                    {
                        UserName = _configuration["EInvoiceService:Username"],
                        Password = _configuration["EInvoiceService:Password"],
                        Language = _configuration["EInvoiceService:Language"]
                    });
                if (!loginResult.Success) return BadRequest(loginResult.Message);

                using (var gelen = new EFinansIncommingInvoiceUtility())
                {
                    var resultInvoiceDoc = await gelen.GetInvoiceDocument(new FaturaFiltreModel
                    {
                        Guid = invoice.Guid,
                        BelgeTipi = invoice.BelgeTipi,
                        BelgeFormati = "html",
                        VergiNo = invoice.AlanVkn
                    });

                    if (!resultInvoiceDoc.Success) BadRequest(resultInvoiceDoc.Message);
                    try
                    {
                        if (belgeTuru.ToLower() == "pdf")
                        {
                            using (StreamReader sr = new StreamReader(resultInvoiceDoc.Data, Encoding.Default))
                            {
                                string resultTExt = "";
                                string s = "";
                                while ((s = sr.ReadLine()) != null)
                                {
                                    resultTExt += s;
                                }

                                DocumentHelper.HtmltoPdf(resultTExt, DirectoryHelper.GetLocalDataPath("Invoices") + ett);
                            }
                        }


                        var stream = new FileStream($"{DirectoryHelper.GetLocalDataPath("Invoices") + ett + "." + belgeTuru}", FileMode.Open);
                        return File(stream, belgeTuru.ToLower() == "pdf" ? "application/pdf" : "text/html", ett + "." + belgeTuru);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }


                }
            }
        }

        [HttpGet("GetInvoice")]
        [KaryaAuthorize(Role = HanelRole.InvoiceIntegEdit)]
        public async Task<IActionResult> GetInvoice(string ett)
        {
            var result = await _erpInvoiceManager.GetInvoice(ett);

            if (result.Success) return Ok(result.Data);
            else return BadRequest(result.Message);

        }

        [HttpPost("SaveInvoice")]
        [KaryaAuthorize(Role = HanelRole.InvoiceIntegEdit)]
        public async Task<IActionResult> SaveInvoice(FaturaDto invoice)
        {
            var result = await _erpInvoiceManager.SaveInvoice(invoice);
            if (result.Success)
            {
                if (invoice.ReturnYevmiyeFisi == true)
                {
                    var yemiyeFis = await _erpInvoiceManager.GetYevmiyeFis(result.Data, 2, invoice.CariKodu);
                    return ApiResult<dynamic>(ResultCode.SUCCESS_INVOICE_SAVED,result.Message,
                        new
                        {
                            YevmiyeFisi = yemiyeFis.Data.YevmiyeFisList,
                            FaturaNo = result.Data,
                            CariKodu = invoice.CariKodu,
                            FisNo = yemiyeFis.Data.FisNo,
                            BranchCode = yemiyeFis.Data.BranchCode,
                            BranchName = yemiyeFis.Data.BranchName,
                            FirmCode = yemiyeFis.Data.FirmCode,
                            FirmName = yemiyeFis.Data.FirmName
                        });
                }

                return ApiResult(ResultCode.SUCCESS_INVOICE_SAVED, result.Message);


            }else if (!result.Success && result.Code == ResultCode.DEFAULT)
            {
                return BadRequest(result.Message);
            }
            else if (!result.Success)
            {
                return ApiResult(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetYevmiyeFisi")]
        [KaryaAuthorize(Role = HanelRole.InvoiceIntegYevmiyeFisPreview)]
        public async Task<IActionResult> GetYevmiyeFisi(string faturaNo, string cariKodu)
        {
            var result = await _erpInvoiceManager.GetYevmiyeFis(faturaNo, 2, cariKodu);
            if (result.Success) return Ok(new { YevmiyeFisi = result.Data.YevmiyeFisList, FaturaNo = faturaNo, CariKodu = cariKodu, FisNo = result.Data.FisNo, BranchCode = result.Data.BranchCode, BranchName = result.Data.BranchName, FirmCode = result.Data.FirmCode, FirmName = result.Data.FirmName });
            else return BadRequest(result.Message);
        }

        [HttpGet("GetInvoicePreview")]
        [KaryaAuthorize(Role = HanelRole.InvoiceIntegPreview)]
        public async Task<IActionResult> GetInvoicePreview(string faturaNo, string cariKodu)
        {
            if (string.IsNullOrEmpty(faturaNo) || string.IsNullOrEmpty(cariKodu)) return BadRequest();

            var resultCari = await _cariManager.GetById(cariKodu);
            if (!resultCari.Success) return BadRequest(resultCari.Message);

            var yemiyeFis = await _erpInvoiceManager.GetYevmiyeFis(faturaNo, 2, cariKodu);
            if (!yemiyeFis.Success) return BadRequest(yemiyeFis.Message);

            var headers = new Dictionary<string, string>();
            headers.Add("Şube   ", $"{yemiyeFis.Data.BranchName}-({yemiyeFis.Data.BranchCode})");
            headers.Add("Fiş No ", yemiyeFis.Data.FisNo);
            //headers.Add("Fatura No ", faturaNo);
            //headers.Add("Cari Ünvan ", $"{resultCari.Data.CariUnvan}-({cariKodu})");
            //headers.Add("Şirket", $"{yemiyeFis.Data.FirmName}-({yemiyeFis.Data.FirmCode})");

            headers.Add("Tarih ", DateTime.Today.ToShortDateString());
            string[] columns = { "Hesap Kodu", "Hesap Adı", "Acıklama", "Borç", "Alacak", "Proje", "Referans", "Açıklama-1", "Açıklama-2" };
            string[] protectedColumns = { "Hesap Kodu" };
            var stream = DocumentHelper.PdfCreatorWithObjectList(yemiyeFis.Data.YevmiyeFisList.Select(x => new
            { x.HesapKodu, x.HesapAdi, x.Aciklama, x.Borc, x.Alacak, x.ProjeAdi, x.ReferansAdi, x.Aciklama2, x.Aciklama3, summ = x.HesapKodu.Length <= 5 || x.HesapKodu.Length == 0 ? true : false }),
                            columns, "YEVMİYE FİŞİ", 6, protectedColumns, headers);


            return File(stream.ToArray(), "application/pdf", "blabla.pdf");

        }

        [HttpGet("Test")]
        public async Task<IActionResult> Test(string value)
        {
            var ll = new List<FaturaDto>();
            ll.Add(new FaturaDto
            {
                AboneNo = "sadasdsa"
            });

            ll.Add(new FaturaDto
            {
                AboneNo = "dasdsadsadsadsad"
            });

            return ApiResult<IList<FaturaDto>>(ResultCode.ERROR_INVOICE_NOT_FOUND,ll);
        } 
    }
}
