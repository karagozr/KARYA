using HANEL.MODEL.Dto.Muhasebe;
using HANEL.MODEL.Entities.Muhasebe;
using KARYA.CORE.Abstract;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Accounting
{
    public interface ICariManager
    {
        Task<IDataResult<IEnumerable<CariDto>>> List(string cariKodu=null);

        Task<IDataResult<CariDto>> GetFromVkn(string vkn);

        Task<IDataResult<CariDto>> GetById(string cariKodu);

    }
}
