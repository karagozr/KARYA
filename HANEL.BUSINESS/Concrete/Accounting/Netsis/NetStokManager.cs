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
    public class NetStokManager : DapperRepository, IStokManager
    {
        public NetStokManager() : base("NETSISConnection")
        {
        }

        public async Task<IDataResult<StokDto>> Get(string stokKodu)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"select   " +
                        $"dbo.TRK(st.STOK_KODU)     as StokKodu         ,  " +
                        $"dbo.TRK(st.STOK_ADI)      as StokAdi          ,  " +
                        $"dbo.TRK(st.KOD_1)         as Kod1             ,  " +
                        $"dbo.TRK(st.GRUP_KODU)     as GrupKodu         ,  " +
                        $"dbo.TRK(mp.HESAP_KODU)    as AlisHesapKodu    ,  " +
                        $"dbo.TRK(mp.HS_ADI)        as AlisHesapAdi     ,  " +
                        $"dbo.TRK(mp1.HESAP_KODU)   as SatisHesapKodu   ,  " +
                        $"dbo.TRK(mp1.HS_ADI)       as SatisHesapAdi    ,  " +
                        $"st.KDV_ORANI as KdvOrani from TBLSTSABIT as st   " +
                        $"left join TBLSTMUHDETAY   as md   on st.MUH_DETAYKODU = md.MUH_DETAYKOD   " +
                        $"left join TBLMUPLAN       as mp   on md.ALIS_HESABI   = mp.HESAP_KODU     " +
                        $"left join TBLMUPLAN       as mp1  on md.SATIS_HESABI  = mp1.HESAP_KODU    " +
                        $"where STOK_KODU like '{stokKodu}'";

                    var data = await connection.QueryFirstOrDefaultAsync<StokDto>(queryString);

                    return new SuccessDataResult<StokDto>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<StokDto>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<StokDto>>> List(string stokKodu=null)
        {
            try
            {
                using (var connection = CreateMsSqlConnection())
                {
                    var queryString = $"select   " +
                        $"dbo.TRK(st.STOK_KODU)     as StokKodu         ,  " +
                        $"dbo.TRK(st.STOK_ADI)      as StokAdi          ,  " +
                        $"dbo.TRK(st.KOD_1)         as Kod1             ,  " +
                        $"dbo.TRK(st.GRUP_KODU)     as GrupKodu         ,  " +
                        $"dbo.TRK(mp.HESAP_KODU)    as AlisHesapKodu    ,  " +
                        $"dbo.TRK(mp.HS_ADI)        as AlisHesapAdi     ,  " +
                        $"dbo.TRK(mp1.HESAP_KODU)   as SatisHesapKodu   ,  " +
                        $"dbo.TRK(mp1.HS_ADI)       as SatisHesapAdi    ,  " +
                        $"st.KDV_ORANI as KdvOrani from TBLSTSABIT as st   " +
                        $"left join TBLSTMUHDETAY   as md   on st.MUH_DETAYKODU = md.MUH_DETAYKOD   " +
                        $"left join TBLMUPLAN       as mp   on md.ALIS_HESABI   = mp.HESAP_KODU     " +
                        $"left join TBLMUPLAN       as mp1  on md.SATIS_HESABI  = mp1.HESAP_KODU    ";

                    if(string.IsNullOrEmpty(stokKodu))
                        queryString += $"where STOK_KODU like '%{stokKodu}%'";

                    var data = await connection.QueryAsync<StokDto>(queryString);

                    return new SuccessDataResult<IEnumerable<StokDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<StokDto>>(ex.Message);
            }
        }
    }
}
