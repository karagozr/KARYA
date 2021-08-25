using HANEL.MODEL.DataTransferModels.EServisEntegrator;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.SERVICE.EINVOICE.Abstract
{
    public interface IServiceAuthUtility : IDisposable
    {
        Task<IResult> Login(EntegratorLoginModel entegratorLoginModel);
        Task<IResult> Logout();
    }
}
