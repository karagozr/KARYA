using KARYA.CORE.Concrete.EntityFramework;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using Microsoft.EntityFrameworkCore;
using SAHIZA.BUSINESS.Abstarct;
using SAHIZA.DATAACCESS.Abstract;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SAHIZA.BUSINESS.Concrete
{
    public class StokManager : BaseManager<Stok>, IStokManager
    {
        IStokDal _stokDal;
        public StokManager(IStokDal stokDal) : base(stokDal) => _stokDal = stokDal;

        public async Task<IDataResult<IEnumerable<Stok>>> Select(StokFilterDto stokFilterDto)
        {
            try
            {
                if (string.IsNullOrEmpty(stokFilterDto.StokKodu) && string.IsNullOrEmpty(stokFilterDto.StokAdi) && string.IsNullOrEmpty(stokFilterDto.Birim)&& stokFilterDto.StokDurum == 0)
                    return new SuccessDataResult<IEnumerable<Stok>>(null,"kayıt yok");
                var query = _stokDal.Select();

                if (!string.IsNullOrEmpty(stokFilterDto.StokKodu)) query = query.Where(x=>x.StokKodu.Contains(stokFilterDto.StokKodu));
                if (!string.IsNullOrEmpty(stokFilterDto.StokAdi)) query = query.Where(x => x.StokAdi.Contains(stokFilterDto.StokAdi));
                if (!string.IsNullOrEmpty(stokFilterDto.Birim)) query = query.Where(x => x.Birim.Contains(stokFilterDto.Birim));
                if (stokFilterDto.StokDurum!=0) query = query.Where(x => x.StokDurum == stokFilterDto.StokDurum);

                var result = await query.ToListAsync();

                return new SuccessDataResult<IEnumerable<Stok>>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Stok>>(null, ex.Message);
            }
        }
    }
}
