using KARYA.CORE.Concrete.EntityFramework;
using KARYA.CORE.Types.Return.Interfaces;
using Microsoft.EntityFrameworkCore;
using SAHIZA.DATAACCESS.Abstract;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SAHIZA.DATAACCESS.Concrete.EntityFramework
{
    public class DizaynDal : EfRepository<Dizayn, SahizaWorldContext>, IDizaynDal
    {
        public async Task<DizaynDto> GetWithDetail(Expression<Func<Dizayn, bool>> filter)
        {
            using(var context = new SahizaWorldContext())
            {
                var result = await context.Set<Dizayn>().Where(filter).Include(z => z.DizaynDetays).FirstOrDefaultAsync();

                return new DizaynDto
                {
                    Id = result.Id,
                    DizaynKodu = result.DizaynKodu,
                    DizaynAdi = result.DizaynAdi,
                    Aciklama = result.Aciklama,
                    DizaynDetays = result.DizaynDetays
                };
            }
        }

        public async Task<DizaynBelgeDto> GetForNewBelge(Expression<Func<Dizayn, bool>> filter)
        {
            using (var context = new SahizaWorldContext())
            {
                var result = await context.Set<Dizayn>().Where(filter).Include(z => z.DizaynDetays).FirstOrDefaultAsync();

                var dizaynBelges = new List<DizaynBelgeDetayDto>();

                foreach (var item in result.DizaynDetays)
                {
                    dizaynBelges.Add(new DizaynBelgeDetayDto { 
                        DizaynDetayId=item.Id,
                        Baslik=item.Baslik,
                        DataTipi=item.DataTipi,
                        Deger=item.Deger,
                        Sira=item.Sira
                        
                    });
                }

                return new DizaynBelgeDto
                {
                    DizaynId = result.Id,
                    DizaynKodu = result.DizaynKodu,
                    DizaynAdi = result.DizaynAdi,
                    DizaynAciklama = result.Aciklama,
                    BelgeDetayDtos = dizaynBelges
                };
            }
        }

        public async override Task UpdateComplex(Dizayn entity)
        {
            using (var context = new SahizaWorldContext())
            {
                var oldDetail = context.DizaynDetay.Where(x => x.DizaynId == entity.Id);

                foreach (var item in oldDetail.Where(x => !entity.DizaynDetays.Select(x=>x.Id).Contains(x.Id)))
                {
                    context.Set<DizaynDetay>().Remove(item);
                }

                context.Set<Dizayn>().Update(entity);

                await context.SaveChangesAsync();
                SCOPE_IDENTY_ID = entity.Id;

            }
        }
    }
}
