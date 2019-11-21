namespace ServerSelectionCommittee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FormStudy")]
    [Serializable]
    public partial class FormStudy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FormStudy()
        {
            TrainingDirection = new HashSet<TrainingDirection>();
        }

        [Key]
        public int IdFormStudy { get; set; }

        [Required]
        [StringLength(50)]
        public string NameFormStudy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainingDirection> TrainingDirection { get; set; }
    }
}
