using HANEL.MODEL.DataTransferModels.Accounting;
using HANEL.MODEL.Dtos.Muhasebe;
using HANEL.MODEL.Entities.Muhasebe;
using KARYA.CORE.Abstract;
using KARYA.CORE.Types.Return.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Accounting
{
    public interface IInvoiceManager : IBaseManager<Fatura>
    {
        Task<IDataResult<int>> CountInvoices(string vknNo);
        Task<IDataResult<Fatura>> GetById(string guid);
        Task<IResult> PatchUpdate(FaturaUpdateDto faturaUpdateDto);
        //Task<IDataResult<FaturaDto>> GetByGuidForSave(string guid);
        Task<IDataResult<IEnumerable<Fatura>>> GetList(InvoiceFilterModel invoiceFilterModel);

    }
}
