using System.ComponentModel;

namespace KARYA.MODEL.Module
{
    public class BaseRole
    {

        [Description("Admin Panel")]
        public const int AdminPanel         = 1;

        [Description("User Control")]
        public const int UserControl        = 2;

        [Description("User Add")] 
        public const int UserAdd            = 3;

        [Description("User Edit")] 
        public const int UserEdit           = 4;

        [Description("User Delete")] 
        public const int UserDelete         = 5;

        [Description("Authorize Control")] 
        public const int AuthorizeModul     = 20;

        [Description("Authorize Add")] 
        public const int AuthorizeAdd       = 21;

        [Description("Authorize Edit")] 
        public const int AuthorizeEdit      = 22;

        [Description("Authorize Delete")] 
        public const int AuthorizeDelete    = 23;
    }
}
