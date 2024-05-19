public class CheckoutService : ICheckoutService
{
    private readonly ICart _cart;
    private readonly IPricingCalculator _pricingCalculator;

    public CheckoutService(ICart cart, IPricingCalculator pricingCalculator)
    {
        _cart = cart ?? throw new ArgumentNullException(nameof(cart));
        _pricingCalculator = pricingCalculator ?? throw new ArgumentNullException(nameof(pricingCalculator));
    }

    public decimal Checkout(string items)
    {
        foreach (var item in items)
        {
            _cart.Add(item.ToString());
        }
        return ConvertCentsToDollars(_pricingCalculator.CalculateTotal(_cart));
    }

    // Helper methods

    private decimal ConvertCentsToDollars(int cents)
    {
        return cents / 100m;
    }
}