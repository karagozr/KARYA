using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.Dtos.User
{
    public class UserLDto
    {
        public int Id { get; set; }
        public int? UserGroupId { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string UserName { get; set; }


        public string EMail { get; set; }

        public string Description { get; set; }
    }
}
