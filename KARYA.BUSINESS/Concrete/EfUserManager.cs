using KARYA.BUSINESS.Abstract;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Abstract.User;
using KARYA.MODEL.Dtos.User;
using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete
{
    public class EfUserManager : IUserManager
    {
        IUserDal _userDal;
        public EfUserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<IResult> Delete(int userId)
        {
            try
            {
                var user = await _userDal.Get(x => x.Id == userId);

                await _userDal.Delete(user);

                return new SuccessResult("Success");

            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<UserSDto>> Get(int id)
        {
            try
            {
                var user = await _userDal.GetUserListWithAutorizeGroups(x=>x.Id==id);

                return new SuccessDataResult<UserSDto>(user.Select(x => new UserSDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                    Lastname = x.Lastname,
                    EMail = x.EMail,
                    UserName = x.UserName,
                    Password = "-1",
                    UserGroupId = x.UserGroupId,
                    Enable = x.Enable,
                    AuthorizeGroups = x.UserAuthorizeGroups.Select(y => y.AuthorizeGroupId)
                }).FirstOrDefault());

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<UserSDto>(ex.Message);
            }
        }


        public async Task<IResult> Edit(UserSDto userSDto)
        {
            try
            {
                var authGroups = new List<UserAuthorizeGroup>();

                if(userSDto.AuthorizeGroups!=null)
                foreach (var item in userSDto.AuthorizeGroups)
                {
                    authGroups.Add(new UserAuthorizeGroup { UserId = userSDto.Id, AuthorizeGroupId = item });
                }

                if (userSDto.Id == 0)
                {
                    var addUser = new Users
                    {
                        Id = userSDto.Id,
                        Description = userSDto.Description,
                        Name = userSDto.Name,
                        Lastname = userSDto.Lastname,
                        EMail = userSDto.EMail,
                        UserName = userSDto.UserName,
                        UserGroupId = userSDto.UserGroupId,
                        Code = "entegre-kod",
                        Enable = userSDto.Enable,
                        Password = userSDto.Password,
                        UserAuthorizeGroups = authGroups
                    };
                    await _userDal.AddComplex(addUser);
                }
                else
                {
                    var updateUser = await _userDal.Get(x => x.Id == userSDto.Id);

                    updateUser.UserAuthorizeGroups = authGroups;
                    updateUser.Description = userSDto.Description;
                    updateUser.Name = userSDto.Name;
                    updateUser.Lastname = userSDto.Lastname;
                    updateUser.EMail = userSDto.EMail;
                    updateUser.UserName = userSDto.UserName;
                    updateUser.UserGroupId = userSDto.UserGroupId;
                    updateUser.Code = "entegre-kod";
                    updateUser.Enable = userSDto.Enable;
                    //updateUser.Password = updateUser.Password;
                    updateUser.UserAuthorizeGroups = authGroups;


                    await _userDal.UpdateComplex(updateUser);
                }

                return new SuccessResult("Success");

            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> ResetPassword(UserResetPasswordDto userPasswordDto)
        {
            try
            {
                var updateUser = await _userDal.Get(x => x.Id == userPasswordDto.UserId);

                if(userPasswordDto.NewPassword != userPasswordDto.NewPasswordRewrite)
                {
                    return new ErrorResult("KRY102");
                }

                updateUser.Password = userPasswordDto.NewPassword;

                await _userDal.Update(updateUser);

                return new SuccessResult("Success");

            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<UserLDto>>> List()
        {
            try
            {
                var user = await _userDal.List(null);

                return new SuccessDataResult<IEnumerable<UserLDto>>(user.Select(x => new UserLDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                    Lastname = x.Lastname,
                    EMail = x.EMail,
                    UserName = x.UserName,
                    UserGroupId = x.UserGroupId,
                }));

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<UserLDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<UserSDto>>> ListWithAuthGroups()
        {
            try
            {
                var user = await _userDal.GetUserListWithAutorizeGroups(null);

                return new SuccessDataResult<IEnumerable<UserSDto>>(user.Select(x => new UserSDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                    Lastname = x.Lastname,
                    EMail = x.EMail,
                    UserName = x.UserName,
                    Password = "-1",
                    UserGroupId = x.UserGroupId,
                    Enable=x.Enable,
                    AuthorizeGroups = x.UserAuthorizeGroups.Select(y => y.AuthorizeGroupId)
                }));

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<UserSDto>>(ex.Message);
            }
        }
    }
}
