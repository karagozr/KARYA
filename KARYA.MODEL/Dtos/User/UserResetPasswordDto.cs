using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.Dtos.User
{
    public class UserResetPasswordDto
    {
        public int UserId { get; set; }
        //public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordRewrite { get; set; }
    }
}
