using HANEL.MODEL.Dtos.Muhasebe;
using HANEL.MODEL.Entities.Muhasebe.Erp;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.Netsis;
using NetOpenX.Rest.Client.BLL;
using NetOpenX.Rest.Client.Model.Enums;
using NetOpenX.Rest.Client.Model.NetOpenX;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Accounting.Netsis.NetOpenX
{
    public class NetsisCariService : NetsisBaseService
    {
        ARPsManager _manager;
        
        public NetsisCariService(Login login) : base(login)
        {
            _manager = new ARPsManager(AUTH);
        }
        public async Task<IDataResult<ErpCari>> AddCari(ErpCari erpCari)
        {
            try
            {
                ARPs cari = new ARPs {
                    IsletmelerdeOrtak = true,
                    SubelerdeOrtak = true,
                    CariTemelBilgi =new ARPsPrimInfo
                    {
                        CARI_KOD    = erpCari.Id,
                        CARI_ISIM   = erpCari.Name,
                        CARI_TIP    = erpCari.CariType,
                        ACIK1       = string.IsNullOrEmpty(erpCari.Description1)?"": erpCari.Description1,
                        ACIK2       = string.IsNullOrEmpty(erpCari.Description2) ? "" : erpCari.Description2,
                        ACIK3       = string.IsNullOrEmpty(erpCari.Description3) ? "" : erpCari.Description3,
                        CARI_ADRES  = string.IsNullOrEmpty(erpCari.Adress) ? "" : erpCari.Adress,
                        CARI_IL     = string.IsNullOrEmpty(erpCari.City) ? "" : erpCari.City,
                        CARI_TEL    = string.IsNullOrEmpty(erpCari.PhoneNo) ? "" : erpCari.PhoneNo,
                        CARI_ILCE   = string.IsNullOrEmpty(erpCari.District) ? "" : erpCari.District,
                        EMAIL       = string.IsNullOrEmpty(erpCari.EMail) ? "" : erpCari.EMail,
                        WEB         = string.IsNullOrEmpty(erpCari.Web) ? "" : erpCari.Web,
                        VERGI_DAIRESI = string.IsNullOrEmpty(erpCari.TaxRoom) ? "" : erpCari.TaxRoom,
                        VERGI_NUMARASI = string.IsNullOrEmpty(erpCari.TaxNumber) ? "" : erpCari.TaxNumber,
                        CM_RAP_TARIH = DateTime.Now
                    },
                    CariEkBilgi= new ARPsSuppInfo
                    {
                        CARI_KOD = erpCari.Id,
                        TcKimlikNo = string.IsNullOrEmpty(erpCari.IdNumber)?"": erpCari.IdNumber,
                    }
                
                };
                

                var result =  await _manager.DeleteInternalByIdAsync(cari.CariTemelBilgi.CARI_KOD);
                var result1 = await _manager.PostInternalAsync(cari);
                var subeOrtak = result1.Data.SubelerdeOrtak.GetValueOrDefault();

                if (!result1.IsSuccessful)
                {
                    return new ErrorDataResult<ErpCari>("NetopenX hata : " + result.ErrorDesc);
                }

                return new SuccessDataResult<ErpCari>(erpCari);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ErpCari>(ex.Message);
            }
            


        }
        
       
    }
}


