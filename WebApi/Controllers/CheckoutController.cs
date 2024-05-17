using Microsoft.AspNetCore.Mvc;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("v1/checkout")]
    public class CheckoutController : ControllerBase
    {

        [HttpGet]
        public ActionResult<ApiResponse<string>> Get([FromQuery] string items)
        {
            DbStore dbStore = new DbStore();
            Cart cart = new Cart();
            PricingCalculator pricingCalculator = new PricingCalculator(dbStore.Products());
            Checkout checkout = new Checkout(cart, pricingCalculator);
            foreach (var item in items)
            {
                cart.Add(item.ToString());
            }
            var response = new ApiResponse<string>
            {
                Total = pricingCalculator.ConvertCentsToDollars(checkout.GetTotal())
            };
            return Ok(response);
        }
    }
}
