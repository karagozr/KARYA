using HANEL.MODEL.Entities.Muhasebe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Muhasebe
{
    public class FaturaUpdateDto
    {
        public Fatura Fatura { get; set; }
        public string[] UpdateColumns { get; set; }
    }
}
