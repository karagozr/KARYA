using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.Entities.Netsis
{
    public class YevmiyeFis
    {
        public int Id { get; set; }
        public string EntegreKey { get; set; }
        public string HesapKodu { get; set; }
        public string HesapAdi { get; set; }
        public string Aciklama { get; set; }
        public double Borc { get; set; }
        public double Alacak { get; set; }
        public string ProjeKodu { get; set; }
        public string ProjeAdi { get; set; }
        public string ReferansKodu { get; set; }
        public string ReferansAdi { get; set; }
        public string Aciklama2 { get; set; }
        public string Aciklama3 { get; set; }

        
    }

    public class YevmiyeFisInfo
    {
        public string FisNo { get; set; }
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
        public int FirmCode { get; set; }
        public string FirmName { get; set; }
        public IEnumerable<YevmiyeFis> YevmiyeFisList { get; set; }
    }
}
