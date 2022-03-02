using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Finance.Budget
{
    public class BudgetProjectListDto
    {
        public string ProjectGroup { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public bool Status { get; set; }
    }
}
