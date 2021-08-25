using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.COMMON.DirectoryAndFileHelpers
{
    public static class DocumentHelper
    {
        public static MemoryStream PdfCreatorWithObjectList<TObject>(IEnumerable<TObject> list,  string[] columns, string headerText,   
            short fontSize = 10, string[] protectedColumns=null, Dictionary<string,string> headerValues = null, 
            IEnumerable<TObject> summaryRows = null) where TObject:class
        {
            using (MemoryStream stream = new MemoryStream())
            {
                var colCount = columns.Length;
                Document pdfDoc = new Document(PageSize.A4,10f,10f,30f,30f);
                BaseFont STF_Helvetica_Turkish = BaseFont.CreateFont("Helvetica", "CP1254", BaseFont.NOT_EMBEDDED);

                Font fontNormal = new Font(STF_Helvetica_Turkish, fontSize, Font.NORMAL);
                Font fontCell = new Font(STF_Helvetica_Turkish, fontSize-1, Font.NORMAL);
                Font fontHeader = new Font(STF_Helvetica_Turkish, fontSize + 1, Font.NORMAL);

                PdfPTable table = new PdfPTable(colCount);
                var htmlWorker = new HTMLWorker(pdfDoc);


                table.TotalWidth = pdfDoc.PageSize.Width-40;
                table.LockedWidth = true;

                float[] widths = new float[colCount];

                float[] colMaxWidths = new float[colCount];

                for (int i = 0; i < colCount; i++) colMaxWidths[i] = 1;
                 
                for (int i = 0; i < colCount; i++)
                {
                    var headerCell = new PdfPCell(new Phrase(columns[i], fontNormal));
                    headerCell.Border = 0;
                    headerCell.BorderWidthBottom = 1f;
                    headerCell.BorderColorBottom = BaseColor.DARK_GRAY;
                    table.AddCell(headerCell);
                }

                foreach (TObject item in list)
                {
                    var prop = item.GetType().GetProperties();
                        
                    for (int i = 0; i < colCount; i++)
                    {
                        var val = item.GetType().GetProperty(prop[i].Name).GetValue(item);

                        bool isDouble = item.GetType().GetProperty(prop[i].Name).PropertyType.Name.ToLower() == "double";

                        val = val == null ? "" : val;

                        if (val.ToString().Length > colMaxWidths[i]) colMaxWidths[i] = isDouble? val.ToString().Length+5: val.ToString().Length;

                        var phrase = isDouble &&  Convert.ToDouble(val) > 0 ? 
                            new Phrase(String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", val), fontCell) :
                            new Phrase("", fontCell);

                        PdfPCell cell = isDouble ? new PdfPCell(phrase) :
                            new PdfPCell(new Phrase(val.ToString(), fontCell)

                           
                        );

                        cell.Border = 0;

                        if (Convert.ToBoolean(item.GetType().GetProperty("summ").GetValue(item))==true)
                            cell.BackgroundColor = BaseColor.LIGHT_GRAY;

                        if (isDouble) cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(cell);
                    }

                }

                float totalWidth = 0;

                for (int i = 0; i < colCount; i++) totalWidth+=colMaxWidths[i];
                float widthAverage = totalWidth/ colCount;

                for (int i = 0; i < colCount; i++)
                {
                    if (colMaxWidths[i] > widthAverage * 2.5f) colMaxWidths[i] = widthAverage * 2.5f;
                    if (colMaxWidths[i] < widthAverage * 0.5f) colMaxWidths[i] = widthAverage * 0.5f;
                    totalWidth += colMaxWidths[i];
                }

                for (int i = 0; i < colCount; i++)
                {
                    if (protectedColumns!=null&&protectedColumns.Any(x => columns[i].Contains(x)))
                        widths[i] = colMaxWidths[i]*1.45f;
                    else
                        widths[i] = table.TotalWidth * (colMaxWidths[i] / totalWidth);
                }

                table.SetWidths(widths);

                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                //htmlWorker.StartDocument();
                pdfDoc.Add(new Header("Name", "Contetnt"));

                pdfDoc.Add(new Paragraph(headerText, fontHeader) { IndentationLeft=(pdfDoc.PageSize.Width-20)/2-headerText.Length});
                if (headerValues != null)
                {
                    var maxDicValLength = headerValues.Max(x => x.Key.Length);
                    foreach (var item in headerValues)
                        pdfDoc.Add(new Paragraph(item.Key + new string(' ', 2*(maxDicValLength-item.Key.Length))+  " : " + item.Value, fontNormal) { IndentationLeft = 10 });

                }

                pdfDoc.Add(new Paragraph("  "));
                pdfDoc.Add(table);
                //StringReader sr = new StringReader(htmlBody);

                //htmlWorker.Parse(sr);
                //htmlWorker.EndDocument();
                //htmlWorker.Close();
                pdfDoc.Close();

                return stream;

            }
        }

        public static bool HtmltoPdf(string htmlString, string savePathWithName)
        {
            try
            {
                HtmlToPdf converter = new HtmlToPdf();
                converter.Options.PdfPageSize = PdfPageSize.A4;
                converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;

                SelectPdf.PdfDocument doc = converter.ConvertHtmlString(htmlString);

                doc.Save(savePathWithName + ".pdf");

                doc.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
