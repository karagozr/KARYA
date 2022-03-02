using KARYA.COMMON.DirectoryAndFileHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace InvoiceDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public async Task DownloadInvoice(string ett, string belgeTuru)
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
