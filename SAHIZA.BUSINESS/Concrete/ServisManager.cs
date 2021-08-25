using KARYA.CORE.Concrete.EntityFramework;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using SAHIZA.BUSINESS.Abstarct;
using SAHIZA.DATAACCESS.Abstarct;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAHIZA.BUSINESS.Concrete
{
    public class ServisManager : BaseManager<Servis>, IServisManager 
    { 
        IServisDal _servisDal;
        public ServisManager(IServisDal servisDal) : base(servisDal) => _servisDal = servisDal;

        public async Task<IDataResult<IEnumerable<ServisListDto>>> List(ServisFiltreDto servisFiltreDto)
        {
            try
            {
                var result = await _servisDal.List(null);
               
                return new SuccessDataResult<IEnumerable<ServisListDto>> (result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<ServisListDto>>(ex.Message);
            }
        }
    }
}
