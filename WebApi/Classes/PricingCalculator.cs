public class PricingCalculator : IPricingCalculator
{
    private readonly Dictionary<string, Product> _products;

    public PricingCalculator(Dictionary<string, Product> products)
    {
        _products = products ?? throw new ArgumentNullException(nameof(products));
    }

    public int CalculateTotal(ICart cart)
    {
        int total = 0;
        var items = cart.GetItems();
        foreach (var item in items)
        {
            total += GetItemTypeTotal(item);
        }
        return total;
    }

    private int GetItemTypeTotal(KeyValuePair<string, int> item)
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
}