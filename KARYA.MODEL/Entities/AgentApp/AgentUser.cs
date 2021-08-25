using KARYA.MODEL.Entities.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Entities.AgentApp
{
    public class AgentUser : BaseEntity
    {
        public string AgentGuid { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string LisanceKey { get; set; }

        public string MachineName { get; set; }
    }

    public class AgentBackUpDirectory : BaseEntity
    {
        public string AgentGuid { get; set; }
        public string MachineName { get; set; }
        public string SyncPath { get; set; }
    }
}
