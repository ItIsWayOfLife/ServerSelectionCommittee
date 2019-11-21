namespace ServerSelectionCommittee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BudgetOrCharge")]
    [Serializable]
    public partial class BudgetOrCharge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BudgetOrCharge()
        {
            TrainingDirection = new HashSet<TrainingDirection>();
        }

        [Key]
        public int IdBudgetOrCharge { get; set; }

        [Required]
        [StringLength(50)]
        public string NameBudgetOrCharge { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainingDirection> TrainingDirection { get; set; }
    }
}
