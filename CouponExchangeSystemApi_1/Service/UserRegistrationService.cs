using CouponExchangeSystemApi_1.Interface;
using CouponExchangeSystemApi_1.ViewModels;
using CouponExchangeSystemApi_1.Data;
using System.Linq;
using CouponExchangeSystemApi_1.Models;
using System.Threading.Tasks;

namespace CouponExchangeSystemApi_1.Service
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private AppDbContext appDbContext;
        public UserRegistrationService(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public UserDetailsData AddUser(UserDetailsData user)
        {
            try
            {
                //Check if EmailId is already present or not
                if (appDbContext.UserDetails.Any(x => x.EmailId.ToLower() == user.EmailId.ToLower()))
                {
                    //return "User already exists";
                    return null;
                }
                else
                {
                    //Add new entry in UserDetails
                    UserDetails ud = new UserDetails();
                    ud.Name = user.Name;
                    ud.EmailId = user.EmailId.ToLower();
                    ud.MobileNumber = user.MobileNumber;
                    ud.CouponUploadCount = 0;
                    ud.CouponExchangeCount = 0;
                    appDbContext.UserDetails.Add(ud);
                    appDbContext.SaveChanges();

                    //Fetch UserId of recently added user
                    user.UserId = appDbContext.UserDetails.Where(x => x.EmailId.ToLower() == user.EmailId.ToLower())
                        .Select(x => x.UserId).FirstOrDefault();

                    //Enter UserLoginDetails of recently added user
                    UserLoginDetails uld = new UserLoginDetails();
                    uld.UserId = user.UserId;
                    uld.Password = user.Password;
                    uld.UserName = user.EmailId.ToLower();
                    uld.UserRole = user.UserRole;
                    appDbContext.UserLoginDetails.Add(uld);
                    appDbContext.SaveChanges();

                    //return "Success";
                    return user;
                }
            }
            catch (System.Exception ex)
            {
                //return "Error";
                return null;
            }
        }

        public UserDetailsData UpdateUser(UserDetailsData user)
        {
            try
            {
                //Fetch record from UserDetails and UserLoginDetails for updating based on UserId
                UserDetails ud = appDbContext.UserDetails.Where(x => x.UserId == user.UserId).FirstOrDefault();
                UserLoginDetails uld = appDbContext.UserLoginDetails.Where(x => x.UserId == user.UserId).FirstOrDefault();

                //Update details only if record is found
                if (ud != null && uld != null)
                {
                    //Update details in UserDetails
                    ud.Name = user.Name;
                    ud.MobileNumber = user.MobileNumber;
                    //ud.ProfilePath = user.ProfilePath;
                    appDbContext.UserDetails.Update(ud);

                    //Update password in UserLoginDetails
                    //uld.Password = user.Password;
                    //appDbContext.UserLoginDetails.Update(uld);
                    appDbContext.SaveChanges();
                    
                    user.EmailId = ud.EmailId;
                    user.CouponUploadCount = ud.CouponUploadCount;
                    user.CouponExchangeCount = ud.CouponExchangeCount;
                    user.ProfilePath = ud.ProfilePath;
                    user.UserRole = uld.UserRole;
                    //return "Success";
                    return user;
                }
                else
                    //return "User details not found";
                    return null;
                
            }
            catch (System.Exception ex)
            {
                //return "Error";
                return null;
            }
        }

        public UserDetailsData GetUser(string username)
        {
            try
            {
                UserDetailsData udd = new UserDetailsData();
                //Fetch details
                UserDetails ud = appDbContext.UserDetails.Where(x => x.EmailId == username).FirstOrDefault();
                UserLoginDetails uld = appDbContext.UserLoginDetails.Where(x => x.UserName == username).FirstOrDefault();

                if (ud != null && uld != null)
                {
                    udd.UserId = ud.UserId;
                    udd.Name = ud.Name;
                    udd.EmailId = ud.EmailId;
                    udd.MobileNumber = ud.MobileNumber;
                    udd.CouponUploadCount = ud.CouponUploadCount;
                    udd.CouponExchangeCount = ud.CouponExchangeCount;
                    udd.ProfilePath = ud.ProfilePath;
                    udd.UserRole = uld.UserRole;
                    return udd;
                }
                else
                    return null;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
    }
}
