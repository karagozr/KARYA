using KARYA.MODEL.Entities.Base.Abstarct;
using KARYA.MODEL.Entities.Base.Concrete;
using KARYA.MODEL.Enums.Karya;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Entities.Karya
{
    public class AuthorizeGroup : BaseEntity , ILogEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }
        public IEnumerable<UserAuthorizeGroup> UserAuthorizeGroups { get; set; }
        public IEnumerable<AuthorizeGroupDetail> AuthorizeGroupDetails { get; set; }
    }
    //Id	AuthGroupId	ModulId	Rule	FieldName	FilterValue

    public class AuthorizeGroupDetail : BaseEntity
    {
        public int AuthorizeGroupId { get; set; }
        public int AppModuleId { get; set; }
        public bool IsAuthorize { get; set; }
        public FilterRule FilterRule { get; set; }
        public string FieldName { get; set; }
        public string FilterValue1 { get; set; }
        public string FilterValue2 { get; set; }
        public AppModule AppModule { get; set; }
        public AuthorizeGroup AuthorizeGroup { get; set; }

        public IEnumerable<AuthorizeGroupDetailFieldAccess> AuthorizeGroupDetailFieldAccessList { get; set; }
    }

    public class AuthorizeGroupDetailFieldAccess : BaseEntity
    {
        public int AuthorizeGroupDetailId { get; set; }
        public string ProjectCode { get; set; }
        public string BudgetsubCode { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Delete { get; set; }
        public AuthorizeGroupDetail AuthorizeGroupDetail { get; set; }
    }
}
