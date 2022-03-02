using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.Dtos.User
{
    public class UserSDto
    {
        public int Id { get; set; }
        public int? UserGroupId { get; set; }
        public int? UserGroupName { get; set; }
        public bool Enable { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Lastname { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(10)]
        public string Password { get; set; }

        [StringLength(30)]
        public string EMail { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
        public IEnumerable<int> AuthorizeGroups { get; set; }
    }
}
