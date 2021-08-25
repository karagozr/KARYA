using Dapper;
using HANEL.BUSINESS.Abstract.Finance;
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

        public async Task<IDataResult<IEnumerable<dynamic>>> List()
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"exec HNL_SP_NAKIT_AKIS_OZET 'USD'";

                    var data = await connection.QueryAsync<dynamic>(queryString);

                    return new SuccessDataResult<IEnumerable<dynamic>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<dynamic>>(ex.Message);
            }
        }
        
    }
}
