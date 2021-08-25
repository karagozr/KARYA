using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.Netsis;
using NetOpenX.Rest.Client.BLL;
using NetOpenX.Rest.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETSIS.NETOPENX.REST.Services
{
    public class NetsisStokService:NetsisBaseService
    {
        ItemsManager _itemsManager;
        QueryManager _queryManager;
        
        public NetsisStokService(Login login) : base(login)
        {
            _itemsManager = new ItemsManager(AUTH);
        }

        public async Task<IDataResult<IEnumerable<Stok>>> List()
        {
            try
            {
                var result = await _itemsManager.GetInternalAsync(new SelectFilter { 
                    Limit=999999999
                });

                var resultList = new List<Stok>();

                if(result.Data!=null)
                foreach (var item in result.Data)
                {
                    resultList.Add(new Stok {
                        StokKodu=item.StokTemelBilgi.Stok_Kodu,
                        StokAdi=item.StokTemelBilgi.Stok_Adi,
                        GrupKodu=item.StokTemelBilgi.Grup_Kodu,
                        Kod1 = item.StokTemelBilgi.Kod_1,
                        Kod2 = item.StokTemelBilgi.Kod_2
                    });
                }

                return new SuccessDataResult<IEnumerable<Stok>>(resultList);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<IEnumerable<Stok>>(null, ex.Message);
            }
        }

        public async Task<IDataResult<Stok>> GetById(string cariKodu)
        {
            try
            {
                var result = await _itemsManager.GetInternalByIdAsync(cariKodu);
                
                return new SuccessDataResult<Stok>(new Stok
                {
                    StokKodu = result.Data.StokTemelBilgi.Stok_Kodu,
                    StokAdi = result.Data.StokTemelBilgi.Stok_Adi,
                    GrupKodu = result.Data.StokTemelBilgi.Grup_Kodu,
                    Kod1 = result.Data.StokTemelBilgi.Kod_1,
                    Kod2 = result.Data.StokTemelBilgi.Kod_2
                });
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Stok>(null, ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<Stok>>> ListMax()
        {
            try
            {
                _queryManager = new QueryManager(AUTH);

                var query = $"select  " +
                    $"st.STOK_KODU,st.KOD_1,st.GRUP_KODU, st.STOK_ADI,mp.HESAP_KODU as ALIS_HESAP_KODU,mp.HS_ADI as ALIS_HESAP_ADI ," +
                    $"mp1.HESAP_KODU as SATIS_HESAP_KODU, mp1.HS_ADI as SATIS_HESAP_ADI, st.KDV_ORANI " +
                    $"from TBLSTSABIT as st " +
                    $" left join TBLSTMUHDETAY as md on st.MUH_DETAYKODU = md.MUH_DETAYKOD " +
                    $" left join TBLMUPLAN as mp on md.ALIS_HESABI = mp.HESAP_KODU " +
                    $" left join TBLMUPLAN as mp1 on md.SATIS_HESABI = mp1.HESAP_KODU";

                var result = await _queryManager.GetInternalAsync(query);

                var resultList = new List<Stok>();
                if(result.Data!=null)
                foreach (var item in result.Data)
                {
                    resultList.Add(new Stok
                    {
                        StokKodu = item.GetValue("STOK_KODU").ToString(),
                        StokAdi = item.GetValue("STOK_ADI").ToString(),
                        GrupKodu = item.GetValue("GRUP_KODU").ToString(),
                        Kod1 = item.GetValue("KOD_1").ToString(),
                        AlisHesapKodu = item.GetValue("ALIS_HESAP_KODU").ToString(),
                        AlisHesapAdi = item.GetValue("ALIS_HESAP_ADI").ToString(),
                        SatisHesapKodu = item.GetValue("SATIS_HESAP_KODU").ToString(),
                        SatisHesapAdi = item.GetValue("SATIS_HESAP_ADI").ToString(),
                        KdvOrani = Convert.ToDouble(item.GetValue("KDV_ORANI"))

                    });
                }
                
                return new SuccessDataResult<IEnumerable<Stok>>(resultList);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<IEnumerable<Stok>>(null, ex.Message);
            }
        }

        public async Task<IDataResult<Stok>> GetMaxById(string stokKodu)
        {
            try
            {
                _queryManager = new QueryManager(AUTH);

                var query = $"select  " +
                    $"st.STOK_KODU,st.KOD_1,st.GRUP_KODU, st.STOK_ADI,mp.HESAP_KODU as ALIS_HESAP_KODU,mp.HS_ADI as ALIS_HESAP_ADI ," +
                    $"mp1.HESAP_KODU as SATIS_HESAP_KODU, mp1.HS_ADI as SATIS_HESAP_ADI, st.KDV_ORANI " +
                    $"from TBLSTSABIT as st " +
                    $" left join TBLSTMUHDETAY as md on st.MUH_DETAYKODU = md.MUH_DETAYKOD " +
                    $" left join TBLMUPLAN as mp on md.ALIS_HESABI = mp.HESAP_KODU " +
                    $" left join TBLMUPLAN as mp1 on md.SATIS_HESABI = mp1.HESAP_KODU " +
                    $" where STOK_KODU = '{stokKodu}'";

                var result = await _queryManager.GetInternalAsync(query);

                if (result.Data == null)
                {
                    return new SuccessDataResult<Stok>(null, "Stok Kartı Bulunamadı");
                }

                return new SuccessDataResult<Stok>(new Stok
                {
                    StokKodu = result.Data[0].GetValue("STOK_KODU").ToString(),
                    StokAdi = result.Data[0].GetValue("STOK_ADI").ToString(),
                    GrupKodu = result.Data[0].GetValue("GRUP_KODU").ToString(),
                    Kod1 = result.Data[0].GetValue("KOD_1").ToString(),
                    AlisHesapKodu = result.Data[0].GetValue("ALIS_HESAP_KODU").ToString(),
                    AlisHesapAdi = result.Data[0].GetValue("ALIS_HESAP_ADI").ToString(),
                    SatisHesapKodu = result.Data[0].GetValue("SATIS_HESAP_KODU").ToString(),
                    SatisHesapAdi = result.Data[0].GetValue("SATIS_HESAP_ADI").ToString(),
                    KdvOrani = Convert.ToDouble(result.Data[0].GetValue("KDV_ORANI"))
                });
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Stok>(null, ex.Message);
            }
        }
    }

}
