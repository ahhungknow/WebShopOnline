namespace Data_Access.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        [StringLength(250)]
        [Required]
        public string MetaTitle { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(500)]
        [AllowHtml]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public long? CategoryId { get; set; }

        public int? Waranty { get; set; }

        [StringLength(10)]
        [Required]
        public string Code { get; set; }

        public int? Status { get; set; }

        public int? Sale { get; set; }
    }
}
