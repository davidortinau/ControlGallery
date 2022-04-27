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
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
			CurrentThemeLabel.Text = Application.Current.UserAppTheme.ToString();
		}

        void OnChangeTheme(object s, EventArgs e)
        {
            AppTheme currentTheme = Application.Current.RequestedTheme;
            Application.Current.UserAppTheme = (currentTheme == AppTheme.Light) ? AppTheme.Dark : AppTheme.Light;
            CurrentThemeLabel.Text = Application.Current.UserAppTheme.ToString();
        }

        

    }
}