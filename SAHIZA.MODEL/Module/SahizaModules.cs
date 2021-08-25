﻿using KARYA.MODEL.Entities.Karya;
using KARYA.MODEL.Module;
using System;

namespace SAHIZA.MODEL.Module
{
    public class SahizaModules: CoreModules
    {
        public SahizaModules()
        {

            #region STOK
            ModuleList.Add(new AppModule() { Id = SahizaRole.StokModule, ParentId = 0, Name = "Stok Module" });
            //ModuleList.Add(new AppModule() { Id = SahizaRole.StokAdd,           ParentId = SahizaRole.StokModule,       Name = SahizaRole.StokAdd.Description()            });
            ModuleList.Add(new AppModule() { Id = SahizaRole.StokUpdate, ParentId = SahizaRole.StokModule, Name = "Stok Edit" });
            ModuleList.Add(new AppModule() { Id = SahizaRole.StokDelete, ParentId = SahizaRole.StokModule, Name = "Stok Delete" });
            #endregion

            #region CARI
            ModuleList.Add(new AppModule() { Id = SahizaRole.CariModule, ParentId = 0, Name = "Cari Module" });
            //ModuleList.Add(new AppModule() { Id = SahizaRole.CariAdd,           ParentId = SahizaRole.CariModule,       Name = SahizaRole.CariAdd.Description()            });
            ModuleList.Add(new AppModule() { Id = SahizaRole.CariUpdate, ParentId = SahizaRole.CariModule, Name = "Cari Edit" });
            ModuleList.Add(new AppModule() { Id = SahizaRole.CariDelete, ParentId = SahizaRole.CariModule, Name = "Cari Delete" });
            #endregion

            #region STOK_HARAKET
            ModuleList.Add(new AppModule() { Id = SahizaRole.StokHaraketModule, ParentId = 0, Name = "Stok Haraket Module" });
            //ModuleList.Add(new AppModule() { Id = SahizaRole.StokHaraketAdd,    ParentId = SahizaRole.StokHaraketModule,Name = SahizaRole.StokHaraketAdd.Description()     });
            ModuleList.Add(new AppModule() { Id = SahizaRole.StokHaraketUpdate, ParentId = SahizaRole.StokHaraketModule, Name = "Stok Haraket Edit" });
            ModuleList.Add(new AppModule() { Id = SahizaRole.StokHaraketDelete, ParentId = SahizaRole.StokHaraketModule, Name = "Stok Haraket Delete" });
            #endregion

            #region DIZAYN
            ModuleList.Add(new AppModule() { Id = SahizaRole.DizaynModule, ParentId = 0, Name = "Dizayn Module" });
            //ModuleList.Add(new AppModule() { Id = SahizaRole.StokHaraketAdd,    ParentId = SahizaRole.StokHaraketModule,Name = SahizaRole.StokHaraketAdd.Description()     });
            ModuleList.Add(new AppModule() { Id = SahizaRole.DizaynUpdate, ParentId = SahizaRole.DizaynModule, Name = "Dizayn Edit" });
            ModuleList.Add(new AppModule() { Id = SahizaRole.DizaynDelete, ParentId = SahizaRole.DizaynModule, Name = "Dizayn Delete" });
            #endregion
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}