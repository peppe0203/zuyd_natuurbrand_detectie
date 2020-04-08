namespace ZuydNatuurBrandDetectie.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nodeTbl")]
    public partial class nodeTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nodeTbl()
        {
            koppelmeldingTbls = new HashSet<koppelmeldingTbl>();
            metingTbls = new HashSet<metingTbl>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string locatie { get; set; }

        [Required]
        [StringLength(50)]
        public string natuurgebied { get; set; }

        public bool actief { get; set; }

        [Column(TypeName = "date")]
        public DateTime batterijVervangen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<koppelmeldingTbl> koppelmeldingTbls { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<metingTbl> metingTbls { get; set; }
    }
}
