using KARYA.CORE.Abstarct;
using KARYA.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.DATAACCESS.Abstract
{
    public interface IBaseDal<TEntity> : IRepository<TEntity> where TEntity:CoreEntity
    {

    }
}
