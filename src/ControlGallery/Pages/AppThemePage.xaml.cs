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

        void OnChangeTheme(object s, EventArgs e)
        {
            OSAppTheme currentTheme = Application.Current.RequestedTheme;
            Application.Current.UserAppTheme = (currentTheme == OSAppTheme.Light) ? OSAppTheme.Dark : OSAppTheme.Light;
            CurrentThemeLabel.Text = Application.Current.UserAppTheme.ToString();
        }

    }
}