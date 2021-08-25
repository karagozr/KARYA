using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.Netsis;
using NetOpenX.Rest.Client;
using NetOpenX.Rest.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Accounting.Netsis
{
    public class NetOpenXAuth : IDisposable
    {
        public oAuth2 AUTH;
     
        public async Task<IResult> Login(Login loginModel)
        {
            try
            {
                AUTH = new oAuth2(loginModel.NetOpenXUrl, 120);

                await AUTH.LoginAsync(new JLogin()
                {
                    BranchCode = loginModel.BranchCode,
                    NetsisUser = loginModel.NetsisUser,
                    NetsisPassword = loginModel.NetsisPassword,
                    DbType = JNVTTipi.vtMSSQL,
                    DbName = loginModel.DbName,
                    DbPassword = "",
                    DbUser = "TEMELSET"
                });

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

        }
        public virtual void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }
}
