namespace ZuydNatuurBrandDetectie.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("koppelmeldingTbl")]
    public partial class koppelmeldingTbl
    {
        public int id { get; set; }

        public int nodeId { get; set; }

        public int meldingId { get; set; }

        public virtual nodeTbl nodeTbl { get; set; }

        public virtual meldingenTbl meldingenTbl { get; set; }
    }
}
