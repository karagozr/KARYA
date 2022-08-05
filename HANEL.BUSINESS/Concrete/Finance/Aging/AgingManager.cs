using Dapper;
using HANEL.BUSINESS.Abstract.Finance.Aging;
using HANEL.MODEL.Dtos.Finance.Aging;
using HANEL.MODEL.Filter.Finance;
using KARYA.CORE.Aspects.CacheAspects;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Concrete.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Finance.Aging
{
    public class AgingManager : DapperBaseDal, IAgingManager
    {
        
        public async Task<IDataResult<IEnumerable<AgingReportDto>>> GetAgingBranchDetail(AgingFilterModel filter)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var query = $"select * from HNLGROUP22..HNL_TF_CARI_YASLANDIRMA_SUBE({filter.RangeDay},'{filter.Sector}', '{filter.CurrencyCode}', '{filter.CariKodu}')";
                    var data = await connection.QueryAsync<AgingReportDto>(query);

                    return new SuccessDataResult<IEnumerable<AgingReportDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<AgingReportDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<AgingDetailReportDto>>> GetAgingDetail(AgingFilterModel filter)
        {
            throw new NotImplementedException();
        }

        
        public async Task<IDataResult<IEnumerable<AgingReportDto>>> GetAgingList(AgingFilterModel filter)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    
                    var data = await connection.QueryAsync<AgingReportDto>($"select * from HNLGROUP22..[HNL_TF_CARI_YASLANDIRMA]({filter.RangeDay},'{filter.CariTip}','{filter.Sector}','{filter.CurrencyCode}')");

                    return new SuccessDataResult<IEnumerable<AgingReportDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<AgingReportDto>>(ex.Message);
            }
        }

        
        public async Task<IDataResult<IEnumerable<AgingReportDto>>> GetAgingProjectDetail(AgingFilterModel filter)
        {
            try
            {
                using (var connection = CreateConnection())
                {

                    var data = await connection.QueryAsync<AgingReportDto>($"select * from HNLGROUP22..HNL_TF_CARI_YASLANDIRMA_PROJE({filter.RangeDay},'{filter.Sector}', '{filter.CurrencyCode}', '{filter.CariKodu}')");

                    return new SuccessDataResult<IEnumerable<AgingReportDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<AgingReportDto>>(ex.Message);
            }
        }
    }
}
