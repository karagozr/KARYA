using KARYA.CORE.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SAHIZA.DATAACCESS.Abstract;
using SAHIZA.MODEL.Dtos;
using SAHIZA.MODEL.Entities;
using SAHIZA.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SAHIZA.DATAACCESS.Concrete.EntityFramework
{
    public class StokHaraketDal : EfRepository<StokHaraket, SahizaWorldContext>, IStokHaraketDal
    {
        public override async Task<IEnumerable<StokHaraket>> List(Expression<Func<StokHaraket, bool>> filter)
        {
            using (var context = new SahizaWorldContext())
            {
                return  await (filter == null ? 
                    context.Set<StokHaraket>().Include(x => x.Stok).Include(x=>x.Cari).Select(x => new StokHaraketListDto
                    {
                        CariAdi =x.Cari.CariAdi,
                        CariId=x.CariId,
                        CreatedTime = x.CreatedTime,
                        Aciklama = x.Aciklama,
                        Birim = x.Stok.Birim,
                        StokAdi = x.Stok.StokAdi,
                        StokHaraketTur = x.StokHaraketTur,
                        Fiyat = x.Fiyat,
                        Miktar = x.Miktar,
                        Tutar = x.Tutar,
                        VergiOrani = x.VergiOrani,
                        StokId = x.StokId,
                        Id = x.Id
                    }).OrderByDescending(x=>x.CreatedTime).ToListAsync() :
                    context.Set<StokHaraket>().Where(filter).Include(x => x.Stok).Select(x => new StokHaraketListDto
                    {
                        CariAdi = x.Cari.CariAdi,
                        CariId = x.CariId,
                        CreatedTime = x.CreatedTime,
                        Aciklama = x.Aciklama,
                        Birim = x.Stok.Birim,
                        StokAdi = x.Stok.StokAdi,
                        StokHaraketTur = x.StokHaraketTur,
                        Fiyat = x.Fiyat,
                        Miktar = x.Miktar,
                        Tutar = x.Tutar,
                        VergiOrani = x.VergiOrani,
                        StokId = x.StokId,
                        Id = x.Id
                    }).OrderByDescending(x => x.CreatedTime).ToListAsync());
            }
        }

        public override async Task<StokHaraket> Get(Expression<Func<StokHaraket, bool>> filter)
        {
            using (var context = new SahizaWorldContext())
            {
                return await (filter == null ?
                    context.Set<StokHaraket>().Include(x => x.Stok).Select(x => new StokHaraketDto
                    {
                        CariAdi = x.Cari.CariAdi,
                        CariId = x.CariId,
                        CreatedTime = x.CreatedTime,
                        Aciklama = x.Aciklama,
                        Birim = x.Stok.Birim,
                        StokAdi = x.Stok.StokAdi,
                        StokHaraketTur = x.StokHaraketTur,
                        Fiyat = x.Fiyat,
                        Miktar = x.Miktar,
                        Tutar = x.Tutar,
                        VergiOrani = x.VergiOrani,
                        StokId = x.StokId,
                        Id = x.Id
                    }).FirstOrDefaultAsync() :
                    context.Set<StokHaraket>().Where(filter).Include(x => x.Stok).Select(x => new StokHaraketDto
                    {
                        CariAdi = x.Cari.CariAdi,
                        CariId = x.CariId,
                        CreatedTime = x.CreatedTime,
                        Aciklama = x.Aciklama,
                        Birim = x.Stok.Birim,
                        StokAdi = x.Stok.StokAdi,
                        StokHaraketTur = x.StokHaraketTur,
                        Fiyat = x.Fiyat,
                        Miktar = x.Miktar,
                        Tutar = x.Tutar,
                        VergiOrani = x.VergiOrani,
                        StokId = x.StokId,
                        Id = x.Id
                    }).FirstOrDefaultAsync());
            }
        }

        public async Task<IEnumerable<StokRaporDto>> ListStokKalan(Expression<Func<StokHaraket, bool>> filter)
        {
            using (var context = new SahizaWorldContext())
            {
                return filter != null ?
                    await context.Set<StokHaraket>().Where(filter).GroupBy(x => x.StokId).Select(x => new
                    {
                        StokId = x.Key,
                        Miktar = x.Sum(x => x.StokHaraketTur == StokHaraketTur.StokGiris ? x.Miktar : (x.StokHaraketTur == StokHaraketTur.StokCikis ? -1 * x.Miktar : 0))
                    }).Join(context.Set<Stok>(),
                        sh => sh.StokId,
                        st => st.Id,
                        (sh, st) => new StokRaporDto
                        {
                            StokId = st.Id,
                            StokAdi = st.StokAdi,
                            Birim = st.Birim,
                            Miktar = sh.Miktar
                        }).ToListAsync()
                    : await context.Set<StokHaraket>().GroupBy(x => x.StokId).Select(x => new
                    {
                        StokId = x.Key,
                        Miktar = x.Sum(x => x.StokHaraketTur == StokHaraketTur.StokGiris ? x.Miktar : (x.StokHaraketTur == StokHaraketTur.StokCikis ? -1 * x.Miktar : 0))
                    }).Join(context.Set<Stok>(),
                        sh => sh.StokId,
                        st => st.Id,
                        (sh, st) => new StokRaporDto
                        {
                            StokId = st.Id,
                            StokAdi = st.StokAdi,
                            Birim = st.Birim,
                            Miktar = sh.Miktar
                        }).ToListAsync();
            }
        }
    }
}
