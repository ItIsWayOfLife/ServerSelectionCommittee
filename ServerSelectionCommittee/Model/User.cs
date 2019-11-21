namespace ServerSelectionCommittee
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Login { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(50)]
        public string Patronymic { get; set; }

        [StringLength(1)]
        public string AdminRights { get; set; }
    }
}
