using CouponExchangeSystemApi_1.Data;
using CouponExchangeSystemApi_1.Interface;
using CouponExchangeSystemApi_1.Models;
using CouponExchangeSystemApi_1.ViewModels;
using System.Collections.Generic;
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
        public CouponCategoryData AddCouponCategory(CouponCategoryData data)
        {
            try
            {
                //Check if CouponCategory is already present or not
                if (appDbContext.CouponCategoryDetails.Any(x => x.CategoryName == data.CategoryName.ToUpper() && x.IsActive == true))
                {
                    //return null if "CouponCategory already exists"
                    return null;
                }
                else
                {
                    //Add new entry in CouponCategoryDetails
                    CouponCategoryDetails ccd = new CouponCategoryDetails();
                    ccd.CategoryName = data.CategoryName.ToUpper();
                    ccd.CategoryImagePath = data.CategoryImagePath;
                    ccd.CreateDate = System.DateTime.Now;
                    ccd.UserId = data.UserId;
                    ccd.IsActive = true;
                    appDbContext.CouponCategoryDetails.Add(ccd);
                    appDbContext.SaveChanges();

                    //Fetch CouponCategoryId of recently added CouponCategory
                    data.CouponCategoryId = appDbContext.CouponCategoryDetails.Where(x => x.CategoryName.ToLower() == data.CategoryName.ToLower())
                        .Select(x => x.CouponCategoryId).FirstOrDefault();
                    
                    return data;
                }
            }
            catch (System.Exception ex)
            {
                //return ex.Message;
                return null;
            }
        }
        public CouponCategoryData UpdateCouponCategory(CouponCategoryData data)
        {
            try
            {
                //Fetch record from CouponCategoryDetails for updating based on CouponCategoryId
                CouponCategoryDetails ccd = appDbContext.CouponCategoryDetails.Where(x => x.CouponCategoryId == data.CouponCategoryId).FirstOrDefault();

                //Update details only if record is found
                if (ccd != null)
                {
                    //Check whether same CategoryName is already present in CouponCategoryDetails
                    if (!appDbContext.CouponCategoryDetails.Where(x => x.CategoryName == data.CategoryName.ToUpper() && x.CouponCategoryId != data.CouponCategoryId).Any())
                    {
                        //Update is same name is not present
                        ccd.CategoryName = data.CategoryName.ToUpper();
                        ccd.CategoryImagePath = data.CategoryImagePath;
                        appDbContext.CouponCategoryDetails.Update(ccd);
                        appDbContext.SaveChanges();

                        return data;
                    }
                    else
                        return null;
                }
                else
                    return null;

            }
            catch (System.Exception ex)
            {
                //return ex.Message;
                return null;
            }
        }
        public CouponCategoryData GetCouponCategoryById(int couponCategoryId)
        {
            try
            {
                CouponCategoryData ccd = new CouponCategoryData();
                var data = appDbContext.CouponCategoryDetails
                    .Where(x => x.CouponCategoryId == couponCategoryId && x.IsActive == true).FirstOrDefault();
                ccd.CouponCategoryId = data.CouponCategoryId;
                ccd.CategoryName = data.CategoryName;
                ccd.CategoryImagePath = data.CategoryImagePath;
                ccd.CreateDate = data.CreateDate;
                ccd.UserId = data.UserId;
                return ccd;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public List<CouponCategoryData> GeAllCouponCategory()
        {
            try
            {
                List<CouponCategoryData> ccd_list = new List<CouponCategoryData>();
                var data_list = appDbContext.CouponCategoryDetails.Where(x => x.IsActive == true).ToList();
                foreach (var item in data_list)
                {
                    CouponCategoryData data = new CouponCategoryData();
                    data.CouponCategoryId = item.CouponCategoryId;
                    data.CategoryName = item.CategoryName;
                    data.CategoryImagePath = item.CategoryImagePath;
                    data.CreateDate = item.CreateDate;
                    data.UserId = item.UserId;
                    ccd_list.Add(data);
                }
                return ccd_list;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public string DeleteCouponCategoryById(int couponCategoryId)
        {
            try
            {
                CouponCategoryDetails ccd = appDbContext.CouponCategoryDetails.Where(x => x.CouponCategoryId == couponCategoryId).FirstOrDefault();
                if (ccd != null)
                {
                    ccd.IsActive = false;
                    appDbContext.CouponCategoryDetails.Update(ccd);
                    appDbContext.SaveChanges();
                    return "Success";
                }
                else
                    return "Data not found";
                
            }
            catch (System.Exception ex)
            {
                return "Error occured";
            }
        }
    }
}
