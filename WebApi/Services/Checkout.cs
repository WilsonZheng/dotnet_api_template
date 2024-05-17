public class Checkout
{
    private readonly ICart _cart;
    private readonly IPricingCalculator _pricingCalculator;

    public Checkout(ICart cart, IPricingCalculator pricingCalculator)
    {
        _cart = cart;
        _pricingCalculator = pricingCalculator;
    }

    public void Scan(string sku)
    {
        _cart.Add(sku);
    }

    public int GetTotal()
    {
        return _pricingCalculator.CalculateTotal(_cart);
    }
}