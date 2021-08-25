using KARYA.MODEL.Entities.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.Entities.HanelApp
{
    public class Company : BaseEntityEnableCode
    {
        public string Name { get; set; }
        public string Vkn { get; set; }
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }
        public string Parameter3 { get; set; }
        public string Parameter4 { get; set; }
    }
}
