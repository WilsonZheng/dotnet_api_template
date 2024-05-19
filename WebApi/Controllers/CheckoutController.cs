using Microsoft.AspNetCore.Mvc;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("v1/checkout")]
    public class CheckoutController : ControllerBase
    {

        [HttpGet]
        public ActionResult<CheckoutApiResponse> Get([FromQuery] string items)
        {
            try
            {
                var result = new CheckoutService(new Cart(), new PricingCalculator(new DbStore().Products())).Checkout(items);
                var response = new CheckoutApiResponse
                {
                    Total = result
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
