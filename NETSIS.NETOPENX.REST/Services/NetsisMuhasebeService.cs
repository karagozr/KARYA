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
    public class NetsisMuhasebeService : NetsisBaseService
    {
        public NetsisMuhasebeService(Login loginModel) : base(loginModel)
        {
        }

        public async Task<IDataResult<IEnumerable<MuhasebeReferans>>> ListMuhReferans()
        {
            try
            {
                var manager = new QueryManager(AUTH);
                var res = await manager.GetInternalAsync("select * from TBLMUHAREF");

                if (res.Data == null)
                {
                    return new SuccessDataResult<IEnumerable<MuhasebeReferans>>(null, "Referans Bulunamadı");
                }

                var resultList = new List<MuhasebeReferans>();

                foreach (var item in res.Data)
                {
                    resultList.Add(new MuhasebeReferans
                    {
                        ReferansKodu = (int)item.GetValue("GRUP_KOD"),
                        ReferansAdi = item.GetValue("GRUP_ISIM").ToString(),

                    });
                }

                return new SuccessDataResult<IEnumerable<MuhasebeReferans>>(resultList);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<MuhasebeReferans>>(null, ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<MuhasebePlan>>> ListMuhHesap()
        {
            try
            {
                var manager = new QueryManager(AUTH);
                var res = await manager.GetInternalAsync("select * from TBLMUPLAN where AGM='M'");

                if (res.Data == null)
                {
                    return new SuccessDataResult<IEnumerable<MuhasebePlan>>(null, "Hesap planı Bulunamadı");
                }

                var resultList = new List<MuhasebePlan>();

                foreach (var item in res.Data)
                {
                    resultList.Add(new MuhasebePlan
                    {
                        HesapKodu = item.GetValue("HESAP_KODU").ToString(),
                        HesapAdi = item.GetValue("HS_ADI").ToString(),

                    });
                }

                return new SuccessDataResult<IEnumerable<MuhasebePlan>>(resultList);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<MuhasebePlan>>(null, ex.Message);
            }
        }
    }
}
