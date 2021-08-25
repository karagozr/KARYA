using KARYA.CORE.Abstract;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SAHIZA.DATAACCESS.Abstarct
{
    public interface IServisDal : IBaseDal<Servis>
    {
        Task<IEnumerable<ServisListDto>> List(Expression<Func<Servis, bool>> filter);
    }
}
