using CouponExchangeSystemApi_1.Interface;
using CouponExchangeSystemApi_1.Models;
using CouponExchangeSystemApi_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CouponExchangeSystemApi_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponCategoryController : ControllerBase
    {
        private ICouponCategoryService couponCategoryService;
        public CouponCategoryController(ICouponCategoryService _couponCategoryService)
        {
            couponCategoryService = _couponCategoryService;
        }

        [HttpGet()]
        public List<CouponCategoryData> GetAll()
        {
            return couponCategoryService.GeAllCouponCategory();
        }

        [HttpGet("{couponCategoryId}")]
        public CouponCategoryData Get(int couponCategoryId)
        {
            return couponCategoryService.GetCouponCategoryById(couponCategoryId);
        }

        [HttpPost]
        public CouponCategoryData Post([FromBody] CouponCategoryData couponCategory)
        {
            //If CouponCategoryId is 0 then perform Add else Update
            if (couponCategory.CouponCategoryId == 0)
                return couponCategoryService.AddCouponCategory(couponCategory);
            else
                return couponCategoryService.UpdateCouponCategory(couponCategory);
        }

        [HttpDelete("{couponCategoryId}")]
        public string Delete(int couponCategoryId)
        {
            return couponCategoryService.DeleteCouponCategoryById(couponCategoryId);
        }
    }
}