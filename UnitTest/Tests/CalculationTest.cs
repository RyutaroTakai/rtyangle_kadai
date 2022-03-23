using FluentAssertions;
using Models.Services;
using System;
using UnitTest.Infrastructures;
using Xunit;

namespace UnitTest.Tests
{
    public class CalculationTest
    {
        public CalculationTest()
        { }

        [Theory]
        [CSV(@"..\..\..\TestFiles\計算結果一致.csv")]
        public void SumTest(uint value1, uint value2, uint sum)
        {
            var cal = new Calculation();

            cal.Sum(value1, value2).Should().Be(sum, "値が一致");
        }


        [Fact]
        public void SumTest_Overflow()
        {
            var cal = new Calculation();

            var action = () => cal.Sum(uint.MaxValue, 1);
            action.Should().Throw<OverflowException>();
        }
    }
}