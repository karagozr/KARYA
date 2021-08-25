using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KARYA.MODEL.DataTransferModels.Karya.Auth
{
    public class UserModel:Users
    {
        //public UserModel()
        //{
        //    UserAuthorizeGroups = UserAuthorizeGroupIds.Count != 0 ? UserAuthorizeGroupIds.Select(x => new UserAuthorizeGroup
        //    {
        //        AuthorizeGroupId = x,
        //    }) : new List<UserAuthorizeGroup>();
        //}
        public List<int> UserAuthorizeGroupIds
        {
            get;
            set;
        }
    }
}
