using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using NetOpenX.Rest.Client;
using NetOpenX.Rest.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Accounting.Netsis.NetOpenX
{
    public class NetsisAuthService:IDisposable
    {
        string _restUrl;
        public NetsisAuthService(string restUrl)
        {
            _restUrl = restUrl;
        }
        public oAuth2 AUTH;
        public async Task<IResult> Login(JLogin loginModel)
        {
            try
            {
                AUTH = new oAuth2(_restUrl,120);

                await AUTH.LoginAsync(loginModel);

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
