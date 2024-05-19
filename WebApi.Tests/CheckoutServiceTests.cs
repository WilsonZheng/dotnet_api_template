namespace WebApi.Tests;
using Xunit;
using Moq;
using FluentAssertions;

public class CheckoutServiceTests
{
    [Theory]
    [InlineData("", 0, 0)]
    [InlineData("A", 50, 0.5)]
    [InlineData("AB", 80, 0.8)]
    [InlineData("CDBA", 115, 1.15)]
    [InlineData("AA", 100, 1)]
    [InlineData("AAA", 130, 1.3)]
    [InlineData("AAAA", 180, 1.8)]
    [InlineData("AAAAA", 230, 2.3)]
    [InlineData("AAAAAA", 260, 2.6)]
    [InlineData("AAAB", 160, 1.6)]
    [InlineData("AAABB", 175, 1.75)]
    [InlineData("AAABBD", 190, 1.9)]
    [InlineData("DABABA", 190, 1.9)]
    public void Checkout_WithItemsAdded_ReturnsExpectedTotal(string items, int totalInCents, decimal expected)
    {
        // arrange
        var mockDbStore = new Mock<IDbStore>();
        var mockCart = new Mock<ICart>();
        var mockPricingCalculator = new Mock<IPricingCalculator>();

        // set up mocks
        mockDbStore.Setup(m => m.Products()).Returns(new Dictionary<string, Product>
        {
            {"A", new Product { Sku = "A", PriceInCents = 50, SpecialQuantity = 3, SpecialPrice = 130 }},
            {"B", new Product { Sku = "B", PriceInCents = 30, SpecialQuantity = 2, SpecialPrice = 45 }},
            {"C", new Product { Sku = "C", PriceInCents = 20, SpecialQuantity = 0, SpecialPrice = 0 }},
            {"D", new Product { Sku = "D", PriceInCents = 15, SpecialQuantity = 0, SpecialPrice = 0 }},
        });
        mockPricingCalculator.Setup(m => m.CalculateTotal(It.IsAny<ICart>())).Returns(totalInCents);

        var checkoutService = new CheckoutService(mockCart.Object, mockPricingCalculator.Object);

        // act
        decimal result = checkoutService.Checkout(items);

        // assert
        result.Should().Be(expected);
    }
}