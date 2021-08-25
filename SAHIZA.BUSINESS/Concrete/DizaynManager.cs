using KARYA.CORE.Concrete.EntityFramework;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using Newtonsoft.Json;
using SAHIZA.BUSINESS.Abstarct;
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
    public class DizaynManager : BaseManager<Dizayn>, IDizaynManager
    {
        IDizaynDal _dizaynDal;
        public DizaynManager(IDizaynDal dizaynDal) : base(dizaynDal) => _dizaynDal = dizaynDal;

        public async Task<IDataResult<DizaynDto>> GetByIdWithDetay(int id)
        {
            try
            {
                var result = await _dizaynDal.GetWithDetail(x => x.Id == id);
                result.DetayListJson= JsonConvert.SerializeObject(result.DizaynDetays.Select(x=>new {Id=x.Id,DataTipiText= x.DataTipi.ToString(), Baslik=x.Baslik,DataTipi=x.DataTipi,DizaynId=x.DizaynId,Sira=x.Sira,Deger=x.Deger }).ToList(), Formatting.Indented);
                return new SuccessDataResult<DizaynDto>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<DizaynDto>(null, ex.Message);
            }
        }

        public async Task<IDataResult<DizaynBelgeDto>> GetByIdForNewBelge(int id)
        {
            try
            {
                var result = await _dizaynDal.GetForNewBelge(x => x.Id == id);
                return new SuccessDataResult<DizaynBelgeDto>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<DizaynBelgeDto>(null, ex.Message);
            }
        }

        public async Task<IResult> AddUpdateComplex(DizaynDto dizaynDto)
        {
            try
            {
                var detayList = JsonConvert.DeserializeObject<List<DizaynDetay>>(dizaynDto.DetayListJson);
                var _sira = 1;
                foreach (var item in detayList.OrderBy(x=>x.Sira))
                {
                    item.Sira = _sira;
                    _sira++;
                }

                if (dizaynDto.Id == 0)
                {
                    dizaynDto.DizaynDetays = detayList;
                    await _dizaynDal.AddComplex(dizaynDto);

                    return new SuccessResult();
                }
                else
                {
                    dizaynDto.DizaynDetays = detayList;

                    await _dizaynDal.UpdateComplex(dizaynDto);

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
