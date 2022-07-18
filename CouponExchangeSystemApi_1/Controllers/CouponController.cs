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
    public class CouponController : ControllerBase
    {
        private ICouponService couponService;
        public CouponController(ICouponService _couponService)
        {
            couponService = _couponService;
        }


        [Route("GetAllFilteredCoupons")]
        [HttpPost]
        public List<CouponData> GetAll([FromBody] CouponData coupon)
        {
            return couponService.GetAllFilteredCoupons(coupon);
        }

        [HttpGet("{couponId}")]
        public CouponData Get(int couponId)
        {
            return couponService.GetCouponById(couponId);
        }

        [Route("UploadCoupon")]
        [HttpPost]
        public CouponData Post([FromBody] CouponData coupon)
        {
            //If CouponId is 0 then perform Add
            if (coupon.CouponId == 0)
                return couponService.AddCoupon(coupon);
            else
                return null;
        }
    }
}
