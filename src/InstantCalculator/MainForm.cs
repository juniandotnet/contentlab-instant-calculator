using System;
using Eto.Forms;
using Eto.Drawing;
using InstantCalculator.ViewModels;

namespace InstantCalculator
{
    public partial class MainForm : Form
    {
        private TextArea _textInput;
        private TextBox _textOutput;
        private TextArea _textLog;
        private Button _buttonCalculate;

        public MainForm()
        {
            Title = "Instant Calculator";
            ClientSize = new Size(400, 350);

            // Main content.
            // 1. Input text area
            // 2. Button to calculate
            // 3. Output text area (read only)
            Content = new StackLayout
            {
                Padding = 10,
                Spacing = 10,
                Orientation = Orientation.Vertical,
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                VerticalContentAlignment = VerticalAlignment.Stretch,
                Items =
                {
                    new StackLayoutItem
                    {
                        Control = _textInput = new TextArea
                        {
                            SpellCheck =false,
                            Wrap = true,
                            ReadOnly = false
                        },
                        Expand = false,
                    },
                    new StackLayout
                    {
                        Padding = 0,
                        Spacing = 5,
                        Orientation = Orientation.Horizontal,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Stretch,
                        Items =
                        {
                            (_buttonCalculate = new Button{Text = "Calculate"}),
                            new StackLayoutItem
                            {
                                Control = _textOutput = new TextBox
                                {
                                    ReadOnly = true
                                },
                                Expand = true,
                            },
                        },
                    },
                    new StackLayoutItem
                    {
                        Control = _textLog = new TextArea
                        {
                            SpellCheck =false,
                            Wrap = true,
                            ReadOnly = true
                        },
                        Expand = true,
                    },
                }
            };

            // Quit application
            var quitCommand = new Command 
            { 
                MenuText = "Quit",
                Shortcut = Application.Instance.CommonModifier | Keys.Q 
            };
            quitCommand.Executed += (_, e) => Application.Instance.Quit();

            // Show about dialog
            var aboutCommand = new Command 
            { 
                MenuText = "About..."
            };
            aboutCommand.Executed += 
                (_, e) => new AboutDialog().ShowDialog(this);

            // Create menu
            Menu = new MenuBar
            {
                Items = { },
                ApplicationItems = { },
                QuitItem = quitCommand,
                AboutItem = aboutCommand
            };

            // Create toolbar, empty for now			
            ToolBar = new ToolBar { Items = { } };

            DataContextChanged += (_, e) =>
            {
                if (!(this.DataContext is MainViewModel vm))
                    return;

                vm.AppendLogAction = (log) => _textLog.Append(log, true);
                ConfigureDataBinding();
            };

            DataContext = new MainViewModel();
        }

        private void ConfigureDataBinding()
        {
            _buttonCalculate.BindDataContext(
                x => x.Command,
                (MainViewModel vm) => vm.CalculateCommand);

            _textInput.BindDataContext(
                x => x.Text, 
                (MainViewModel vm) => vm.MathExpression);

            _textOutput.BindDataContext(
                x => x.Text,
                (MainViewModel vm) => vm.MathResult);
        }
    }
}
