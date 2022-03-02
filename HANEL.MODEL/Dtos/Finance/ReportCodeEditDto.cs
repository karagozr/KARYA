using KARYA.CORE.Entities.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Finance
{
    public class ReportCodeEditDto: IEditEntity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string OrderCode { get; set; }
        public string Name { get; set; }
        public bool IsReportCode { get; set; }
        public string IntegrationCode1 { get; set; }
        public string IntegrationCode2 { get; set; }
        public string IntegrationCode3 { get; set; }
        public bool IsExpanded { get; set; }
        public string ColorCode { get; set; }
        public bool Inserted { get; set; }
        public bool Updated { get; set; }
        public bool Deleted { get; set; }
    }
}
