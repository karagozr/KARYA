using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.Module
{
    public interface ICoreModules
    {
        IList<AppModule> ModuleList { get; set; }
    }
}
