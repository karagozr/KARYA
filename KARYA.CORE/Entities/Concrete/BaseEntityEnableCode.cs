using KARYA.CORE.Entities.Abstarct;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KARYA.CORE.Entities.Concrete
{
    public class BaseEntityEnableCode : BaseEntityEnable,IBaseEntityEnableCode
    {
        [Column(Order = 2), Required, StringLength(30)]
        public string Code { get; set; }
    }
}
