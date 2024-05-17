public interface ICart
{
    void Add(string sku);
    Dictionary<string, int> GetItems();
}