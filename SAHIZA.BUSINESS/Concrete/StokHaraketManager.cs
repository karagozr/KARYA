using KARYA.CORE.Concrete.EntityFramework;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using SAHIZA.BUSINESS.Abstarct;
using SAHIZA.DATAACCESS.Abstract;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAHIZA.BUSINESS.Concrete
{
    public class StokHaraketManager : BaseManager<StokHaraket>, IStokHaraketManager 
    { 
        IStokHaraketDal _stokHaraketDal;
        public StokHaraketManager(IStokHaraketDal stokHaraketDal) : base(stokHaraketDal) => _stokHaraketDal = stokHaraketDal;

        public async Task<IDataResult<IEnumerable<StokRaporDto>>> StokRaporList(StokFilterDto stokFilterDto=null)
        {
            try
            {
                var result = await _stokHaraketDal.ListStokKalan(null);
                return new SuccessDataResult<IEnumerable<StokRaporDto>>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<StokRaporDto>>(ex.Message);
            }
        }
    }
}
