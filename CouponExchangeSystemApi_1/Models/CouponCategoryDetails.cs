using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponExchangeSystemApi_1.Models
{
    public class CouponCategoryDetails
    {
        [Key]
        public int CouponCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImagePath { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserDetails UserDetails { get; set; }
    }
}
