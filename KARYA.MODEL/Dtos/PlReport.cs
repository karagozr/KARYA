using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Dtos
{
    public class PlReport
    {
        public double Budget { get; set; }
        public double ActualCost { get; set; }
        public double Differance { get; set; }
        public double Rate { get; set; }
        public double LastActualCost { get; set; }
        public double LastDifferance { get; set; }
        public double LastRate { get; set; }
    }
}
