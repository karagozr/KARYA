using KARYA.MODEL.Entities.Base.Concrete;
using KARYA.MODEL.Enums.Karya;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Entities.Karya
{
    //Id	Name	//Id	FieldGroupId	FieldName	FieldType

    public class FieldGroup : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<Field> Fields { get; set; }
    }
    public class Field : BaseEntity
    {
        public int FieldGroupId { get; set; }
        public string FieldName { get; set; }
        public FieldType FieldType { get; set; }
        public FieldGroup FieldsGroup { get; set; }
    }
}
