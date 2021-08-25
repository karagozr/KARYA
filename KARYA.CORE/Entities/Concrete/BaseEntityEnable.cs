using KARYA.CORE.Entities.Abstarct;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KARYA.CORE.Entities.Concrete
{
    public class BaseEntityEnable : BaseEntity, IBaseEntityEnable
    {
        [Column(Order = 1), Required]
        public bool Enable { get; set; }
    }
}
