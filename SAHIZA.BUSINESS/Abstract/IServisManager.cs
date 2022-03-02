using KARYA.CORE.Abstract;
using KARYA.CORE.Types.Return.Interfaces;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAHIZA.BUSINESS.Abstarct
{
    public interface IServisManager : IBaseManager<Servis>
    {
        Task<IDataResult<ServisDto>> GetBakimById(int id);
        Task<IDataResult<IEnumerable<ServisListDto>>> List(ServisFiltreDto servisFiltreDto);
        Task<IResult> AddUpdateBakim(ServisDto servisDto);
    }
}
