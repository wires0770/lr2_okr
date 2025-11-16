using Calculator;
using System;
using Xunit;

public class CalculatorEngineTests
{
    [Fact]
    public void InputNumber_ShouldSetDisplay()
    {
        var calc = new CalculatorEngine();

        calc.InputNumber("5");

        Assert.Equal("5", calc.Display);
    }

    [Fact]
    public void Addition_WorksCorrectly()
    {
        var calc = new CalculatorEngine();

        calc.InputNumber("4");
        calc.SetOperation("+");
        calc.InputNumber("6");
        calc.Calculate();

        Assert.Equal("10", calc.Display);
    }

    [Fact]
    public void Subtraction_WorksCorrectly()
    {
        var calc = new CalculatorEngine();

        calc.InputNumber("9");
        calc.SetOperation("-");
        calc.InputNumber("5");
        calc.Calculate();

        Assert.Equal("4", calc.Display);
    }

    [Fact]
    public void Multiplication_WorksCorrectly()
    {
        var calc = new CalculatorEngine();

        calc.InputNumber("3");
        calc.SetOperation("*");
        calc.InputNumber("7");
        calc.Calculate();

        Assert.Equal("21", calc.Display);
    }

    [Fact]
    public void Division_WorksCorrectly()
    {
        var calc = new CalculatorEngine();

        calc.InputNumber("8");
        calc.SetOperation("/");
        calc.InputNumber("2");
        calc.Calculate();

        Assert.Equal("4", calc.Display);
    }

    [Fact]
    public void Division_ByZero_ThrowsException()
    {
        var calc = new CalculatorEngine();

        calc.InputNumber("5");
        calc.SetOperation("/");
        calc.InputNumber("0");

        Assert.Throws<DivideByZeroException>(() => calc.Calculate());
    }
}
