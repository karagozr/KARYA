using HANEL.BUSINESS.Abstract.Finance;
using HANEL.DATAACCESS.Abstract.Finance;
using HANEL.MODEL.Dtos.Finance;
using HANEL.MODEL.Entities.Finance;
using KARYA.CORE.Concrete.EntityFramework;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Finance
{
    public class ReportCodeManager : BaseManager<ReportCode>, IReportCodeManager
    {
        IReportCodeDal _dal;

        public ReportCodeManager(IReportCodeDal dal) : base(dal)
        {
            _dal = dal;
        }
        public async Task<IDataResult<IEnumerable<ReportCodeEditDto>>> GetEditList()
        {
            try
            {
                var result = await _dal.List(null);
                var data = result.Select(x => new ReportCodeEditDto {
                    IntegrationCode1 = x.IntegrationCode1,
                    IntegrationCode2 = x.IntegrationCode2,
                    IntegrationCode3 = x.IntegrationCode3,
                    IsExpanded = x.IsExpanded,
                    ColorCode = x.ColorCode,
                    OrderCode = x.OrderCode,
                    Id = x.Id,
                    ParentId = x.ParentId,
                    IsReportCode = x.IsReportCode,
                    Name = x.Name,
                    Deleted = false,
                    Updated = false,
                    Inserted = false
                }) ;

                return new SuccessDataResult<IEnumerable<ReportCodeEditDto>>(data);
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<IEnumerable<ReportCodeEditDto>>(ex.Message);
            }
        }
        public async Task<IResult> EditList(IEnumerable<ReportCodeEditDto> reportCodeEditDto)
        {
            try
            {
                var deleteList = reportCodeEditDto.Where(x => x.Deleted == true).Select(x => new ReportCode
                {
                    IntegrationCode1 = x.IntegrationCode1,
                    IntegrationCode2 = x.IntegrationCode2,
                    IntegrationCode3 = x.IntegrationCode3,
                    IsExpanded = x.IsExpanded,
                    ColorCode = x.ColorCode,
                    OrderCode = x.OrderCode,
                    Id = x.Id,
                    ParentId = x.ParentId,
                    IsReportCode = x.IsReportCode,
                    Name = x.Name
                });
                
                var insertList = reportCodeEditDto.Where(x => x.Inserted == true && x.Deleted == false).Select(x => new ReportCode
                {
                    IntegrationCode1 = x.IntegrationCode1,
                    IntegrationCode2 = x.IntegrationCode2,
                    IntegrationCode3 = x.IntegrationCode3,
                    IsExpanded = x.IsExpanded,
                    ColorCode = x.ColorCode,
                    OrderCode = x.OrderCode,
                    Id = x.Id,
                    ParentId = x.ParentId,
                    IsReportCode = x.IsReportCode,
                    Name = x.Name
                });

                var updateList = reportCodeEditDto.Where(x => x.Updated == true && x.Inserted == false && x.Deleted == false).Select(x => new ReportCode
                {
                    IntegrationCode1 = x.IntegrationCode1,
                    IntegrationCode2 = x.IntegrationCode2,
                    IntegrationCode3 = x.IntegrationCode3,
                    IsExpanded = x.IsExpanded,
                    ColorCode = x.ColorCode,
                    OrderCode = x.OrderCode,
                    Id = x.Id,
                    ParentId = x.ParentId,
                    IsReportCode = x.IsReportCode,
                    Name = x.Name
                });


                await _dal.Update(updateList);
                
                await _dal.Add(insertList);

                await _dal.Delete(deleteList);


                return new SuccessResult();
            }
            catch (System.Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

    }

}
