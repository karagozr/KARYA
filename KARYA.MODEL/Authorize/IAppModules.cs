using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.Authorize
{
    public interface IAppModules:IDisposable
    {
        IList<AppModule> ModuleList { get; set; }
    }
}
