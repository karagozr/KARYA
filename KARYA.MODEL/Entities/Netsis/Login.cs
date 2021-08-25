using KARYA.MODEL.Enums.Netsis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.Entities.Netsis
{
    public class Login
    {
        public DbTypes DbType { get; set; }
        public string DbName { get; set; }
        public string DbUser { get; set; }
        public string DbPassword { get; set; }
        public string NetsisUser { get; set; }
        public string NetsisPassword { get; set; }
        public int BranchCode { get; set; }
        public string NetOpenXUrl { get; set; }
    }
}
