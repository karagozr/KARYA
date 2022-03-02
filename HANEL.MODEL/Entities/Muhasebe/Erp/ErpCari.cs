using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Entities.Muhasebe.Erp
{
    public class ErpCari
    {
        public string Id { get; set; } //CARI_KOD = "CARI001",
        public string Name { get; set; }// CARI_ISIM = "Rest Cari",
        public string CariType { get; set; }            //CARI_TIP = "S",
        public string BranchCode { get; set; }            //Sube_Kodu = 0,
        public string Description1 { get; set; }            // ACIK1 = "acik1",
        public string Description2 { get; set; }            // ACIK2 = "acik2",
        public string Description3 { get; set; }            // ACIK3 = "acik3",
        public string Adress { get; set; }            // CARI_ADRES = "izmir",
        public string City{ get; set; }            // CARI_IL = "izmir",
        public string District { get; set; }            // CARI_TEL = "2322225566",
        public string PhoneNo { get; set; }            // CARI_ILCE = "ksk",
        public string EMail { get; set; }            // EMAIL = "netopenx@logo.com.tr",
        public string Web { get; set; }            // WEB = "www.logo.com.tr",
        public string RecordDate { get; set; }            //CM_RAP_TARIH = DateTime.Now
        public string IdNumber { get; set; }
        public string TaxRoom { get; set; }
        public string TaxNumber { get; set; }
    }
}
