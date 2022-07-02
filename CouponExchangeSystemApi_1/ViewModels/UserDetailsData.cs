namespace CouponExchangeSystemApi_1.ViewModels
{
    public class UserDetailsData
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public long? MobileNumber { get; set; }
        public int? CouponUploadCount { get; set; }
        public int? CouponExchangeCount { get; set; }
        public string? ProfilePath { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
    }
}
