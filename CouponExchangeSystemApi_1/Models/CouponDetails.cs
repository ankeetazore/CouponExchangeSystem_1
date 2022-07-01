using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponExchangeSystemApi_1.Models
{
    public class CouponDetails
    {
        [Key]
        public int CouponId { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime ExpiryDate { get; set; }

        public int? MinSpend { get; set; }
        public int? MaxOff { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string BrandName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string CouponCode { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string? ProductList { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserDetails UserDetails { get; set; }

        public int CouponCategoryId { get; set; }
        [ForeignKey("CouponCategoryId")]
        public CouponCategoryDetails CouponCategoryDetails { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime UploadDate { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
