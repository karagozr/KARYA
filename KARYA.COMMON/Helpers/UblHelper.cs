using KARYA.COMMON.XmlModels.EFinansXml.EFATURA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using UblSharp;

namespace KARYA.COMMON.Helpers
{
    public static class UblHelper
    {
        public static fatura LoadAndValidateInvoice(string xmlString)
        {
            using (var xmlReader = XmlReader.Create(new StringReader(xmlString))) 
            {
                XmlSerializer xs = new XmlSerializer(typeof(fatura));

                try
                {
                    return (fatura)xs.Deserialize(xmlReader);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Deserialize: " + ex.Message);
                    return null;
                }
            } 
            //if (!ValidateUblInvoiceDocument(xmlInvoice, invoiceSchemaSet))
            //{
            //    Console.WriteLine("Invalid ubl invoice document, but I will try and read it anyway...");
            //}

            
        }

        private static bool ValidateUblInvoiceDocument(XDocument ublDocument, XmlSchemaSet invoiceSchemaSet)
        {
            bool res = false;

            try
            {
                invoiceSchemaSet = CreateInvoiceValidationSchemaSet();
                System.Xml.Schema.Extensions.Validate(ublDocument, invoiceSchemaSet, null, false);
                res = true;
            }
            catch (XmlSchemaValidationException ex)
            {
                Console.WriteLine("Validation: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Validation: Unknown error. " + ex.Message);
            }

            return res;
        }

        public static XmlSchemaSet CreateInvoiceValidationSchemaSet()
        {
            string ublXsdDir = @"..\..\..\";
            string preloadToAvoidExceptionFilename = Path.Combine(ublXsdDir, @"fatura.xsd");
            string invoiceSchemaFilename = Path.Combine(ublXsdDir, @"fatura.xsd");

            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.ValidationEventHandler += (s, e) =>
            {
                Console.WriteLine("<>XmlSchemaSet: {0}: {1}", e.Severity.ToString(), e.Message);
            };

            ValidationEventHandler valHandler = (s, e) =>
            {
                Console.WriteLine("XmlTextReader: {0}: {1}", e.Severity.ToString(), e.Message);
            };

            using (XmlTextReader tr = new XmlTextReader(preloadToAvoidExceptionFilename))
            {
                schemaSet.Add(XmlSchema.Read(tr, valHandler));
            }

            using (XmlTextReader tr = new XmlTextReader(invoiceSchemaFilename))
            {
                schemaSet.Add(XmlSchema.Read(tr, valHandler));
            }
            schemaSet.Compile();
            return schemaSet;
        }
    }
}
