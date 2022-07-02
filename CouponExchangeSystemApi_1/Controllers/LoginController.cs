using CouponExchangeSystemApi_1.Interface;
using CouponExchangeSystemApi_1.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CouponExchangeSystemApi_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService loginService;
        public LoginController(ILoginService _loginService)
        {
            loginService = _loginService;
        }

        [HttpPost]
        public string Post(string username, string password)
        {
            return loginService.Login(username, password);
        }

    }
}
