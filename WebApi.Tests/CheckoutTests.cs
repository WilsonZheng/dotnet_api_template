namespace WebApi.Tests;
using Xunit;

public class CheckoutTests
{
    private readonly DbStore _dbStore;
    private readonly Cart _cart;
    private readonly PricingCalculator _pricingCalculator;
    private readonly Checkout _checkout;

    public CheckoutTests()
    {
        _dbStore = new DbStore();
        _cart = new Cart();
        _pricingCalculator = new PricingCalculator(_dbStore.Products());
        _checkout = new Checkout(_cart, _pricingCalculator);
    }
    [Theory]
    [InlineData("", 0)]
    [InlineData("A", 0.5)]
    [InlineData("AB", 0.8)]
    [InlineData("CDBA", 1.15)]
    [InlineData("AA", 1)]
    [InlineData("AAA", 1.3)]
    [InlineData("AAAA", 1.8)]
    [InlineData("AAAAA", 2.3)]
    [InlineData("AAAAAA", 2.6)]
    [InlineData("AAAB", 1.6)]
    [InlineData("AAABB", 1.75)]
    [InlineData("AAABBD", 1.9)]
    [InlineData("DABABA", 1.9)]
    public void GetTotalTheory(string items, decimal expected)
    {
        foreach (var item in items)
        {
            _cart.Add(item.ToString());
        }
        decimal result = _pricingCalculator.ConvertCentsToDollars(_checkout.GetTotal());
        Assert.Equal(expected, result);
    }
    [Fact]
    public void TestIncrementalFact()
    {
        _cart.Add("A");
        Assert.Equal(0.5m, _pricingCalculator.ConvertCentsToDollars(_checkout.GetTotal()));
        _cart.Add("B");
        Assert.Equal(0.8m, _pricingCalculator.ConvertCentsToDollars(_checkout.GetTotal()));
        _cart.Add("A");
        Assert.Equal(1.3m, _pricingCalculator.ConvertCentsToDollars(_checkout.GetTotal()));
        _cart.Add("A");
        Assert.Equal(1.6m, _pricingCalculator.ConvertCentsToDollars(_checkout.GetTotal()));
        _cart.Add("B");
        Assert.Equal(1.75m, _pricingCalculator.ConvertCentsToDollars(_checkout.GetTotal()));
    }
}