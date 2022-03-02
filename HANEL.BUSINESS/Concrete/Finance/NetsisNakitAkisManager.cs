using Dapper;
using HANEL.BUSINESS.Abstract.Finance;
using HANEL.MODEL.Dtos.Finance.CashFlow;
using HANEL.MODEL.Filter.Finance;
using KARYA.CORE.Abstract;
using KARYA.CORE.Concrete.Dapper;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Finance
{
    public class NetsisNakitAkisManager : DapperRepository,INakitAkisManager
    {
        public NetsisNakitAkisManager() : base("NETSISConnection")
        {
        }

        public async Task<IDataResult<IEnumerable<CashFlowMonthlyDto>>> List(CashFlowFilterModel filter)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"exec HNL_SP_NAKIT_AKIS  {filter.Year}, '{filter.CurrencyCode}', '{filter.SectorName}','{filter.Date1.ToString("yyyy-MM-dd")}','{filter.Date2.ToString("yyyy-MM-dd")}' ";

                    var data = await connection.QueryAsync<CashFlowMonthlyDto>(queryString);

                    return new SuccessDataResult<IEnumerable<CashFlowMonthlyDto>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<CashFlowMonthlyDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<CashFlowDetailDto>>> ListDetail(CashFlowFilterModel filter)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    filter.Date1 = filter.Month == 0 ? filter.Date1 : new DateTime(filter.Year, filter.Month, 1);
                    filter.Date2 = filter.Month == 0 ? filter.Date2 : new DateTime(filter.Year, filter.Month, 1).AddMonths(1).AddDays(-1);

                    var queryString = $"HNL_SP_NAKIT_AKIS_DETAY {filter.Year}, '{filter.CurrencyCode}', '{filter.SectorName}','{filter.RefCode}','{filter.Date1.ToString("yyyy-MM-dd")}','{filter.Date2.ToString("yyyy-MM-dd")}'";

                    var data = await connection.QueryAsync<CashFlowDetailDto>(queryString);

                    return new SuccessDataResult<IEnumerable<CashFlowDetailDto>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<CashFlowDetailDto>>(ex.Message);
            }
        }

    }
}
