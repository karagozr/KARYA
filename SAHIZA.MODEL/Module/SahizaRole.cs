using KARYA.MODEL.Module;
using System.ComponentModel;

namespace SAHIZA.MODEL.Module
{
    public class SahizaRole:BaseRole
    {
        [Description("Stok Module")]
        public const int StokModule = 100;

        [Description("Stok Entry Edit")]
        public const int StokUpdate = 1002;

        [Description("Stok Entry Delete")]
        public const int StokDelete = 102;
        /// <summary>
        /// ///////////////////////
        /// </summary>
        [Description("Cari Module")]
        public const int CariModule = 200;

        [Description("Cari Entry Edit")]
        public const int CariUpdate = 2002;

        [Description("Cari Entry Delete")]
        public const int CariDelete = 2003;
        /// <summary>
        /// /////////////////////
        /// </summary>
        [Description("StokHaraket Module")]
        public const int StokHaraketModule = 300;

        [Description("StokHaraket Entry Edit")]
        public const int StokHaraketUpdate = 3002;

        [Description("StokHaraket Entry Delete")]
        public const int StokHaraketDelete = 3003;

        [Description("Stok Rapor")]
        public const int StokRapor = 3004;
        /// <summary>
        /// /////////////////////
        /// </summary>
        [Description("Dizayn Module")]
        public const int DizaynModule = 400;

        [Description("Dizayn Entry Edit")]
        public const int DizaynUpdate = 4002;

        [Description("Dizayn Entry Delete")]
        public const int DizaynDelete = 4003;
        /// <summary>
        /// /////////////////////
        /// </summary>
        [Description("Belge Module")]
        public const int BelgeModule = 500;

        [Description("Belge Entry Edit")]
        public const int BelgeUpdate = 5002;

        [Description("Belge Entry Delete")]
        public const int BelgeDelete = 5003;
        /// <summary>
        /// /////////////////////
        /// </summary>
        [Description("Servis Module")]
        public const int ServisModule = 600;

        [Description("Servis Entry Edit")]
        public const int ServisUpdate = 6002;

        [Description("Servis Entry Delete")]
        public const int ServisDelete = 6003;




    }
}
