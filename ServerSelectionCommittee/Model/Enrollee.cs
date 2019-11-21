namespace ServerSelectionCommittee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Enrollee")]
    [Serializable]
    public partial class Enrollee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Enrollee()
        {
            ContractEn = new HashSet<ContractEn>();
            Documents = new HashSet<Documents>();
            History = new HashSet<History>();
            RelativeOrGuardian = new HashSet<RelativeOrGuardian>();
        }

        [Key]
        public int IdEnrollee { get; set; }

        public int IdDirectionTraining { get; set; }

        public int IdLevelEducation { get; set; }

        public int? IdConcession { get; set; }

        [StringLength(100)]
        public string DescriptionConcession { get; set; }

        public DateTime EnrolleeDateOfRegistration { get; set; }

        [Required]
        [StringLength(50)]
        public string EnrolleeFirstname { get; set; }

        [Required]
        [StringLength(50)]
        public string EnrolleeLastname { get; set; }

        [StringLength(50)]
        public string EnrolleePatronymic { get; set; }

        [Required]
        [StringLength(50)]
        public string EnrolleeSex { get; set; }

        public DateTime EnrolleeDateOfBirth { get; set; }

        [Required]
        [StringLength(50)]
        public string EnrolleePassportSeries { get; set; }

        [Required]
        [StringLength(50)]
        public string EnrolleePassportNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string EnrolleePassportPersonalNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string EnrolleePassportIssuedBy { get; set; }

        public DateTime EnrolleeDateOfIssue { get; set; }

        public DateTime EnrolleeDateExpiry { get; set; }

        [Required]
        [StringLength(50)]
        public string EnrolleeAddress { get; set; }

        [StringLength(50)]
        public string EnrolleePostcode { get; set; }

        [StringLength(50)]
        public string EnrolleePhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string EnrolleeEducation { get; set; }

        [Required]
        [StringLength(50)]
        public string EnrolleeLastPlaceOfStudy { get; set; }

        [Required]
        [StringLength(50)]
        public string EnrolleeAddressLastPlaceOfStudy { get; set; }

        public DateTime EnrolleeGraduationDate { get; set; }

        [Required]
        [StringLength(50)]
        public string EnrolleeNumberCertificateOrDiploma { get; set; }

        public double? EnrolleeAverageGradeOfCertificateOrDiploma { get; set; }

        public double? EnrolleeScoreOfTheFirstEntranceTest { get; set; }

        public double? EnrolleeScoreOfTheSecondEntranceTest { get; set; }

        public double? EnrolleeScoreOfTheThirdEntranceTest { get; set; }

        [StringLength(50)]
        public string EnrolleeEmail { get; set; }

        [StringLength(250)]
        public string EnrolleeAdditionalInformation { get; set; }

        public virtual Concession Concession { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractEn> ContractEn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documents> Documents { get; set; }

        public virtual LevelEducation LevelEducation { get; set; }

        public virtual TrainingDirection TrainingDirection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<History> History { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RelativeOrGuardian> RelativeOrGuardian { get; set; }
    }
}
