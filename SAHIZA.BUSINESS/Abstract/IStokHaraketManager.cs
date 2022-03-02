using KARYA.CORE.Abstract;
using KARYA.CORE.Types.Return.Interfaces;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAHIZA.BUSINESS.Abstarct
{
    public interface IStokHaraketManager : IBaseManager<StokHaraket>
    {
        Task<IDataResult<IEnumerable<StokRaporDto>>> StokRaporList(StokFilterDto stokFilterDto);
    }
}
