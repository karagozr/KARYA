using KARYA.CORE.Concrete.EntityFramework;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using Newtonsoft.Json;
using SAHIZA.BUSINESS.Abstarct;
using SAHIZA.DATAACCESS.Abstarct;
using SAHIZA.DATAACCESS.Abstract;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using SAHIZA.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAHIZA.BUSINESS.Concrete
{
    public class BelgeManager : BaseManager<Belge>, IBelgeManager
    {
        IBelgeDal _belgeDal;
        public BelgeManager(IBelgeDal belgeDal) : base(belgeDal) => _belgeDal = belgeDal;

        public async Task<IDataResult<DizaynBelgeDto>> GetByIdWithDetay(int id)
        {
            try
            {
                var result = await _belgeDal.GetWithDetail(x => x.Id == id);
                //result.DetayListJson= JsonConvert.SerializeObject(result.DizaynDetays.Select(x=>new {Id=x.Id,DataTipiText= x.DataTipi.ToString(), Baslik=x.Baslik,DataTipi=x.DataTipi,DizaynId=x.DizaynId,Sira=x.Sira }).ToList(), Formatting.Indented);
                return new SuccessDataResult<DizaynBelgeDto>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<DizaynBelgeDto>(null, ex.Message);
            }
        }

        public async Task<IResult> AddUpdateComplex(DizaynBelgeDto dizaynDto)
        {
            try
            {
                var belge = new Belge { 
                    Id=dizaynDto.BelgeId,
                    Adi=dizaynDto.BelgeAdi,
                    Aciklama=dizaynDto.BelgeAciklama,
                    DizaynId=dizaynDto.DizaynId
                };

                var detayList = new List<BelgeDetay>();
                

                foreach (var item in dizaynDto.BelgeDetayDtos)
                {
                    detayList.Add(new BelgeDetay {
                        Id=item.BelgeDetayId,
                        Bool=item.Bool,
                        DecimalNumber=item.DecimalNumber,
                        Number=item.Number,
                        DateTime=item.DateTime,
                        Text=item.Text,
                        Not1=item.Not1,
                        DizaynDetayId=item.DizaynDetayId
                    });
                }

                belge.BelgeDetays = detayList;

                //tarık ay ve birkay korku  hepsi
                //yalçın turan call center

                if (belge.Id == 0)
                {
                    await _belgeDal.AddComplex(belge);

                    return new SuccessResult();
                }
                else
                {

                    await _belgeDal.UpdateComplex(belge);

                    return new SuccessResult();
                }


            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

    }
   
}
