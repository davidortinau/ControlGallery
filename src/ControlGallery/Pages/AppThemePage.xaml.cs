using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace ControlGallery.Pages
{
    public partial class AppThemePage : ContentPage
    {
        public AppThemePage()
        {
            InitializeComponent();
            // InitMenu();
        }

        void OnChangeTheme(object s, EventArgs e)
        {
            OSAppTheme currentTheme = Application.Current.RequestedTheme;
            Application.Current.UserAppTheme = (currentTheme == OSAppTheme.Light) ? OSAppTheme.Dark : OSAppTheme.Light;
            CurrentThemeLabel.Text = Application.Current.UserAppTheme.ToString();
        }

        void InitMenu()
		{
			var mainMenu = new Menu();

			var fileMenu = new Menu { Text = "File" };
			var exitItem = new MenuItem
			{
				Text = "Exit",
				Command = new Command((obj) =>
				{
					Application.Current.Quit();
				})
			};
			MenuItem.SetAccelerator(exitItem, Accelerator.FromString("cmd+q"));
			fileMenu.Items.Add(exitItem);

			var locationMenu = new Menu { Text = "Location" };
			var changeItem = new MenuItem
			{
				Text = "Change",
				Command = new Command((obj) =>
				{
					Navigation.PushAsync(new ButtonPage());
				})
			};
			locationMenu.Items.Add(changeItem);

			var refreshItem = new MenuItem
			{
				Text = "Refresh"
			};
			MenuItem.SetAccelerator(refreshItem, Accelerator.FromString("cmd+r"));
			locationMenu.Items.Add(refreshItem);

			mainMenu.Add(fileMenu);
			mainMenu.Add(locationMenu);
			SetMenu(Application.Current, mainMenu); 
		}

    }
}