using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CouponExchangeSystemApi_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponCategoryController : ControllerBase
    {
        // GET api/<CouponCategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CouponCategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // DELETE api/<CouponCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
