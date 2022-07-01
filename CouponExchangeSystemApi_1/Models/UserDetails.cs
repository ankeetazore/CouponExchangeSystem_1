using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponExchangeSystemApi_1.Models
{
    public class UserDetails
    {
        [Key]
        public int UserId { get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string EmailId { get; set; }

        [Column(TypeName = "BIGINT")]
        public long? MobileNumber { get; set; }
        public int? CouponUploadCount { get; set; }
        public int? CouponExchangeCount { get; set; }
        
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string? ProfilePath { get; set; }
    }
}
