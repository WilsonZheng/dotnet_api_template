using Microsoft.AspNetCore.Mvc;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("v1/checkout")]
    public class CheckoutController : ControllerBase
    {

        [HttpGet]
        public ActionResult<ApiResponse<string>> Get([FromQuery] string cart)
        {
            DbStore dbStore = new DbStore();
            Checkout checkout = new Checkout(dbStore.Products());
            foreach (var item in cart)
            {
                checkout.Scan(item.ToString());
            }
            var response = new ApiResponse<string>
            {
                Total = checkout.GetTotal().ToString()
            };
            return Ok(response);
        }
    }
}
