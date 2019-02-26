using System;
using Eto.Forms;
using Eto.Drawing;

namespace InstantCalculator
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			Title = "Instant Calculator";
			ClientSize = new Size(400, 350);

			Content = new StackLayout
			{
				Padding = 10,
				Items =
				{
					"Hello World!",
					// add more controls here
				}
			};

			var quitCommand = new Command { MenuText = "Quit", Shortcut = Application.Instance.CommonModifier | Keys.Q };
			quitCommand.Executed += (sender, e) => Application.Instance.Quit();

			var aboutCommand = new Command { MenuText = "About..." };
			aboutCommand.Executed += (sender, e) => new AboutDialog().ShowDialog(this);

			// create menu
			Menu = new MenuBar
			{
				Items = {},
				ApplicationItems = {},
				QuitItem = quitCommand,
				AboutItem = aboutCommand
			};

            // create toolbar			
            ToolBar = new ToolBar { Items = { } };
        }
    }
}
