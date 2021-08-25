using System;
using System.ComponentModel;

namespace KARYA.MODEL.Authorize.SahizaWorld
{
    [Flags]
    public enum AppRole : int
    {
        [Description("Admin Module")]                  AdminModul           = 1,
        [Description("User Control")]                  UserModul            = 10,
        [Description("User Add")]                      UserAdd              = 11,
        [Description("User Edit")]                     UserEdit             = 12,
        [Description("User Delete")]                   UserDelete           = 13,
        [Description("Authorize Control")]             AuthorizeModul       = 20,
        [Description("Authorize Add")]                 AuthorizeAdd         = 21,
        [Description("Authorize Edit")]                AuthorizeEdit        = 22,
        [Description("Authorize Delete")]              AuthorizeDelete      = 23,

        [Description("Stok Module")]                   StokModule           = 100,
        //[Description("Stok Entry Add")]                StokAdd              = 1001,
        [Description("Stok Entry Edit")]               StokUpdate           = 1002,
        [Description("Stok Entry Delete")]             StokDelete           = 1003,
                                                                            
        [Description("Cari Module")]                   CariModule           = 200,
        //[Description("Cari Entry Add")]                CariAdd              = 2001,
        [Description("Cari Entry Edit")]               CariUpdate           = 2002,
        [Description("Cari Entry Delete")]             CariDelete           = 2003,
                                                                            
        [Description("StokHaraket Module")]            StokHaraketModule    = 300,
        //[Description("StokHaraket Entry Add")]         StokHaraketAdd       = 3001,
        [Description("StokHaraket Entry Edit")]        StokHaraketUpdate    = 3002,
        [Description("StokHaraket Entry Delete")]      StokHaraketDelete    = 3003,


    }

}
