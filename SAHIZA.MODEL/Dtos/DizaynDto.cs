using SAHIZA.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHIZA.MODEL.Dtos
{
    public class DizaynDto:Dizayn
    {
        public string DetayListJson { get; set; } 
    }
}
