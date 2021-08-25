using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.DataTransferModels.Karya.Admin
{
    public class UserEditModel
    {
        public Users User { get; set; }
        public List<AuthorizeGroup> AuthorizeGroups { get; set; }
    }
}
