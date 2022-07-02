using CouponExchangeSystemApi_1.ViewModels;
using System.Threading.Tasks;

namespace CouponExchangeSystemApi_1.Interface
{
    public interface IUserRegistrationService
    {
        UserDetailsData AddUser(UserDetailsData user);
        UserDetailsData UpdateUser(UserDetailsData user);
        UserDetailsData GetUser(string username);
    }
}
