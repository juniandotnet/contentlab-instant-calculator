using System;
using InstantCalculator.ViewModels;
using Xunit;

namespace InstantCalculator.Tests.ViewModels
{
    public class MainViewModelExperiment
    {
        MainViewModel _vm;

        public MainViewModelExperiment()
        {
            _vm = new MainViewModel();
        }

        [Theory]
        [InlineData("1+1", 2)]
        [InlineData("1.5+1", 2.5)]
        [InlineData("2+2", 4)]
        [InlineData("4-1", 3)]
        [InlineData("9*8*7", 504)]
        [InlineData("woah", null)]
        [InlineData("1+2-", null)]
        [InlineData("1+2+'a'", null)]
        public void StringCalculationTest(string mathExpression, double? expected)
        {
            var actual = _vm.Calculate(mathExpression);
            Assert.Equal(expected, actual);
        }
    }
}
