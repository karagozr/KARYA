using KARYA.CORE.Entities.Abstarct;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KARYA.CORE.Entities.Concrete
{
    public class BaseEntity : CoreEntity, IBaseEntity
    {
        [Column(Order = 0), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
    }
}
