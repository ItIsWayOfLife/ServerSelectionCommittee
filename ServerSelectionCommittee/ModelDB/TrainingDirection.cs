namespace ServerSelectionCommittee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainingDirection")]
    [Serializable]
    public partial class TrainingDirection
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrainingDirection()
        {
            Enrollee = new HashSet<Enrollee>();
        }

        [Key]
        public int IdDirectionTraining { get; set; }

        public int IdSpecialty { get; set; }

        public int IdFormStudy { get; set; }

        public int IdTrainingPeriod { get; set; }

        public int IdBudgetOrCharge { get; set; }

        public string FirstIdEntranceTests { get; set; }

        public string SecondEntranceTests { get; set; }

        public string ThirdEntranceTests { get; set; }

        public int AdmissionPlan { get; set; }

        public virtual BudgetOrCharge BudgetOrCharge { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Enrollee> Enrollee { get; set; }

        public virtual FormStudy FormStudy { get; set; }

        public virtual Specialty Specialty { get; set; }

        public virtual TrainingPeriod TrainingPeriod { get; set; }
    }
}
