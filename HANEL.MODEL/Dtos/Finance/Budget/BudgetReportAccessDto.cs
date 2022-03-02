using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Finance.Budget
{
    public class BudgetReportAccessDto
    {
        public bool AccessRead { get; set; }
        public bool AccessAdd { get; set; }
        public bool AccessUpdate { get; set; }
        public bool AccessDelete { get; set; }
    }
}
