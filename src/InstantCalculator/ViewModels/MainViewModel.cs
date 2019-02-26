using System.Windows.Input;
using Juniansoft.MvvmReady;

namespace InstantCalculator.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        Jint.Engine _js;

        public MainViewModel()
        {
            _js = new Jint.Engine();
        }

        private string _mathExperession;
        public string MathExpression
        {
            get => _mathExperession;
            set => Set(ref _mathExperession, value);
        }

        private string _mathResult;
        public string MathResult
        {
            get => _mathResult;
            set => Set(ref _mathResult, value);
        }

        public double? Calculate(string mathExpression)
        {
            try
            {
                var result = _js.Execute(mathExpression)
                                .GetCompletionValue()
                                .ToString();

                if (double.TryParse(result, out var dec))
                    return dec;
            }
            catch { }
            return null;
        }

        private ICommand _calculateCommand;
        public ICommand CalculateCommand => _calculateCommand ??
            (_calculateCommand = new Command(
            () => 
            {
                var result = Calculate(MathExpression);
                MathResult = result == null ? "N/A" : result.ToString();
            }));
    }
}
