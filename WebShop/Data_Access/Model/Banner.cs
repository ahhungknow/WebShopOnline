namespace Data_Access.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [StringLength(250)]
        public string Link { get; set; }
    }
}
