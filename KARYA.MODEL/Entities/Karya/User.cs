using KARYA.MODEL.Entities.Base.Abstarct;
using KARYA.MODEL.Entities.Base.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace KARYA.MODEL.Entities.Karya
{
    public class Users:BaseEntityEnableCode, ILogEntity
    {
        public int? UserGroupId { get; set; }

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

        public DateTime? CreatedTime { get; set; }
        
        public DateTime? UpdatedTime { get; set; }
        
        public int? CreatedUserId { get; set; }
        
        public int? UpdatedUserId { get; set; }

        public IEnumerable<UserAuthorizeGroup> UserAuthorizeGroups { get; set; }


    }


    public class UserAuthorizeGroup : BaseEntity
    {
        public int UserId { get; set; }

        public int AuthorizeGroupId { get; set; }

        public Users User { get; set; }

        public AuthorizeGroup AuthorizeGroup { get; set; }

    }
}
