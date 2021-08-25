using KARYA.CORE.Abstract;
using KARYA.CORE.Types.Return.Interfaces;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using System.Threading.Tasks;

namespace SAHIZA.BUSINESS.Abstarct
{
    public interface IBelgeManager : IBaseManager<Belge>
    {
        Task<IResult> AddUpdateComplex(DizaynBelgeDto dizaynDto);

        Task<IDataResult<DizaynBelgeDto>> GetByIdWithDetay(int id);
    }
}
