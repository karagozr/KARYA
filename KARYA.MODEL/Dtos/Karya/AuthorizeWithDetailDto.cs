using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.Dtos.Karya
{
    public class AuthorizeGroupDto:AuthorizeGroup
    {
        public string AuthorizeGrupDetailJson { get; set; }
        public List<AuthorizeGroupDetail> AuthorizeGrupDetails { get; set; }
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
