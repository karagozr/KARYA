using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAHIZA.WEB.MVC.Models.Admin
{
    public class UserModel:Users
    {
        public int[] UserAuthorizeList { 
            get { 
                return UserAuthorizeGroups.Select(x => x.AuthorizeGroupId).ToArray(); 
            } set {
                UserAuthorizeGroups = value.Select(x => new UserAuthorizeGroup {
                    AuthorizeGroupId=x,
                    UserId=Id
                });

            } }
    }
}
