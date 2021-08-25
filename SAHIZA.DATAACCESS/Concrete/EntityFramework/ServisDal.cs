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
                        MusteriBilgisi = x.MusteriBilgisi + " /" + x.Cari != null ? x.Cari.CariAdi : "",
                        UrunBilgisi = x.UrunBilgisi + " /" + x.Stok != null ? x.Stok.StokAdi : "",
                        BaslangicTarihi = x.CreatedTime,
                        SonGuncellemeTarihi = x.UpdatedTime,
                    }).OrderByDescending(x => x.SonGuncellemeTarihi).ToListAsync() :
                    context.Set<Servis>().Where(filter).Include(x => x.Stok).Include(x => x.Cari).Select(x => new ServisListDto
                    {
                        Id = x.Id,
                        ServisIslemTur = x.ServisIslemTur,
                        ServisDurum = x.ServisDurum,
                        DurumAciklama = x.Aciklama,
                        MusteriBilgisi = x.MusteriBilgisi + " /" + x.Cari != null ? x.Cari.CariAdi : "",
                        UrunBilgisi = x.UrunBilgisi + " /" + x.Stok != null ? x.Stok.StokAdi : "",
                        BaslangicTarihi = x.CreatedTime,
                        SonGuncellemeTarihi = x.UpdatedTime,
                    }).OrderByDescending(x => x.SonGuncellemeTarihi).ToListAsync() );
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
