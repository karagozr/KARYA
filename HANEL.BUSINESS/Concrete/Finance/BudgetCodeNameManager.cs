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
    public class BudgetCodeNameManager : DapperBaseDal, IBudgetCodeNameManager
    {
        public async Task<IDataResult<IEnumerable<BudgetCodeName>>> List()
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var data = await connection.QueryAsync<BudgetCodeName>("select * from Vw_PlReportCodes");

                    return new SuccessDataResult<IEnumerable<BudgetCodeName>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<BudgetCodeName>>(ex.Message);
            }
        }
    }
}
