using System.ComponentModel;

namespace KARYA.MODEL.Module
{
    public class BaseRole
    {

        [Description("Admin Panel")]
        public const int AdminPanel = 1;

        [Description("User Control")]
        public const int UserControl = 2;

        [Description("User Add")]
        public const int UserAdd = 3;

        [Description("User Edit")]
        public const int UserUpdate = 4;

        [Description("User Delete")]
        public const int UserDelete = 5;

        [Description("Authorize Control")]
        public const int AuthorizeModul = 20;

        [Description("Authorize Add")]
        public const int AuthorizeAdd = 21;

        [Description("Authorize Edit")]
        public const int AuthorizeEdit = 22;

        [Description("Authorize Delete")]
        public const int AuthorizeDelete = 23;

        [Description("Admin Modülü")] public const int AdminModule = 10000;
        [Description("Kullanıcı Paneli")] public const int UserPanel = 11000;
        [Description("Kullanıcı Ekle/Düzenle")] public const int UserEdit = 11004;
        [Description("Parola Sıfırla")] public const int UserResetPassword = 11007;
        [Description("Yetki Grubu Paneli")] public const int AuthGroupPanel = 12000;
        [Description("Yetki Grubu Sil")] public const int AuthGroupDelete = 12003;
        [Description("Yetki Grubu Ekle/Düzenle")] public const int AuthGroupEdit = 12004;
    }
}
