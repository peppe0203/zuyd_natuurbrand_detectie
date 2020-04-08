namespace ZuydNatuurBrandDetectie.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("meldingenTbl")]
    public partial class meldingenTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public meldingenTbl()
        {
            koppelmeldingTbls = new HashSet<koppelmeldingTbl>();
        }

        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime datum { get; set; }

        public TimeSpan tijd { get; set; }

        [Required]
        [StringLength(50)]
        public string type { get; set; }

        [Required]
        [StringLength(255)]
        public string beschrijving { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<koppelmeldingTbl> koppelmeldingTbls { get; set; }
    }
}
