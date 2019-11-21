namespace ServerSelectionCommittee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainingPeriod")]
    public partial class TrainingPeriod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrainingPeriod()
        {
            TrainingDirection = new HashSet<TrainingDirection>();
        }

        [Key]
        public int IdTrainingPeriod { get; set; }

        [Required]
        [StringLength(50)]
        public string NameTrainingPeriod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainingDirection> TrainingDirection { get; set; }
    }
}
