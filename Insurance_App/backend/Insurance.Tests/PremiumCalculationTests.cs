using Xunit;
using FluentAssertions;


public class PremiumCalculationTests
{
    [Fact]
    public void CalculatePremium_Example()
    {
        // arrange
        var age = 35m;
        var factor = 1.5m;
        var cover = 500000m;

        // act
        var premium = (cover * factor * age) / 1000m * 12m;

        // assert
        premium.Should().Be(315000m);
    }
}