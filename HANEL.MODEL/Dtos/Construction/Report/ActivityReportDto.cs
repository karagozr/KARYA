using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Construction.Report
{
    public class ActivityReportDto
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Description { get; set; }
        public double Actual { get; set; }
        public double Budget { get; set; }
    }
}
