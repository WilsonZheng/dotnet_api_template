public class Cart : ICart
{
    private readonly Dictionary<string, int> _items = new Dictionary<string, int>();

    public void Add(string sku)
    {
        if (_items.ContainsKey(sku))
        {
            _items[sku]++;
        }
        else
        {
            _items[sku] = 1;
        }
    }

    public Dictionary<string, int> GetItems()
    {
        return _items;
    }
}
