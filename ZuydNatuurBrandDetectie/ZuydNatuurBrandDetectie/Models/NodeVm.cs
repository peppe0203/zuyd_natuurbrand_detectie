using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZuydNatuurBrandDetectie.Models
{
    public class NodeVm
    {
        public nodeTbl node { get; set; }
        public List<metingTbl> metingen { get; set; }
        public List<meldingenTbl> meldingen { get; set; }
    }
}