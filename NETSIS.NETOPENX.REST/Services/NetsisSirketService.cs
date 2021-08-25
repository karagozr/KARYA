using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.Netsis;
using NetOpenX.Rest.Client.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETSIS.NETOPENX.REST.Services
{
    public class NetsisSirketService : NetsisBaseService
    {
        public NetsisSirketService(Login loginModel) : base(loginModel)
        {
        }

        public async Task<IDataResult<IEnumerable<Sube>>> ListSube()
        {
            try
            {
                var manager = new QueryManager(AUTH);
                var res = await manager.GetInternalAsync("SELECT * FROM TBLSUBELER where SUBE_KODU = ISLETME_KODU ");
                var resultList = new List<Sube>();
                if(res.Data!=null)
                foreach (var item in res.Data)
                {
                    resultList.Add(new Sube
                    {
                        SubeKodu = (int)item.GetValue("SUBE_KODU"),
                        IsletmeKodu = (int)item.GetValue("ISLETME_KODU"),
                        Unvan = item.GetValue("UNVAN").ToString(),
                        Vkn = item.GetValue("VNO").ToString(),

                    });
                }
                return new SuccessDataResult<IEnumerable<Sube>>(resultList);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Sube>>(null,ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<Sube>>> GetSube(string vkn)
        {
            try
            {
                var manager = new QueryManager(AUTH);
                var res = await manager.GetInternalAsync(string.IsNullOrEmpty(vkn)?$"SELECT * FROM TBLSUBELER": 
                    $"SELECT * FROM TBLSUBELER WHERE SUBE_KODU!= ISLETME_KODU AND VNO ='{vkn}'");
                var resultList = new List<Sube>();
                if(res.IsSuccessful)
                foreach (var item in res.Data)
                {
                    resultList.Add(new Sube
                    {
                        SubeKodu = (int)item.GetValue("SUBE_KODU"),
                        IsletmeKodu = (int)item.GetValue("ISLETME_KODU"),
                        Unvan = item.GetValue("UNVAN").ToString(),
                        Vkn = item.GetValue("VNO").ToString(),

                    });
                }
                return new SuccessDataResult<IEnumerable<Sube>>(resultList);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Sube>>(null, ex.Message);
            }
        }

        public async Task<IDataResult<Sube>> GetSubeById(int subeKodu)
        {
            try
            {
                var manager = new QueryManager(AUTH);
                var res = await manager.GetInternalAsync($"SELECT * FROM TBLSUBELER WHERE SUBE_KODU={subeKodu}");

                if (res.Data == null)
                {
                    return new SuccessDataResult<Sube>(null, "Sube Bulunamadı");
                }

                return new SuccessDataResult<Sube>(new Sube
                {
                    SubeKodu = (int)res.Data[0].GetValue("SUBE_KODU"),
                    IsletmeKodu = (int)res.Data[0].GetValue("ISLETME_KODU"),
                    Unvan = res.Data[0].GetValue("UNVAN").ToString(),
                    Vkn = res.Data[0].GetValue("VNO").ToString(),

                });
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Sube>(null, ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<Proje>>> ListProje()
        {
            try
            {
                var manager = new QueryManager(AUTH);
                var res = await manager.GetInternalAsync("select * from TBLPROJE");

                if (res.Data == null)
                {
                    return new SuccessDataResult<IEnumerable<Proje>>(null, "Proje Bulunamadı");
                }

                var resultList = new List<Proje>();

                foreach (var item in res.Data)
                {
                    resultList.Add(new Proje
                    {
                        ProjeAdi = item.GetValue("PROJE_ACIKLAMA").ToString(),
                        ProjeKodu = item.GetValue("PROJE_KODU").ToString(),
                        RaporKod1 = item.GetValue("RAPOR_KOD1").ToString(),
                        RaporKod2 = item.GetValue("RAPOR_KOD2").ToString(),

                    });
                }

                return new SuccessDataResult<IEnumerable<Proje>>(resultList);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Proje>>(null, ex.Message);
            }
        }
    }
}
