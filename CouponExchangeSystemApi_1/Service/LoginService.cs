using CouponExchangeSystemApi_1.Data;
using CouponExchangeSystemApi_1.Interface;
using CouponExchangeSystemApi_1.Models;
using System.Linq;

namespace CouponExchangeSystemApi_1.Service
{
    public class LoginService : ILoginService
    {
        private AppDbContext appDbContext;
        public LoginService(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public string Login(string username, string password)
        {
            try
            {
                UserLoginDetails uld = appDbContext.UserLoginDetails
                    .Where(x => x.UserName == username && x.Password == password).FirstOrDefault();

                if (uld != null)
                    return "Success";
                else
                    return "Wrong username or password";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
                throw;
            }
        }
    }
}
