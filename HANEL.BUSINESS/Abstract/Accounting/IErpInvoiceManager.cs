using HANEL.MODEL.DataTransferModels.Accounting;
using HANEL.MODEL.Dtos.Muhasebe;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.Netsis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Accounting
{
    public interface IErpInvoiceManager
    {
        Task<IDataResult<FaturaDto>> CheckInvoice(string guid);
        Task<IDataResult<FaturaDto>> GetInvoice(string guid);
        Task<IDataResult<IEnumerable<FaturaDto>>> ListInvoice(InvoiceFilterModel invoiceFilterModel);
        Task<IDataResult<string>> SaveInvoice(FaturaDto invoice, Login login = null);
        Task<IResult> DeleteInvoice(string faturaNo, string cariKodu, Login login = null);
        Task<IDataResult<YevmiyeFisInfo>> GetYevmiyeFis(string faturaNo, short faturaIrsaliye, string cariKodu);

    }
}
