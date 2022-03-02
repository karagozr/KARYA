using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.Dtos.AuthGroup
{
    public class AuthGroupDetailLDto
    {
        public int Id { get; set; }
        public int AuthorizeGroupId { get; set; }
        public int AppModuleParentId { get; set; }
        public int AppModuleId { get; set; }
        public string AppModuleName { get; set; }
        public bool IsAuthorize { get; set; }
    }
}
