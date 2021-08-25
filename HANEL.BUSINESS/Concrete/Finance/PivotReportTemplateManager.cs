using HANEL.BUSINESS.Abstract.Finance;
using HANEL.DATAACCESS.Abstract;
using HANEL.MODEL.Entities.Finance;
using KARYA.CORE.Concrete.EntityFramework;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Finance
{
    public class PivotReportTemplateManager : BaseManager<PivotReportTemplate>, IPivotReportTemplateManager
    {
        IPivotReportTemplateDal _pivotReportTemplateDal;
        
        public PivotReportTemplateManager(IPivotReportTemplateDal pivotReportTemplateDal) : base(pivotReportTemplateDal)
        {
            _pivotReportTemplateDal = pivotReportTemplateDal;
        }

        public async Task<IDataResult<IEnumerable<PivotReportTemplate>>> GetAll()
        {
            IDataResult<IEnumerable<PivotReportTemplate>> result;

            try
            {
                var data = await _pivotReportTemplateDal.List(null);
                result = new SuccessDataResult<IEnumerable<PivotReportTemplate>>(data);
            }
            catch (Exception ex)
            {
                result = new ErrorDataResult<IEnumerable<PivotReportTemplate>>(null, ex.Message);
            }

            return result;
        }

        
    }
}
