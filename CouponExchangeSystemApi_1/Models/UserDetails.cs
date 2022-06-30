using System.ComponentModel.DataAnnotations;

namespace CouponExchangeSystemApi_1.Models
{
    public class UserDetails
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public long? MobileNumber { get; set; }
        public int? CouponUploadCount { get; set; }
        public int? CouponExchangeCount { get; set; }
        public string? ProfilePath { get; set; }
    }
}
