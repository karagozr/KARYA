using KARYA.BUSINESS.Abstract;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Abstract.Authorize;
using KARYA.DATAACCESS.Abstract.User;
using KARYA.MODEL.Dtos.AuthGroup;
using KARYA.MODEL.Dtos.User;
using KARYA.MODEL.Entities.Karya;
using KARYA.MODEL.Enums.Karya;
using KARYA.MODEL.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete
{
    public class EfAuthGroupManager : IAuthGroupManager
    {
        IAuthorizeGroupDal _authGroupDal;
        ICoreModules _appModules;
        public EfAuthGroupManager(IAuthorizeGroupDal authGroupDal, ICoreModules appModules)
        {
            _appModules=appModules;
            _authGroupDal = authGroupDal;
        }


        public async Task<IResult> Edit(AuthGroupSDto authGroupSDto)
        {
            try
            {

                if (authGroupSDto.Id == 0)
                {

                    
                    var newAuthGroupDetails = new List<AuthorizeGroupDetail>();

                    foreach (var item in authGroupSDto.AuthGroupDetails)
                    {
                        newAuthGroupDetails.Add(new AuthorizeGroupDetail { 
                            AppModuleId=item.AppModuleId,
                            IsAuthorize=item.IsAuthorize,
                            FieldName="",
                            FilterRule=FilterRule.IsAnyOf,
                            FilterValue1="",
                            FilterValue2=""
                        });
                    }

                    var newAuthGroup = new AuthorizeGroup
                    {
                        Name = authGroupSDto.Name,
                        Description = authGroupSDto.Description,
                        AuthorizeGroupDetails = newAuthGroupDetails
                    };

                    await _authGroupDal.AddComplex(newAuthGroup);
                }
                else
                {
                    bool parentIsAuthorize(int appModuleId)
                    {
                        var module = _appModules.ModuleList.FirstOrDefault(x => x.Id == appModuleId);
                        var authModule = authGroupSDto.AuthGroupDetails.FirstOrDefault(x => x.AppModuleId == module.ParentId);
                        if (authModule == null)
                            return true;
                        if (module.ParentId == 0 && authModule.IsAuthorize)
                            return true;
                        else if (module.ParentId != 0 && authModule.IsAuthorize)
                            return parentIsAuthorize(module.ParentId);
                        else
                            return false;
                    }

                    var updateAuthGroup = await _authGroupDal.GetWithDetails(x => x.Id == authGroupSDto.Id);

                    IEnumerable<AuthorizeGroupDetail> newAuthList = _appModules.ModuleList
                        .GroupJoin(authGroupSDto.AuthGroupDetails,
                            mdl => mdl.Id,
                            adl => adl.AppModuleId,
                            (left, right) => new {
                                mdl = left,
                                adl = right })
                        .SelectMany(
                            full => full.adl,
                            (left, right) => new { mdl = left.mdl, adl = right }
                        ).Select(x => new AuthorizeGroupDetail
                        {
                            Id=x.adl.Id,
                            AppModuleId = x.mdl.Id,
                            IsAuthorize = x.adl.IsAuthorize? parentIsAuthorize(x.mdl.Id):false,
                            AuthorizeGroupId = authGroupSDto.Id,
                            FieldName="",
                        }).ToList();

                    updateAuthGroup.Name = authGroupSDto.Name;
                    updateAuthGroup.Description = authGroupSDto.Description;
                    updateAuthGroup.AuthorizeGroupDetails = newAuthList;

                    await _authGroupDal.UpdateComplex(updateAuthGroup);
                }

                return new SuccessResult("Success");

            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<AuthGroupSDto>> GetWithDetail(int Id)
        {
            try
            {
                var data = await _authGroupDal.GetWithDetails(x => x.Id == Id);

                if (data == null)
                {
                    return new SuccessDataResult<AuthGroupSDto>(new AuthGroupSDto
                    {
                        Id = 0,
                        Name = "",
                        Description = "",
                        AuthGroupDetails = _appModules.ModuleList.Select(x => new AuthGroupDetailLDto
                        {
                            Id=0,
                            AppModuleId = x.Id,
                            AppModuleParentId = x.ParentId,
                            AppModuleName = x.Name,
                            IsAuthorize = false

                        })
                    });
                }

                var authGroups = _appModules.ModuleList
                        .GroupJoin(data.AuthorizeGroupDetails,
                            mdl => mdl.Id,
                            adl => adl.AppModuleId,
                            (left, right) => new {
                                mdl = left,
                                adl = right
                            }).SelectMany(
                            full => full.adl.DefaultIfEmpty(),
                            (left, right) => new { mdl = left.mdl, adl = right }
                        ).Select(x => new AuthGroupDetailLDto
                        {
                            Id=x.adl ==null?0: x.adl.Id,
                            AppModuleParentId = x.mdl.ParentId,
                            AppModuleId = x.mdl.Id,
                            IsAuthorize = x.adl == null ? false : x.adl.IsAuthorize,
                            AppModuleName=x.mdl.Name,
                            AuthorizeGroupId = data.Id,
                        });

                return new SuccessDataResult<AuthGroupSDto>(new AuthGroupSDto {
                    Id = data.Id,
                    Name = data.Name,
                    Description = data.Description,
                    AuthGroupDetails = authGroups
                });
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<AuthGroupSDto>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<AuthGroupLDto>>> List()
        {
            try
            {
                var data = await _authGroupDal.List(null);

                return new SuccessDataResult<IEnumerable<AuthGroupLDto>>(data.Select(x => new AuthGroupLDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<AuthGroupLDto>>(ex.Message);
            }
        }
    }
}
