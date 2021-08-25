using Dapper;
using HANEL.BUSINESS.Abstract.Accounting;
using HANEL.MODEL.Dto.Muhasebe;
using KARYA.CORE.Concrete.Dapper;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Accounting.Netsis
{
    public class NetMuhasebeManager : DapperRepository, IMuhasebeManager
    {
        public NetMuhasebeManager() : base("NETSISConnection")
        {
        }

        public async Task<IDataResult<IEnumerable<MuhasebePlanDto>>> ListMuhHesap(string hesapKodu = null)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"select " +
                        $"dbo.TRK(HESAP_KODU)        as HesapKodu     , " +
                        $"dbo.TRK(HS_ADI)            as HesapAdi        " +
                        $"from TBLMUPLAN where AGM='M' ";

                    if (string.IsNullOrEmpty(hesapKodu))
                        queryString += $" and HESAP_KODU like '%{hesapKodu}%'";

                    var data = await connection.QueryAsync<MuhasebePlanDto>(queryString);

                    return new SuccessDataResult<IEnumerable<MuhasebePlanDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<MuhasebePlanDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<MuhasebeReferansDto>>> ListMuhReferans(string referansKodu = null)
        {


            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"select " +
                        $"dbo.TRK(GRUP_KOD )     as ReferansKodu     , " +
                        $"dbo.TRK(GRUP_ISIM)     as ReferansAdi        " +
                        $"from TBLMUHAREF ";

                    if (string.IsNullOrEmpty(referansKodu))
                        queryString += $"where GRUP_KOD like '%{referansKodu}%'";

                    var data = await connection.QueryAsync<MuhasebeReferansDto>(queryString);

                    return new SuccessDataResult<IEnumerable<MuhasebeReferansDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<MuhasebeReferansDto>>(ex.Message);
            }
        }
    }
}
