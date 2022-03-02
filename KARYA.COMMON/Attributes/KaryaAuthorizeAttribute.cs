using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.COMMON.Attributes
{
    public class KaryaAuthorizeAttribute : AuthorizeAttribute
    {
        private int role;
        public int Role
        {
            get { return role; }
            set { role = value; base.Roles = value.ToString(); }
        }

    }
}
