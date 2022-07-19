using CouponExchangeSystemApi_1.ViewModels;
using CouponExchangeSystemApi_1.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CouponExchangeSystemApi_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private IUserRegistrationService userRegistration;
        public UserRegistrationController(IUserRegistrationService _userRegistration)
        {
            userRegistration = _userRegistration;
        }
        [HttpGet("{username}")]
        public UserDetailsData Get(string username)
        {
            return userRegistration.GetUser(username);
        }

        [Route("RegisterUser")]
        [HttpPost]
        public UserDetailsData Post([FromBody] UserDetailsData user)
        {
            //If UserId is 0 then perform Add else Update
            if (user.UserId == 0)
                return userRegistration.AddUser(user);
            else
                return userRegistration.UpdateUser(user);
        }

        [Route("UpdatePassword")]
        [HttpPost]
        public string UpdatePassword(string username, string oldPassword, string newPassword)
        {
            return userRegistration.UpdatePassword(username, oldPassword, newPassword);
        }
    }
}
