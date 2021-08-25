using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KARYA.MODEL.DataTransferModels.HanelApp.Finance
{
    public class PivotTemplateModel
    {
        public int Id { get; set; }
        public string ReportName { get; set; }
        public string JsonData { get; set; }
    }
}
