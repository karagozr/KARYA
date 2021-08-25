using KARYA.BUSINESS.Abstract.Karya;
using KARYA.BUSINESS.Concrete.Base;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Abstract.App;
using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.Karya
{
    public class AppParameterManager : BaseManager<AppParameter>, IAppParameterManager
    {
        IAppParameterDal _appParameterDal;
        public AppParameterManager(IAppParameterDal appParameterDal) : base(appParameterDal)
        {
            _appParameterDal = appParameterDal;
        }

        public async Task<IDataResult<AppParameter>> GetParameters(string groupName)
        {
            try
            {
                var result = await _appParameterDal.Get(x => x.GroupName == groupName);

                return new SuccessDataResult<AppParameter>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<AppParameter>(null, ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<AppParameter>>> GetParameter(string groupName, string name)
        {
            try
            {
                var result = await _appParameterDal.List(x => x.Name == name && x.GroupName == groupName);

                return new SuccessDataResult<IEnumerable<AppParameter>>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<AppParameter>>(null, ex.Message);
            }
        }
    }
}
