using HANEL.MODEL.Dto.Muhasebe;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Accounting
{
    public interface IMuhasebeManager
    {
        Task<IDataResult<IEnumerable<MuhasebeReferansDto>>> ListMuhReferans(string referansKodu = null);
        Task<IDataResult<IEnumerable<MuhasebePlanDto>>> ListMuhHesap(string hesapKodu = null);
    }
}
