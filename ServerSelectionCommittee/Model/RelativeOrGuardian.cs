namespace ServerSelectionCommittee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RelativeOrGuardian")]
    public partial class RelativeOrGuardian
    {
        [Key]
        public int IdRelative { get; set; }

        public int IdEnrollee { get; set; }

        [StringLength(30)]
        public string RelationDegree { get; set; }

        [Required]
        [StringLength(50)]
        public string RelativeFirstname { get; set; }

        [Required]
        [StringLength(50)]
        public string RelativeLastname { get; set; }

        [StringLength(50)]
        public string RelativePatronymic { get; set; }

        [Required]
        [StringLength(10)]
        public string RelativeSex { get; set; }

        public DateTime? RelativeDateOfBirth { get; set; }

        [StringLength(20)]
        public string RelativePassportSeries { get; set; }

        [StringLength(20)]
        public string RelativePassportNumber { get; set; }

        [StringLength(50)]
        public string RelativePassportPersonalNumber { get; set; }

        [StringLength(50)]
        public string RelativePassportIssuedBy { get; set; }

        public DateTime? RelativePassportDateOfIssue { get; set; }

        public DateTime? RelativePassportDateExpiry { get; set; }

        [StringLength(100)]
        public string RelativeAddress { get; set; }

        [StringLength(30)]
        public string RelativePhoneNumber { get; set; }

        [StringLength(50)]
        public string RelativePlaceOfWork { get; set; }

        [StringLength(50)]
        public string RelativePost { get; set; }

        public virtual Enrollee Enrollee { get; set; }
    }
}
