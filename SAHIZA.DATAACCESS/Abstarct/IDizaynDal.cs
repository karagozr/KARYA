using KARYA.CORE.Abstract;
using KARYA.CORE.Types.Return.Interfaces;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SAHIZA.DATAACCESS.Abstract
{
    public interface IDizaynDal : IBaseDal<Dizayn>
    {
        Task<DizaynDto> GetWithDetail(Expression<Func<Dizayn, bool>> filter);

        Task<DizaynBelgeDto> GetForNewBelge(Expression<Func<Dizayn, bool>> filter);
    }
}
