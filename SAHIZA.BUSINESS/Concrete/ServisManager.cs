using KARYA.CORE.Concrete.EntityFramework;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using SAHIZA.BUSINESS.Abstarct;
using SAHIZA.DATAACCESS.Abstarct;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAHIZA.BUSINESS.Concrete
{
    public class ServisManager : BaseManager<Servis>, IServisManager 
    { 
        IServisDal _servisDal;
        public ServisManager(IServisDal servisDal) : base(servisDal) => _servisDal = servisDal;
        public async Task<IDataResult<ServisDto>> GetBakimById(int id)
        {
            try
            {
                var result = await _servisDal.Get(x=>x.Id==id);

                return new SuccessDataResult<ServisDto>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ServisDto>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<ServisListDto>>> List(ServisFiltreDto servisFiltreDto)
        {
            try
            {
                var result = await _servisDal.List(null);
               
                return new SuccessDataResult<IEnumerable<ServisListDto>> (result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<ServisListDto>>(ex.Message);
            }
        }

        public async Task<IResult> AddUpdateBakim(ServisDto servisDto)
        {
            try
            {
                await _servisDal.AddUpdate(new Servis { 
                    Aciklama=servisDto.Aciklama,
                    CariId=servisDto.CariId == 0 ? null : servisDto.CariId,
                    CreatedTime=servisDto.CreatedTime,
                    CreatedUserId=servisDto.CreatedUserId,
                    Id=servisDto.Id,
                    MusteriAdres=servisDto.MusteriAdres,
                    MusteriBilgisi= servisDto.CariAdi,
                    Not1=servisDto.Not1,
                    Not2=servisDto.Not2,
                    ServisDurum=servisDto.ServisDurum,
                    ServisIslemTur=servisDto.ServisIslemTur,
                    StokHaraketId=servisDto.StokHaraketId,
                    StokId=servisDto.StokId == 0 ? null : servisDto.StokId,
                    Tel1=servisDto.Tel1,
                    //ToplamFiyat=servisDto.ToplamFiyat,
                    //ToplamTutar=servisDto.ToplamTutar,
                    //VergiOrani=servisDto.VergiOrani,
                    UrunBilgisi=servisDto.StokAdi,
                    UpdatedTime=servisDto.UpdatedTime,
                    UpdatedUserId=servisDto.UpdatedUserId
                });
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
