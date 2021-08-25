using HANEL.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.DataTransferModels.Accounting
{
    public class InvoiceFilterModel
    {
        public DateTime? FirstDate { get; set; }
        public DateTime? LastDate { get; set; }
        public DateTime? IncomeFirstDate { get; set; }
        public DateTime? IncomeLastDate { get; set; }
        public string CompanyVkn { get; set; }
        public string SenderVkn { get; set; }
        public string SenderName { get; set; }
        public string Ett { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }

    }
}
