using CouponExchangeSystemApi_1.Data;
using CouponExchangeSystemApi_1.Interface;
using CouponExchangeSystemApi_1.Models;
using CouponExchangeSystemApi_1.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;

namespace CouponExchangeSystemApi_1.Service
{
    public class CouponService : ICouponService
    {
        private AppDbContext appDbContext;
        public CouponService(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public CouponData AddCoupon(CouponData data)
        {
            try
            {
                DateTime ExpiryDate = DateTime.Parse(data.ExpiryDate);
                //Check if Coupon is already present or not
                if (appDbContext.CouponDetails.Any(x => x.CouponCode == data.CouponCode && x.ExpiryDate == ExpiryDate))
                {
                    //return null if "Coupon already exists"
                    return null;
                }
                else
                {
                    //Add new entry in CouponDetails
                    CouponDetails cd = new CouponDetails();
                    cd.ExpiryDate = ExpiryDate;
                    cd.MinSpend = data.MinSpend;
                    cd.MaxOff = data.MaxOff;
                    cd.BrandName = data.BrandName;
                    cd.CouponCode = data.CouponCode;
                    cd.ProductList = data.ProductList;
                    cd.UploadDate = System.DateTime.Now;
                    cd.UserId = data.UserId;
                    cd.CouponCategoryId = data.CouponCategoryId;
                    cd.IsActive = true;
                    appDbContext.CouponDetails.Add(cd);
                    appDbContext.SaveChanges();

                    //Fetch CouponId of recently added CouponDetails
                    data.CouponId = appDbContext.CouponDetails.Where(x => x.CouponCode == data.CouponCode && x.ExpiryDate == ExpiryDate)
                            .Select(x => x.CouponId).FirstOrDefault();

                    //Fetch record from UserDetails and update CouponUploadCount
                    UserDetails ud = appDbContext.UserDetails.Where(x => x.UserId == data.UserId).FirstOrDefault();
                    if (ud != null)
                    {
                        ud.CouponUploadCount = ud.CouponUploadCount + 1;
                        appDbContext.UserDetails.Update(ud);
                        appDbContext.SaveChanges();
                    }
                    return data;
                }
            }
            catch (System.Exception ex)
            {
                //return ex.Message;
                return null;
            }
        }
        public CouponData GetCouponById(int couponId)
        {
            try
            {
                CouponData cd = new CouponData();
                var data = appDbContext.CouponDetails
                    .Where(x => x.CouponId == couponId).FirstOrDefault();
                cd.ExpiryDate = data.ExpiryDate.ToString("dd-MM-yyyy");
                cd.MinSpend = data.MinSpend;
                cd.MaxOff = data.MaxOff;
                cd.BrandName = data.BrandName;
                cd.CouponCode = data.CouponCode;
                cd.ProductList = data.ProductList;
                cd.UploadDate = data.UploadDate;
                cd.UserId = data.UserId;
                cd.CouponCategoryId = data.CouponCategoryId;
                return cd;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public List<CouponData> GetAllFilteredCoupons(CouponData cd)
        {
            try
            {
                List<CouponData> cd_list = new List<CouponData>();
                int AdminUserId = 0;
                try
                {
                    DeleteExpiredCoupons();
                    AdminUserId = appDbContext.UserLoginDetails.Where(x => x.UserRole == "Admin").Select(x => x.UserId).FirstOrDefault();
                }
                catch (System.Exception)
                {
                    throw;
                }
                dynamic filtered_list = null;
                //List of Coupons Uploaded by other Users
                var data_list_by_user = appDbContext.CouponDetails.Where(x => x.IsActive == true && x.ExpiryDate >= System.DateTime.Now
                                                                    && x.CouponId != cd.CouponId && x.UserId != cd.UserId 
                                                                    && x.UserId != AdminUserId).ToList();

                //List of Coupons Uploaded by Admin
                var data_list_by_admin = appDbContext.CouponDetails.Where(x => x.IsActive == true && x.ExpiryDate >= System.DateTime.Now
                                                                    && x.UserId == AdminUserId).ToList();

                //First Filter [MinSpend]
                if (cd.MinSpend != null && cd.MinSpend != 0)
                {
                    data_list_by_user = data_list_by_user.Where(x => x.MinSpend != null && x.MinSpend != 0
                                                    && (x.MinSpend == cd.MinSpend || x.MinSpend > cd.MinSpend)).ToList();
                    filtered_list = data_list_by_user;
                }

                //Second Filter [MaxOff]
                else if (cd.MaxOff != null && cd.MaxOff != 0)
                {
                    data_list_by_user = data_list_by_user.Where(x => x.MaxOff != null && x.MaxOff != 0
                                                    && (x.MaxOff == cd.MaxOff || x.MaxOff < cd.MaxOff)).ToList();
                    filtered_list = data_list_by_user;
                }

                //Add data_list_by_admin in filtered_list
                filtered_list.AddRange(data_list_by_admin);
                foreach (var item in filtered_list)
                {
                    CouponData data = new CouponData();
                    data.CouponId = item.CouponId;
                    data.ExpiryDate = item.ExpiryDate.ToString("dd-MM-yyyy");
                    data.MinSpend = item.MinSpend;
                    data.MaxOff = item.MaxOff;
                    data.BrandName = item.BrandName;
                    //data.CouponCode = item.CouponCode;
                    data.ProductList = item.ProductList;
                    data.UploadDate = item.UploadDate;
                    data.UserId = item.UserId;
                    data.CouponCategoryId = item.CouponCategoryId;
                    cd_list.Add(data);
                }
                return cd_list;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public CouponData ExchangeCoupon(CouponData uploadedCoupon, int selectedCouponId)
        {
            try
            {
                var result = AddCoupon(uploadedCoupon);
                if(result != null)
                {
                    CouponDetails cd = appDbContext.CouponDetails.Where(x => x.CouponId == selectedCouponId && x.IsActive == true).FirstOrDefault();
                    CouponData data = new CouponData();
                    data.CouponId = cd.CouponId;
                    data.ExpiryDate = cd.ExpiryDate.ToString("dd-MM-yyyy");
                    data.MinSpend = cd.MinSpend;
                    data.MaxOff = cd.MaxOff;
                    data.BrandName = cd.BrandName;
                    data.CouponCode = cd.CouponCode;
                    data.ProductList = cd.ProductList;
                    data.UploadDate = cd.UploadDate;
                    data.UserId = cd.UserId;
                    data.CouponCategoryId = cd.CouponCategoryId;

                    //Fetch record from UserDetails and update CouponExchangeCount
                    UserDetails ud = appDbContext.UserDetails.Where(x => x.UserId == uploadedCoupon.UserId).FirstOrDefault();
                    if (ud != null)
                    {
                        ud.CouponExchangeCount = ud.CouponExchangeCount + 1;
                        appDbContext.UserDetails.Update(ud);
                        appDbContext.SaveChanges();
                    }

                    //Delete coupon which is seleted for exchange
                    appDbContext.CouponDetails.Remove(cd);
                    appDbContext.SaveChanges();
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        private void DeleteExpiredCoupons()
        {
            var data_list = appDbContext.CouponDetails.Where(x => x.IsActive == true && x.ExpiryDate < System.DateTime.Now).ToList();
            data_list.ForEach(x => x.IsActive = false);
            appDbContext.UpdateRange(data_list);
            appDbContext.SaveChanges();
        }
    }
}
