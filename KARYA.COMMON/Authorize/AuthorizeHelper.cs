using KARYA.MODEL.Authorize.Karya;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.COMMON.Authorize
{
    public static class AuthorizeHelper
    {
        public static string GetRole(this AppRole appModuleRole)
        {
            return appModuleRole.ToString();
        }
    }

    public class KaryaAuthorizeAttribute: AuthorizeAttribute
    {
        private AppRole role;
        public AppRole RoleEnum
        {
            get { return role; }
            set { role = value; base.Roles = value.ToString(); }
        }

    }


}