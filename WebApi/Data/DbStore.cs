public class DbStore : IDbStore
{
    public Dictionary<string, Product> Products()
    {
        // Simulate loading products data from DB
        return new Dictionary<string, Product>
        {
            {"A", new Product { Sku = "A", PriceInCents = 50, SpecialQuantity = 3, SpecialPriceInCents = 130 }},
            {"B", new Product { Sku = "B", PriceInCents = 30, SpecialQuantity = 2, SpecialPriceInCents = 45 }},
            {"C", new Product { Sku = "C", PriceInCents = 20, SpecialQuantity = 0, SpecialPriceInCents = 0 }},
            {"D", new Product { Sku = "D", PriceInCents = 15, SpecialQuantity = 0, SpecialPriceInCents = 0 }},
        };
    }
}