namespace ServerSelectionCommittee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Documents
    {
        [Key]
        public int IdDocument { get; set; }

        public int IdEnrollee { get; set; }

        [StringLength(50)]
        public string NameDocument { get; set; }

        [StringLength(50)]
        public string NumberDocument { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public virtual Enrollee Enrollee { get; set; }
    }
}
