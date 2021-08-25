using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.InnovaApp.Mobilya;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.InnovaApp
{
    public interface IReceteManager
    {
        Task<IDataResult<string>> ReceteOlustur(string stokKodu);
        Task<IDataResult<IEnumerable<Recete>>> ReceteGetir(string guidId);
        Task<IDataResult<IEnumerable<ReceteStok>>> ReceteStokGetir(int ozellikId);
        Task<IResult> ReceteStokUpdate(int id, string stokKodu);
    }
}
