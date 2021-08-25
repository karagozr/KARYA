using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.InnovaApp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.InnovaApp
{
    public interface IStokManager
    {
        Task<IDataResult<IEnumerable<Stok>>> List(string stokKodu = null, string stokAdi = null, string kod1 = null, string kod2 = null, string kod3 = null, string kod4=null);

        Task<IDataResult<Stok>> GetFromStokKod(string stokKodu);
    }
}
