using HANEL.BUSINESS.Abstract.Finance;
using HANEL.DATAACCESS.Abstract.Finance;
using HANEL.MODEL.Dtos.Finance;
using HANEL.MODEL.Entities.Finance;
using HANEL.MODEL.Filter.Finance;
using KARYA.CORE.Concrete.EntityFramework;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Finance
{
    public class ReportCodeUserFilterManager : BaseManager<ReportCodeUserFilter>, IReportCodeUserFilterManager
    {
        IReportCodeUserFilterDal _dal;
        IReportCodeDal _reportDal;

        public ReportCodeUserFilterManager(IReportCodeUserFilterDal dal, IReportCodeDal reportDal) : base(dal)
        {
            _dal = dal;
            _reportDal = reportDal;
        }
        public async Task<IDataResult<IEnumerable<ReportCodeUserFilterEditDto>>> GetEditList(ReportCodeUserFilterFilterModel reportCodeUserFilterFilterModel)
        {
            try
            {
                var reportCodes = await _reportDal.List(x=>x.IsReportCode==true);

                

                var filterData = await _dal.List(x => x.ProjectCode == reportCodeUserFilterFilterModel.ProjectCode && x.UserId==reportCodeUserFilterFilterModel.UserId);

                var res = reportCodes.GroupJoin(
                    filterData,
                    rep => rep.IntegrationCode1,
                    fil => fil.IntegrationCode1,
                    (x, y) => new { rep = x, filterData = y })
                    .SelectMany(
                    x => x.filterData.DefaultIfEmpty(),
                    (x, y) => new ReportCodeUserFilterEditDto
                    {
                        Id                  = y == null ? 0 : y.Id,
                        UserId              = y == null ? reportCodeUserFilterFilterModel.UserId : y.UserId,
                        ProjectCode         = y == null ? reportCodeUserFilterFilterModel.ProjectCode : y.ProjectCode,
                        BranchCode          = y == null ? null : y.BranchCode,
                        Name                = x.rep.Name,
                        IntegrationCode1    = x.rep.IntegrationCode1,
                        IntegrationCode2    = x.rep.IntegrationCode2,
                        IntegrationCode3    = x.rep.IntegrationCode3,
                        AccessRead          = y == null ? false : y.AccessRead,
                        AccessAdd           = y == null ? false : y.AccessAdd,
                        AccessUpdate        = y == null ? false : y.AccessUpdate,
                        AccessDelete        = y == null ? false : y.AccessDelete
                    });

                return new SuccessDataResult<IEnumerable<ReportCodeUserFilterEditDto>>(res);
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<IEnumerable<ReportCodeUserFilterEditDto>>(ex.Message);
            }
        }
        public async Task<IResult> EditList(IEnumerable<ReportCodeUserFilter> reportCodeUserFilters)
        {
            try
            {
                await _dal.AddUpdate(reportCodeUserFilters);

                return new SuccessResult();
            }
            catch (System.Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

    }

}
