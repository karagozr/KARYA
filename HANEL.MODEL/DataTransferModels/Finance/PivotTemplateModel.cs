using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.MODEL.DataTransferModels.Finance
{
    public class PivotTemplateModel
    {
        public int Id { get; set; }
        public string ReportName { get; set; }
        public string JsonData { get; set; }
    }
}
