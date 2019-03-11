namespace Data_Access.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        [DisplayName("Mã loại")]
        public long Id { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống trường này")]
        [DisplayName("Tên loại")]
        [StringLength(250)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống trường này")]
        [DisplayName("Meta Title")]
        [StringLength(250)]
        public string MetaTitle { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống trường này")]
        [DisplayName("Vị trí hiển thị")]
        public int? DisplayOrder { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống trường này")]
        [DisplayName("Tiêu đề SEO")]
        [StringLength(250)]
        public string SeoTitle { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống trường này")]
        [DisplayName("Thuộc loại")]
        public int? ParentId { get; set; }
    }
}
