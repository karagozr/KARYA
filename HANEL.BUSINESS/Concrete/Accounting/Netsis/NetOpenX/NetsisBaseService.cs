using KARYA.MODEL.Entities.Netsis;
using NetOpenX.Rest.Client;
using NetOpenX.Rest.Client.Model;
using System;

namespace HANEL.BUSINESS.Concrete.Accounting.Netsis.NetOpenX
{
    public abstract class NetsisBaseService : IDisposable
    {
        public oAuth2 AUTH;
        public NetsisBaseService(Login loginModel)
        {
            //"http://192.168.7.23:7070"
            var authService = new NetsisAuthService(loginModel.NetOpenXUrl);

            var loginResult = authService.Login(new JLogin()
            {
                BranchCode = loginModel.BranchCode,
                NetsisUser = loginModel.NetsisUser,
                NetsisPassword = loginModel.NetsisPassword,
                DbType = JNVTTipi.vtMSSQL,
                DbName = loginModel.DbName,
                DbPassword = "",
                DbUser = "TEMELSET"
            }).Result;

            if (loginResult.Success)
            {
                AUTH = authService.AUTH;
            }
                
        }

        public virtual void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }
}
