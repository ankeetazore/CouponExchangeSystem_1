using CouponExchangeSystemApi_1.Data;
using CouponExchangeSystemApi_1.Interface;
using CouponExchangeSystemApi_1.ViewModels;
using System.Linq;

namespace CouponExchangeSystemApi_1.Service
{
    public class CouponCategoryService : ICouponCategoryService
    {
        private AppDbContext appDbContext;
        public CouponCategoryService(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public CouponCategoryData AddCouponCategory(CouponCategoryData ccd)
        {
            return null;
        }
        public CouponCategoryData UpdateCouponCategory(CouponCategoryData ccd)
        {
            return null;
        }
        public CouponCategoryData GetCouponCategoryById(int couponCategoryId)
        {
            return null;
        }
        public CouponCategoryData GeAllCouponCategory()
        {
            //try
            //{
            //    CouponCategoryData ccd = new CouponCategoryData();
            //    ccd = appDbContext.CouponCategoryDetails.Sele
            //}
            //catch (System.Exception)
            //{

            //    throw;
            //}
            return null;
        }
    }
}
