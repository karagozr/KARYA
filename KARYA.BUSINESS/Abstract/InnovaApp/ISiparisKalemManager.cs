using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.InnovaApp;
using KARYA.MODEL.Entities.InnovaApp.Mobilya;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.InnovaApp
{
    public interface ISiparisKalemManager
    {
        Task<IResult> AddSiparisKalem(IEnumerable<SiparisKalem> siparisKalems);
    }
}
