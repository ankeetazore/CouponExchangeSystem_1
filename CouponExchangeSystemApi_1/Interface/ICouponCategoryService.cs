using CouponExchangeSystemApi_1.ViewModels;

namespace CouponExchangeSystemApi_1.Interface
{
    public interface ICouponCategoryService
    {
        CouponCategoryData AddCouponCategory(CouponCategoryData ccd);
        CouponCategoryData UpdateCouponCategory(CouponCategoryData ccd);
        CouponCategoryData GetCouponCategoryById(int couponCategoryId);
        CouponCategoryData GeAllCouponCategory();
    }
}
