namespace ServerSelectionCommittee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Specialty")]
    [Serializable]
    public partial class Specialty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Specialty()
        {
            TrainingDirection = new HashSet<TrainingDirection>();
        }

        [Key]
        public int IdSpecialty { get; set; }

        public int IdFaculty { get; set; }

        public int IdDepartment { get; set; }

        [Required]
        [StringLength(20)]
        public string CodeSpecialty { get; set; }

        [Required]
        [StringLength(30)]
        public string CodeSpecialization { get; set; }

        [Required]
        [StringLength(100)]
        public string FullNameSpecialty { get; set; }

        [Required]
        [StringLength(30)]
        public string ShortNameSpecialty { get; set; }

        public virtual Department Department { get; set; }

        public virtual Faculty Faculty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainingDirection> TrainingDirection { get; set; }
    }
}
