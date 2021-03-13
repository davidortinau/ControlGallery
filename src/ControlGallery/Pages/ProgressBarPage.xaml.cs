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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressBarPage : ContentPage, IPage
    {
        public IView View { get => (IView)Content; set => Content = (View)value; }
        private bool isActiveWindow;

        public ProgressBarPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            isActiveWindow = true;
            Device.StartTimer(TimeSpan.FromSeconds(0.05), TimerCallback);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            isActiveWindow = false;
        }

        bool TimerCallback()
        {
            progressBar.Progress += 0.01;
            if(isActiveWindow && progressBar.Progress == 1)
                progressBar.Progress = 0;
            return isActiveWindow || progressBar.Progress == 1;
        }
    }
}