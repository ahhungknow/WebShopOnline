namespace Data_Access.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        public bool? Status { get; set; }

        public int? Role { get; set; }
    }
}
