using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KARYA.MODEL.DataTransferModels.HanelApp.Finance
{
    public class SaveBudgetModel
    {
        public string ProjectCode { get; set; }

        public string BudgetName { get; set; }

        public short BudgetYear { get; set; }

        public List<BudgetModel> BugdetList { get; set; }
    }
}
