using Xunit;
using task11;

namespace task11tests;

public class UnitTest1
{
    [Fact]
    public void TestCalculatorOperations()
    {
        var calc = CalcBuilder.CreateCalculator();

        Assert.Equal(14, calc.Add(8, 6));
        Assert.Equal(2, calc.Minus(8, 6));
        Assert.Equal(15, calc.Mul(3, 5));
        Assert.Equal(2, calc.Div(4, 2));
    }
}
