namespace ServerSelectionCommittee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Concession")]
    public partial class Concession
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Concession()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        [Key]
        public int IdConcession { get; set; }

        [Required]
        [StringLength(100)]
        public string NameConcession { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Enrollee> Enrollee { get; set; }
    }
}
