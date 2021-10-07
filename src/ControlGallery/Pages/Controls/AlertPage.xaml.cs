using Microsoft.Maui.Controls;
using System;
using Microsoft.Maui.Controls.Xaml;
using System.Diagnostics;

namespace ControlGallery.Pages
{
    public partial class AlertPage : ContentPage
    {
        public AlertPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Debug.WriteLine("Trying to DisplayAlert");
            this.DisplayAlert("Welcome", ".NET MAUI supports simple platform alerts.", "Okay");
        }
    }
}