using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.MODEL.DataTransferModels.Finance
{
    public class SaveBudgetModel
    {
        public string ProjectCode { get; set; }

        public string BudgetName { get; set; }

        public short BudgetYear { get; set; }

        public List<BudgetModel> BugdetList { get; set; }
    }
}
