using KARYA.CORE.Abstract;
using KARYA.CORE.Types.Return.Interfaces;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using System.Threading.Tasks;

namespace SAHIZA.BUSINESS.Abstarct
{
    public interface IDizaynManager : IBaseManager<Dizayn>
    {
        Task<IResult> AddUpdateComplex(DizaynDto dizaynDto);

        Task<IDataResult<DizaynDto>> GetByIdWithDetay(int id);

        Task<IDataResult<DizaynBelgeDto>> GetByIdForNewBelge(int id);
    }
}
