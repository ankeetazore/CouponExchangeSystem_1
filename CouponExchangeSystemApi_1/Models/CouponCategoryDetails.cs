using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponExchangeSystemApi_1.Models
{
    public class CouponCategoryDetails
    {
        [Key]
        public int CouponCategoryId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string CategoryImagePath { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime CreateDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserDetails UserDetails { get; set; }
    }
}
