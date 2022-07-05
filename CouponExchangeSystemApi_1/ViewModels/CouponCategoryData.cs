using System;

namespace CouponExchangeSystemApi_1.ViewModels
{
    public class CouponCategoryData
    {
        public int CouponCategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryImagePath { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsActive { get; set; }

        public int UserId { get; set; }
    }
}
