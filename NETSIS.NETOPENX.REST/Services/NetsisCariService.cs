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
    public class NetsisCariService:NetsisBaseService
    {
        ARPsManager _ARPsManager;
    
        public NetsisCariService(Login login) : base(login)
        {
            _ARPsManager = new ARPsManager(AUTH);
        }

        public async Task<IDataResult<IEnumerable<Cari>>> List()
        {
            try
            {
                

                var _queryManager = new QueryManager(AUTH);


                var query =  $" select C.CARI_KOD as CariKodu, CARI_ISIM as CariUnvan, VERGI_NUMARASI as VergiDairesi,  " +
                        $" VERGI_NUMARASI as Vkn ,Ce.TCKIMLIKNO as Tckn from TBLCASABIT as C " +
                        $" left join TBLCASABITEK as CE on C.CARI_KOD = CE.CARI_KOD ";
                   
                var result = await _queryManager.GetInternalAsync(query);

                var resultList = result.Data.Select(x => new Cari
                {
                    CariKodu = x.GetValue("CariKodu").ToString(),
                    CariUnvan = x.GetValue("CariUnvan").ToString(),
                    Vkn = x.GetValue("Vkn").ToString(),
                    VergiDairesi = x.GetValue("VergiDairesi").ToString(),
                    Tckn = x.GetValue("Tckn").ToString()

                });

                

                return new SuccessDataResult<IEnumerable<Cari>>(resultList);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<IEnumerable<Cari>>(null, ex.Message);
            }
        }

        public async Task<IDataResult<Cari>> GetFromVkn(string vknNo)
        {
            try
            {
                var result = await _ARPsManager.GetInternalAsync(new SelectFilter
                {
                    Limit = 999999999,
                    Filter = $"VERGI_NUMARASI = '{vknNo}'"
                });

                var cari = result.Data.FirstOrDefault();

                if (cari == null) return new SuccessDataResult<Cari>(new Cari());

                return new SuccessDataResult<Cari>(new Cari
                {
                    CariKodu = cari.CariTemelBilgi.CARI_KOD,
                    CariUnvan = cari.CariTemelBilgi.CARI_ISIM,
                    Vkn = cari.CariTemelBilgi.VERGI_NUMARASI,
                    VergiDairesi = cari.CariTemelBilgi.VERGI_DAIRESI,
                    Tckn = cari.CariEkBilgi.TcKimlikNo
                });
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Cari>(null, ex.Message);
            }
        }

        public async Task<IDataResult<Cari>> GetById(string cariKodu)
        {
            try
            {
                //var result = await _ARPsManager.GetInternalByIdAsync(cariKodu);
                var _queryManager = new QueryManager(AUTH);


                var query = $" select C.CARI_KOD as CariKodu, CARI_ISIM as CariUnvan, VERGI_NUMARASI as VergiDairesi,  " +
                        $" VERGI_NUMARASI as Vkn ,Ce.TCKIMLIKNO as Tckn from TBLCASABIT as C " +
                        $" left join TBLCASABITEK as CE on C.CARI_KOD = CE.CARI_KOD where C.CARI_KOD='{cariKodu}'";

                var result = await _queryManager.GetInternalAsync(query);

                var cari = result.Data.FirstOrDefault();

                return new SuccessDataResult<Cari>(new Cari
                {
                    CariKodu = cari.GetValue("CariKodu").ToString(),
                    CariUnvan = cari.GetValue("CariUnvan").ToString(),
                    Vkn = cari.GetValue("Vkn").ToString(),
                    VergiDairesi = cari.GetValue("VergiDairesi").ToString(),
                    Tckn = cari.GetValue("Tckn").ToString()
                });
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Cari>(null, ex.Message);
            }
        }
    }
}
