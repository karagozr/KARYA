using KARYA.CORE.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SAHIZA.DATAACCESS.Abstarct;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SAHIZA.DATAACCESS.Concrete.EntityFramework
{
    public class BelgeDal : EfRepository<Belge, SahizaWorldContext>, IBelgeDal
    {
        public async Task<DizaynBelgeDto> GetWithDetail(Expression<Func<Belge, bool>> filter)
        {
            using (var context = new SahizaWorldContext())
            {
                var result = await context.Set<Belge>().Where(filter).Include(z => z.Dizayn).Include(y => y.BelgeDetays).ThenInclude(w => w.DizaynDetay).FirstOrDefaultAsync();


                var detays = result.BelgeDetays;

                var detayDtos = new List<DizaynBelgeDetayDto>();

                foreach (var item in detays)
                {
                    detayDtos.Add(new DizaynBelgeDetayDto
                    {
                        BelgeDetayId = item.Id,
                        BelgeId = item.BelgeId,
                        Sira =item.DizaynDetay.Sira,
                        Baslik = item.DizaynDetay.Baslik,
                        DataTipi=item.DizaynDetay.DataTipi,
                        DizaynDetayId=item.DizaynDetay.Id,
                        Text=item.Text,
                        Number=item.Number,
                        DecimalNumber=item.DecimalNumber,
                        DateTime=item.DateTime,
                        Bool=item.Bool,
                        Not1=item.Not1,
                        Deger=item.DizaynDetay.Deger,

                    });

                }

                return new DizaynBelgeDto
                {
                    BelgeId = result.Id,
                    DizaynId =result.DizaynId,
                    BelgeAdi = result.Adi,
                    Not1=result.Not1,
                    Not2=result.Not2,
                    BelgeAciklama= result.Aciklama,
                    DizaynAciklama=result.Dizayn.Aciklama,
                    DizaynAdi=result.Dizayn.DizaynAdi,
                    BelgeDetayDtos = detayDtos
                };
            }
        }

        //public async override Task UpdateComplex(Belge entity)
        //{
        //    using (var context = new SahizaWorldContext())
        //    {
        //        var oldDetail = context.DizaynDetay.Where(x => x.DizaynId == entity.Id);

        //        foreach (var item in oldDetail.Where(x => !entity.DizaynDetays.Select(x=>x.Id).Contains(x.Id)))
        //        {
        //            context.Set<DizaynDetay>().Remove(item);
        //        }

        //        context.Set<Dizayn>().Update(entity);

        //        await context.SaveChangesAsync();
        //        SCOPE_IDENTY_ID = entity.Id;

        //    }
        //}

        
    }
}
