namespace ServerSelectionCommittee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("History")]
    public partial class History
    {
        [Key]
        public int IdHistory { get; set; }

        public int IdEnrollee { get; set; }

        [Required]
        [StringLength(150)]
        public string Operation { get; set; }

        public DateTime CreateAt { get; set; }

        public virtual Enrollee Enrollee { get; set; }
    }
}
