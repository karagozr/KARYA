using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.CORE.Entities
{
    public interface IModificationEntity
    {
        DateTime? CreatedTime { get; set; }

        DateTime? UpdatedTime { get; set; }

        int? CreatedUserId { get; set; }

        int? UpdatedUserId { get; set; }
    }
}
