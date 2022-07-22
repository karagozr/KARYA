using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.CORE.Entities.Enum
{
    public enum ResultCode:int
    {
        [Description("")]
        DEFAULT = 0,
        
        [Description("Başarılı")]
        SUCCESS = 200,

        [Description("Hata")]
        ERROR = 400,
        /// <summary>
        /// Fatura Kayıt durum kodları kodları
        /// 220 - 230 arası kodlar
        /// </summary>

        [Description("Fatura kaydı başarılı")]
        SUCCESS_INVOICE_SAVED = 201,
        
        [Description("Fatura bulunamadı")]
        ERROR_INVOICE_NOT_FOUND = 404,

        [Description("Bu fatura daha önce kaydedilmiş")]
        ERROR_INVOICE_HAS_SAVED = 409,

        [Description("Fatura dip tutar tutmamamkta")]
        ERROR_INVOICE_SUMMARY_NOT_CORRECT = 453,

        [Description("Fatura vergi tutarı tutmamamkta")]
        ERROR_INVOICE_TAX_SUM_NOT_CORRECT = 454
    }
}
