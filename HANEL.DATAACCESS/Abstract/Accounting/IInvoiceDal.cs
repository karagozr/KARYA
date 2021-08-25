using HANEL.MODEL.DataTransferModels.Accounting;
using HANEL.MODEL.Entities.Muhasebe;
using KARYA.CORE.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.DATAACCESS.Abstract.Accounting
{
    public interface IInvoiceDal: IBaseDal<Fatura>
    {
        Task<IEnumerable<Fatura>> List(InvoiceFilterModel invoiceFilterModel);

        Task<Fatura> GetWithDetail(InvoiceFilterModel invoiceFilterModel);
    }
}
