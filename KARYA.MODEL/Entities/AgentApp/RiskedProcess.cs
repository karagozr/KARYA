using KARYA.MODEL.Entities.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Entities.AgentApp
{
    public class RiskedProcess: BaseEntity
    {
        public string Name { get; set; }
        public float RiskScore { get; set; }
    }
}
