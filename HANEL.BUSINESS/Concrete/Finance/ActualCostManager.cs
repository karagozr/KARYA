using Dapper;
using HANEL.BUSINESS.Abstract.Finance;
using HANEL.MODEL.Dtos.Finance.Budget;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Concrete.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Finance
{
    public class ActualCostManager : DapperBaseDal, IActualCostManager 
    {
        public async Task<IDataResult<IEnumerable<ActualCostWithMonths>>> GetActualCostWithMonths(string projectCode,short year, string currency)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"select * from TFunc_GetActualOfProject('{projectCode}',{year},'{currency}')";

                    var data = await connection.QueryAsync<ActualCostWithMonths>(queryString);
                   
                    return new SuccessDataResult<IEnumerable<ActualCostWithMonths>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<ActualCostWithMonths>>(ex.Message);
            }
        }


    }
}
