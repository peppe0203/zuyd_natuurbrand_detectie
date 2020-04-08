namespace ZuydNatuurBrandDetectie.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("metingTbl")]
    public partial class metingTbl
    {
        public int id { get; set; }

        public int nodeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime datum { get; set; }

        public TimeSpan tijd { get; set; }

        public int luchtVochtigheidSensor { get; set; }

        public int grondSensor { get; set; }

        public int diepGrondSensor { get; set; }

        public int temperatuurSensor { get; set; }

        public virtual nodeTbl nodeTbl { get; set; }
    }
}
