using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Dtos.AuthGroup;
using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract
{
    public interface IAuthGroupManager
    {
        Task<IDataResult<IEnumerable<AuthGroupLDto>>> List();
        Task<IDataResult<AuthGroupSDto>> GetWithDetail(int Id);
        Task<IResult> Edit(AuthGroupSDto authGroupSDto);
    }
}
