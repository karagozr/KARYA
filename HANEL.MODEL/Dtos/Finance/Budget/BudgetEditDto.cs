using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Finance.Budget
{
    public class BudgetEditDto:BudgetAddDto
    {
        public string DetailCodes { set
            {

                var ids = value != null ? value.Split("-"):"0-0-0-0-0-0-0-0-0-0-0-0".Split("-");
                DetailIdJanuary = Convert.ToInt32(ids[0]);
                DetailIdFebruary = Convert.ToInt32(ids[1]);
                DetailIdMarch = Convert.ToInt32(ids[2]);
                DetailIdApril = Convert.ToInt32(ids[3]);
                DetailIdMay = Convert.ToInt32(ids[4]);
                DetailIdJune = Convert.ToInt32(ids[5]);
                DetailIdJuly = Convert.ToInt32(ids[6]);
                DetailIdAugust = Convert.ToInt32(ids[7]);
                DetailIdSeptember = Convert.ToInt32(ids[8]);
                DetailIdOctober = Convert.ToInt32(ids[9]);
                DetailIdNovember = Convert.ToInt32(ids[10]);
                DetailIdDecember = Convert.ToInt32(ids[11]);
            }
        }
        public int BudgetId { get; set; }
        public int DetailIdJanuary { get; set; }
        public int DetailIdFebruary { get; set; }
        public int DetailIdMarch { get; set; }
        public int DetailIdApril { get; set; }
        public int DetailIdMay { get; set; }
        public int DetailIdJune { get; set; }
        public int DetailIdJuly { get; set; }
        public int DetailIdAugust { get; set; }
        public int DetailIdSeptember { get; set; }
        public int DetailIdOctober { get; set; }
        public int DetailIdNovember { get; set; }
        public int DetailIdDecember { get; set; }
    }
}
