using KARYA.MODEL.Authorize.Karya;
using KARYA.MODEL.Entities.Base.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KARYA.MODEL.Entities.Karya
{
    public class AppModule : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public bool DefaultAuthorize { get; set; }
        public bool RecordBasedAuthorize { get; set; }
        public int FieldGroupId { get; set; }

    }
}
