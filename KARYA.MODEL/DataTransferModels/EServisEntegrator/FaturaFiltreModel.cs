using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.DataTransferModels.EServisEntegrator
{
    public class FaturaFiltreModel
    {
        public string Guid { get; set; }
        public string VergiNo { get; set; }
        public int SonBelgeSiraNo { get; set; }
        public string BelgeTipi { get; set; }
    }
}
