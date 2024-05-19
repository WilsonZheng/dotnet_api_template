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
                var checkout = new Checkout(
                    new Cart(),
                    new PricingCalculator(
                        new DbStore().Products()
                    )
                );
                var response = new CheckoutApiResponse
                {
                    Total = checkout.GetTotal(items)
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
