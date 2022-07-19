using CouponExchangeSystemApi_1.ViewModels;
using System.Collections.Generic;

namespace CouponExchangeSystemApi_1.Interface
{
    public interface ICouponService
    {
        CouponData AddCoupon(CouponData cd);
        CouponData GetCouponById(int couponId);
        List<CouponData> GetAllFilteredCoupons(CouponData data);
        CouponData ExchangeCoupon(CouponData uploadedCoupon, int selectedCouponId);
    }
}
