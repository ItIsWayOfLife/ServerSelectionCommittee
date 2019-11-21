namespace ServerSelectionCommittee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContractEn")]
    public partial class ContractEn
    {
        [Key]
        public int IdContract { get; set; }

        public int IdEnrolle { get; set; }

        [Required]
        [StringLength(50)]
        public string NumberContract { get; set; }

        public DateTime ImprisonmentDateContract { get; set; }

        public DateTime ValidityContract { get; set; }

        [StringLength(250)]
        public string DescriptionContract { get; set; }

        public virtual Enrollee Enrollee { get; set; }
    }
}
