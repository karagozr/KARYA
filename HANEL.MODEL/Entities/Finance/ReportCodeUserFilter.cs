using KARYA.CORE.Entities.Concrete;
using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Entities.Finance
{
    public class ReportCodeUserFilter : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        public string ProjectCode { get; set; }
        public string BranchCode { get; set; }

        [Required, StringLength(100)]
        public string IntegrationCode1 { get; set; }
        public string IntegrationCode2 { get; set; }
        public string IntegrationCode3 { get; set; }
        public bool AccessRead { get; set; } = true;
        public bool AccessAdd { get; set; } = false;
        public bool AccessUpdate { get; set; } = false;
        public bool AccessDelete { get; set; } = false;

    }
}
