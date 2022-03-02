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
    public class ServisDal : EfRepository<Servis, SahizaWorldContext>, IServisDal
    {
      
        public async Task<IEnumerable<ServisListDto>> List(Expression<Func<Servis, bool>> filter)
        {
            using (var context = new SahizaWorldContext())
            {
                return await (filter == null ?
                    context.Set<Servis>().Include(x => x.Stok).Include(x => x.Cari).Select(x => new ServisListDto
                    {
                        Id = x.Id,
                        ServisIslemTur = x.ServisIslemTur,
                        ServisDurum = x.ServisDurum,
                        DurumAciklama = x.Aciklama,
                        MusteriBilgisi = x.MusteriBilgisi,
                        UrunBilgisi = x.UrunBilgisi,
                        BaslangicTarihi = x.CreatedTime,
                        SonGuncellemeTarihi = x.UpdatedTime,
                    }).OrderByDescending(x => x.SonGuncellemeTarihi).ToListAsync() :
                    context.Set<Servis>().Where(filter).Include(x => x.Stok).Include(x => x.Cari).Select(x => new ServisListDto
                    {
                        Id = x.Id,
                        ServisIslemTur = x.ServisIslemTur,
                        ServisDurum = x.ServisDurum,
                        DurumAciklama = x.Aciklama,
                        MusteriBilgisi = x.MusteriBilgisi ,
                        UrunBilgisi = x.UrunBilgisi ,
                        BaslangicTarihi = x.CreatedTime,
                        SonGuncellemeTarihi = x.UpdatedTime,
                    }).OrderByDescending(x => x.SonGuncellemeTarihi).ToListAsync() );
            }
        }

        public async Task<ServisDto> Get(Expression<Func<Servis, bool>> filter)
        {
            using (var context = new SahizaWorldContext())
            {
                return await context.Set<Servis>().Include(x => x.Stok).Include(x => x.Cari).Where(filter).Select(x => new ServisDto
                    {
                        Id = x.Id,
                        ServisIslemTur = x.ServisIslemTur,
                        ServisDurum = x.ServisDurum,
                        Aciklama = x.Aciklama,
                        MusteriBilgisi = x.MusteriBilgisi,
                        UrunBilgisi = x.UrunBilgisi,
                        CreatedTime = x.CreatedTime,
                        UpdatedTime = x.UpdatedTime,
                        StokAdi=x.StokId==null?x.UrunBilgisi: x.Stok.StokAdi,
                        Not1=x.Not1,
                        Not2=x.Not2,
                        Tel1=x.Tel1,
                        StokHaraketId=x.StokHaraketId,
                        ToplamFiyat=x.ToplamFiyat,
                        ToplamTutar=x.ToplamTutar,
                        VergiOrani=x.VergiOrani,
                        CariId=x.CariId,
                        CariAdi= x.CariId == null ? x.MusteriBilgisi : x.Cari.CariAdi,
                        CreatedUserId=x.CreatedUserId,
                        UpdatedUserId=x.UpdatedUserId,
                        MusteriAdres=x.MusteriAdres,
                        StokId=x.StokId
                    }).FirstOrDefaultAsync();
            }
        }



        //public override async Task<StokHaraket> Get(Expression<Func<StokHaraket, bool>> filter)
        //{
        //    using (var context = new SahizaWorldContext())
        //    {
        //        return await (filter == null ?
        //            context.Set<StokHaraket>().Include(x => x.Stok).Select(x => new StokHaraketDto
        //            {
        //                CariAdi = x.Cari.CariAdi,
        //                CariId = x.CariId,
        //                CreatedTime = x.CreatedTime,
        //                Aciklama = x.Aciklama,
        //                Birim = x.Stok.Birim,
        //                StokAdi = x.Stok.StokAdi,
        //                StokHaraketTur = x.StokHaraketTur,
        //                Fiyat = x.Fiyat,
        //                Miktar = x.Miktar,
        //                Tutar = x.Tutar,
        //                VergiOrani = x.VergiOrani,
        //                StokId = x.StokId,
        //                Id = x.Id
        //            }).FirstOrDefaultAsync() :
        //            context.Set<StokHaraket>().Where(filter).Include(x => x.Stok).Select(x => new StokHaraketDto
        //            {
        //                CariAdi = x.Cari.CariAdi,
        //                CariId = x.CariId,
        //                CreatedTime = x.CreatedTime,
        //                Aciklama = x.Aciklama,
        //                Birim = x.Stok.Birim,
        //                StokAdi = x.Stok.StokAdi,
        //                StokHaraketTur = x.StokHaraketTur,
        //                Fiyat = x.Fiyat,
        //                Miktar = x.Miktar,
        //                Tutar = x.Tutar,
        //                VergiOrani = x.VergiOrani,
        //                StokId = x.StokId,
        //                Id = x.Id
        //            }).FirstOrDefaultAsync());
        //    }
        //}
    }
}
