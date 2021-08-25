using KARYA.MODEL.Entities.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Entities.AgentApp
{
    public class ProcessLog : BaseEntity
    {
        public string AgentGuid { get; set; }
        public int Pid { get; set; }
        public string ProcessType { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public string ProductName { get; set; }
        public long Size { get; set; }
        public string Language { get; set; }
    }
}
