using System;

namespace CouponExchangeSystemApi_1.ViewModels
{
    public class CouponData
    {
        public int CouponId { get; set; }
        public string ExpiryDate { get; set; }
        public int? MinSpend { get; set; }
        public int? MaxOff { get; set; }
        public string BrandName { get; set; }
        public string CouponCode { get; set; }
        public string? ProductList { get; set; }
        public int UserId { get; set; }
        public int CouponCategoryId { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
