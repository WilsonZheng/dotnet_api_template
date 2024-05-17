public class PricingCalculator : IPricingCalculator
{
    private readonly Dictionary<string, Product> _products;

    public PricingCalculator(Dictionary<string, Product> products)
    {
        _products = products;
    }

    public int CalculateTotal(ICart cart)
    {
        int total = 0;
        var items = cart.GetItems();
        foreach (var item in items)
        {
            total += CalculateItemTotal(item);
        }
        return total;
    }

    private int CalculateItemTotal(KeyValuePair<string, int> item)
    {
        var product = _products[item.Key];
        if (product.SpecialQuantity > 0)
        {
            int sets = item.Value / product.SpecialQuantity;
            int remainder = item.Value % product.SpecialQuantity;
            return sets * product.SpecialPrice + remainder * product.PriceInCents;
        }
        else
        {
            return item.Value * product.PriceInCents;
        }
    }

    // Helper method to convert cents to dollars
    public decimal ConvertCentsToDollars(int cents)
    {
        return cents / 100m;
    }
}