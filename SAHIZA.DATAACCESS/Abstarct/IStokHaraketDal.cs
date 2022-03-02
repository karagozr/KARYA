using KARYA.CORE.Abstract;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SAHIZA.DATAACCESS.Abstract
{
    public interface IStokHaraketDal : IBaseDal<StokHaraket>
    {
        Task<IEnumerable<StokRaporDto>> ListStokKalan(Expression<Func<StokHaraket, bool>> filter);
    }
}
