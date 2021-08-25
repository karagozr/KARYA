using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.Dtos.Karya
{
    public class AuthorizeDetailWithAppModuleDto:AuthorizeGroupDetail
    {
        public int ModuleName { get; set; }
    }
}
