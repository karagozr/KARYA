using EFinansAuthService;
using HANEL.MODEL.DataTransferModels.EServisEntegrator;
using HANEL.SERVICE.EINVOICE.Abstract;
using HANEL.SERVICE.EINVOICE.Helpers;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;
using static HANEL.SERVICE.EINVOICE.Helpers.CookieHelper;

namespace HANEL.SERVICE.EINVOICE.Concrete.EFinansService
{
    public class EFinansAuthServiceUtility : IServiceAuthUtility
    {
        UserServiceClient userService;
        public EFinansAuthServiceUtility()
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

                userService.Endpoint.EndpointBehaviors.Clear();
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
