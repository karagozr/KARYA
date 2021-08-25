using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Finance
{
    public interface INakitAkisManager
    {
        Task<IDataResult<IEnumerable<dynamic>>> List();
    }
}
