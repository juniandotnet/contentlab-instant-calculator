using System;
using System.Collections.Generic;
using System.Text;
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

        [Fact]
        public void CalculateCommandTest()
        {
            var logs = new StringBuilder();
            _vm.AppendLogAction = (log) => logs.Append(log);

            var inputSample = new Dictionary<string, string>
            {
                { "1+1", "2" },
                { "100+10", "110" },
                { "100 + a", "N/A" },
            };

            var expectedLogs = new StringBuilder();
            foreach (var s in inputSample)
            {
                expectedLogs.AppendLine($">>> {s.Key}");
                expectedLogs.AppendLine(s.Value);
                expectedLogs.AppendLine();

                _vm.MathExpression = s.Key;
                _vm.CalculateCommand.Execute(null);
                Assert.Equal(s.Value, _vm.MathResult);
            }

            Assert.Equal(expectedLogs.ToString(), logs.ToString());
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
