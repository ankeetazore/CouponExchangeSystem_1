using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponExchangeSystemApi_1.Models
{
    public class CouponDetails
    {
        [Key]
        public int CouponId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int? MinSpend { get; set; }
        public int? MaxOff { get; set; }
        public string BrandName { get; set; }
        public string CouponCode { get; set; }
        public string? ProductList { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserDetails UserDetails { get; set; }
        public int CouponCategoryId { get; set; }
        [ForeignKey("CouponCategoryId")]
        public CouponCategoryDetails CouponCategoryDetails { get; set; }
        public DateTime UploadDate { get; set; }
        public bool IsActive { get; set; }
    }
}
