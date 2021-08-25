using HANEL.MODEL.DataTransferModels.EServisEntegrator;
using HANEL.MODEL.Entities.Muhasebe;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.SERVICE.EINVOICE.Abstract
{
    public interface IIncomingInvoiceUtility:IDisposable
    {
        Task<IDataResult<string>> GetInvoiceDocument(FaturaFiltreModel faturaFiltreModel);
        Task<IDataResult<Fatura>> GetInvoice(FaturaFiltreModel faturaFiltreModel);
        Task<IDataResult<IEnumerable<Fatura>>> ListInvoiceWithDetail(FaturaFiltreModel faturaFiltreModel);
    }
}
