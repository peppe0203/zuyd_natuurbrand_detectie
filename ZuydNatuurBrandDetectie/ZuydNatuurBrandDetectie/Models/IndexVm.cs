using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZuydNatuurBrandDetectie.Models
{
    public class IndexVm
    {
        public List<nodeTbl> nodes { get; set; }
        public List<metingTbl> metingen { get; set; }
        public List <meldingenTbl> meldingen { get; set; }
    }
}