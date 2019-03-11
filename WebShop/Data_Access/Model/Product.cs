namespace Data_Access.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }
        [DisplayName("Tiêu Đề Meta")]
        [StringLength(250)]
        [Required(ErrorMessage ="Không được bỏ trống trường này!!")]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Không được bỏ trống trường này!!")]
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "Không được bỏ trống trường này!!")]
        [DisplayName("Mô tả sản phẩm")]
        public string Description { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Không được bỏ trống trường này!!")]
        [DisplayName("Ảnh")]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        [DisplayName("Thêm nhiều ảnh")]
        public string MoreImage { get; set; }
        [DisplayName("Giá")]
        public decimal? Price { get; set; }
        [DisplayName("Số lượng còn")]
        public int? Quantity { get; set; }
        [DisplayName("Loại sản phẩm")]
        public long? CategoryId { get; set; }
        [DisplayName("Thời gian bảo hành")]
        public int? Waranty { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Không được bỏ trống trường này!!")]
        [DisplayName("Mã")]
        public string Code { get; set; }
        [DisplayName("Trạng thái")]
        public int? Status { get; set; }
        [DisplayName("Giảm giá (%)")]
        public int? Sale { get; set; }
    }
}
