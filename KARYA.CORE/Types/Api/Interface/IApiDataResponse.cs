using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.CORE.Types.Api.Interface
{
    public interface IApiDataResponse<TData>:IApiResponse
    {
        TData Data { get; }
    }
}
