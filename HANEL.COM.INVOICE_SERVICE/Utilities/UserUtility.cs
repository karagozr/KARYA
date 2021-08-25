using EFinansAuthService;
using HANEL.COM.INVOICE_SERVICE.Helpers;
using HANEL.MODEL.DataTransferModels.EServisEntegrator;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static HANEL.COM.INVOICE_SERVICE.Helpers.CookieHelper;

namespace HANEL.COM.INVOICE_SERVICE.Utilities
{
    public class UserUtility : IDisposable
    {
        UserServiceClient userService;
        public UserUtility()
        {
            userService = new UserServiceClient();
        }

        public async Task<IResult> Login(EntegratorLoginModel entegratorLoginModel)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                cookieContainer.Add(userService.Endpoint.Address.Uri, new Cookie("DemoName", "DemoValue"));
                var behave = new CookieBehavior(cookieContainer);

                userService.Endpoint.EndpointBehaviors.Add(behave);

                await userService.wsLoginAsync(entegratorLoginModel.UserName, entegratorLoginModel.Password, entegratorLoginModel.Language);

                CookieHelper.COOKIEBEHAVIOR = behave;

                return new SuccessResult();

            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

        }

        public async Task<IResult> Logout()
        {
            try
            {

                await userService.logoutAsync();

                COOKIEBEHAVIOR = null;

                return new SuccessResult();

            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public void Dispose()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
