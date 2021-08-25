using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KARYA.MODEL.DataTransferModels.Karya.Finance.Admin
{
    public class AuthorizeGrupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorizeGrupDetailJson { get; set; }
        public List<AuthorizeGrupDetailModel> AuthorizeGrupDetailModels { get; set; }
    }
    public class AuthorizeGrupDetailModel
    {
        public int Id { get; set; }
        public int AuthorizeGroupId { get; set; }
        public int AppModuleId { get; set; }
        public bool IsAuthorize { get; set; }
    }

    public class AuthorizeGrupDetailFilterModel
    {
        public int Id { get; set; }
        public int AuthorizeGrupDetailId { get; set; }
        public string ProjectCode { get; set; }
        public string BudgetsubCode { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Delete { get; set; }
    }
}
