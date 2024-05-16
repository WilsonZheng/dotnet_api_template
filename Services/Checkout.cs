public class Checkout
{
    private readonly Dictionary<string, Product> _products;
    private readonly Dictionary<string, int> _cart;

    public Checkout(Dictionary<string, Product> products)
    {
        _products = products;
        _cart = new Dictionary<string, int>();
    }

    public void Scan(string sku)
    {
        if (_cart.ContainsKey(sku))
        {
            _cart[sku]++;
        }
        else
        {
            _cart[sku] = 1;
        }
    }

    public decimal GetTotal()
    {
        decimal total = 0m;
        foreach (var item in _cart)
        {
            var product = _products[item.Key];
            if (product.SpecialQuantity > 0)
            {
                int sets = item.Value / product.SpecialQuantity;
                int remainder = item.Value % product.SpecialQuantity;
                total += sets * product.SpecialPrice + remainder * product.PriceInCents;
            }
            else
            {
                total += item.Value * product.PriceInCents;
            }
        }
        return total;
    }
}