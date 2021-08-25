using KARYA.BUSINESS.Abstract.Karya;
using KARYA.BUSINESS.Concrete.Base;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Abstract.User;
using KARYA.MODEL.Common.Auth;
using KARYA.MODEL.DataTransferModels.Karya.Auth;
using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.Karya
{
    public class UserManager : BaseManager<Users>, IUserManager
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal) : base(userDal)
        {
            _userDal = userDal;
        }
       
        public async Task<IDataResult<UserModel>> GetByIdWithAuthorizeGrups(int id)
        {
            try
            {
                var user = await _userDal.Get(x=>x.Id==id);
                return new SuccessDataResult<UserModel>(new UserModel { 
                    Code=user.Code,
                    UserAuthorizeGroups=user.UserAuthorizeGroups,
                    UserGroupId=user.UserGroupId,
                    Enable=user.Enable,
                    UserName=user.UserName,
                    Lastname=user.Lastname,
                    Password=user.Password,
                    Name=user.Name,
                    Description=user.Description,
                    Id=user.Id,
                    EMail=user.EMail,
                    UserAuthorizeGroupIds=user.UserAuthorizeGroups.Select(x=>x.AuthorizeGroupId).ToList()

                });
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<UserModel>(ex.Message);
            }
        }

        public async Task<IResult> AddComplex(UserModel user)
        {
            try
            {
                var addUser = new Users
                {
                    Code = user.UserName,
                    Name = user.Name,
                    Lastname = user.Lastname,
                    UserName = user.UserName,
                    Password = user.Password,
                    UserGroupId = user.UserGroupId,
                    EMail = user.EMail,
                    Enable = true,
                    Description = user.Description,

                };

                var userAuthorizeGroups = new List<UserAuthorizeGroup>();

                user.UserAuthorizeGroupIds.ForEach(x =>
                {
                    userAuthorizeGroups.Add(new UserAuthorizeGroup { AuthorizeGroupId = x });
                });

                addUser.UserAuthorizeGroups = userAuthorizeGroups;

                await _userDal.AddUpdate(addUser);

                return new SuccessResult("Adding was succesed");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> UpdateComplex(UserModel user)
        {
            
            try
            {
                var userAuthorizeGroups = new List<UserAuthorizeGroup>();

                user.UserAuthorizeGroupIds.ForEach(x =>
                {
                    userAuthorizeGroups.Add(new UserAuthorizeGroup { AuthorizeGroupId = x, UserId = user.Id });
                });

                var updateUser = new Users
                {
                    Id = user.Id,
                    Code = user.UserName,
                    Name = user.Name,
                    Lastname = user.Lastname,
                    UserName = user.UserName,
                    Password = user.Password,
                    UserGroupId = user.UserGroupId,
                    EMail = user.EMail,
                    Enable = true,
                    Description = user.Description,
                    UserAuthorizeGroups = userAuthorizeGroups
                };

                await _userDal.UpdateComplex(updateUser);

                return new SuccessResult("Updating was succesed");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> AddUpdateComplex(UserModel user)
        {
            try
            {
                List<UserAuthorizeGroup> userAuthList = new List<UserAuthorizeGroup>();
                if(user.UserAuthorizeGroups!=null)
                    userAuthList  = user.UserAuthorizeGroups.Where(x=> user.UserAuthorizeGroupIds!=null && user.UserAuthorizeGroupIds.Contains(x.AuthorizeGroupId)).ToList();

                List<int> newAuthList = new List<int>();
                if(user.UserAuthorizeGroupIds!=null)
                    newAuthList = user.UserAuthorizeGroupIds.Where(x => !userAuthList.Select(z => z.AuthorizeGroupId).Contains(x)).ToList();

                foreach (var item in newAuthList)
                {
                    userAuthList.Add(new UserAuthorizeGroup {
                        UserId=user.Id,
                        User=user,
                        AuthorizeGroupId=item
                    });
                }

                user.UserAuthorizeGroups = userAuthList;

                if (user.Id == 0)
                {
                    await _userDal.AddComplex(user);
                }
                else
                {
                    await _userDal.UpdateComplex(user);
                }

                _identityId = _userDal.SCOPE_IDENTY_ID;
                return new SuccessResult("Edit was succesed");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
        public async Task<IDataResult<Users>> Login(UserLoginModel userLoginModel)
        {
            IDataResult<Users> result;

            try
            {
                var resultUser = await _userDal.GetUserWithAutorizeGroups(x => x.UserName == userLoginModel.UserName && x.Password == userLoginModel.Password);


                if (resultUser != null)
                    result = new SuccessDataResult<Users>(resultUser);
                else
                    result = new SuccessDataResult<Users>(resultUser,  "User was not found.");
            }
            catch (Exception ex)
            {
                result = new ErrorDataResult<Users>(null, ex.Message);
            }

            return result;
        }

    }
}
