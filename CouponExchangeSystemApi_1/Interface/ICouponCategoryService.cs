using CouponExchangeSystemApi_1.ViewModels;
using System.Collections.Generic;

namespace CouponExchangeSystemApi_1.Interface
{
    public interface ICouponCategoryService
    {
        CouponCategoryData AddCouponCategory(CouponCategoryData ccd);
        CouponCategoryData UpdateCouponCategory(CouponCategoryData ccd);
        CouponCategoryData GetCouponCategoryById(int couponCategoryId);
        List<CouponCategoryData> GeAllCouponCategory();
        string DeleteCouponCategoryById(int couponCategoryId);
    }
}
