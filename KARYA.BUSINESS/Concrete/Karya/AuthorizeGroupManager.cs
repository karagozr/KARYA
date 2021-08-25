using KARYA.BUSINESS.Abstract.Karya;
using KARYA.BUSINESS.Concrete.Base;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Abstract.Authorize;
using KARYA.MODEL.Authorize;
using KARYA.MODEL.DataTransferModels.Karya.Finance.Admin;
using KARYA.MODEL.Dtos.Karya;
using KARYA.MODEL.Entities.Karya;
using KARYA.MODEL.Module;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.Karya
{
    public class AuthorizeGroupManager : BaseManager<AuthorizeGroup>, IAuthorizeGroupManager
    {
        IAuthorizeGroupDal _authorizeGroupDal;
        ICoreModules _appModules;
        public AuthorizeGroupManager(IAuthorizeGroupDal authorizeGroupDal, ICoreModules appModules) : base(authorizeGroupDal) 
        {
            _authorizeGroupDal = authorizeGroupDal;
            _appModules = appModules;
        }



        public async Task<IResult> Add(AuthorizeGrupModel authorizeGrupModel)
        {
            try
            {

                var authorizeGrupData = new AuthorizeGroup
                {
                    Name = authorizeGrupModel.Name,
                    Description = authorizeGrupModel.Description,
                };

                var detailData = new List<AuthorizeGroupDetail>();
                foreach (var item in authorizeGrupModel.AuthorizeGrupDetailModels)
                {
                    detailData.Add(new AuthorizeGroupDetail
                    {
                        AppModuleId = item.AppModuleId,
                        AuthorizeGroup = authorizeGrupData,
                        IsAuthorize = item.IsAuthorize
                    });
                }

                authorizeGrupData.AuthorizeGroupDetails = detailData;

                await _authorizeGroupDal.AddComplex(authorizeGrupData);

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<AuthorizeGroupDto>> GetWithDetail(int Id)
        {
            try
            {
                var result = await _authorizeGroupDal.GetWithDetails(x => x.Id == Id);

                return new SuccessDataResult<AuthorizeGroupDto>(new AuthorizeGroupDto
                {
                    Id = result.Id,
                    AuthorizeGroupDetails = result.AuthorizeGroupDetails,
                    Description = result.Description,
                    Name = result.Name,
                    AuthorizeGrupDetailJson = JsonConvert.SerializeObject(result.AuthorizeGroupDetails.Select(x => x.AppModuleId))
                });
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<AuthorizeGroupDto>(null,ex.Message);
            }
        }

        public async Task<IResult> Update(AuthorizeGrupModel authorizeGrupModel)
        {
            try
            {
                var authorizeGrupData = new AuthorizeGroup
                {
                    Id = authorizeGrupModel.Id,
                    Name = authorizeGrupModel.Name,
                    Description = authorizeGrupModel.Description,
                };

                var detailData = new List<AuthorizeGroupDetail>();

                foreach (var item in authorizeGrupModel.AuthorizeGrupDetailModels)
                {
                    detailData.Add(new AuthorizeGroupDetail
                    {
                        Id = item.Id,
                        AppModuleId = item.AppModuleId,
                        AuthorizeGroup = item.AuthorizeGroupId == 0? null : authorizeGrupData,
                        IsAuthorize = item.IsAuthorize
                    });
                }

                authorizeGrupData.AuthorizeGroupDetails = detailData;

                await _authorizeGroupDal.UpdateCascade(authorizeGrupData);

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> AddUpdateComplex(AuthorizeGroupDto entity)
        {
            try
            {
                string[] authArrayStr = entity.AuthorizeGrupDetailJson.Split(',');
                //var authArray = new int[authArrayStr.Length];

                //foreach (var item in authArrayStr)
                //{
                //    authArray
                //}

                if (entity.Id == 0)
                {
                    var authList = new List<AuthorizeGroupDetail>();

                    foreach (var item in _appModules.ModuleList)
                    {
                        authList.Add(new AuthorizeGroupDetail
                        {
                            AppModuleId = item.Id,
                            IsAuthorize = authArrayStr.Any(x=>x==item.Id.ToString()),
                        });
                    }

                    entity.AuthorizeGroupDetails = authList;

                    await _authorizeGroupDal.AddComplex(entity);

                    return new SuccessResult();
                }
                else
                {
                    var auth = await _authorizeGroupDal.GetWithDetails(x => x.Id == entity.Id);
                    var authList = auth.AuthorizeGroupDetails.ToList();
                    var newAuthList = _appModules.ModuleList.Where(x => !authList.Select(c => c.Id).Contains(x.Id));

                    foreach (var item in newAuthList)
                    {
                        authList.Add(new AuthorizeGroupDetail
                        {
                            AppModuleId = item.Id,
                            IsAuthorize = authArrayStr.Any(x => x == item.Id.ToString()),
                        });
                    }

                    foreach (var item in authList)
                    {
                        item.IsAuthorize = authArrayStr.Any(x => x == item.AppModuleId.ToString());
                    }

                    entity.AuthorizeGroupDetails = authList;

                    await _authorizeGroupDal.UpdateComplex(entity);

                    return new SuccessResult();
                }
               

            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
