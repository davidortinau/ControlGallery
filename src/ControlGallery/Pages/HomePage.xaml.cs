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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void OnClicked(object sender, EventArgs e)
		{
            Button btn = sender as Button;
            switch(btn.Text.ToLower())
            {
                case "activityindicator":
                    Navigation.PushAsync(new ActivityIndicatorPage());
                    break;
                case "button":
                    Navigation.PushAsync(new ButtonPage());
                    break;
                case "checkbox":
                    Navigation.PushAsync(new CheckboxPage());
                    break;
                case "editor":
                    Navigation.PushAsync(new EditorPage());
                    break;
                case "entry":
                    Navigation.PushAsync(new EntryPage());
                    break;
                case "label":
                    Navigation.PushAsync(new LabelPage());
                    break;
                case "progressbar":
                    Navigation.PushAsync(new ProgressBarPage());
                    break;
                case "radiobutton":
                    Navigation.PushAsync(new RadioButtonPage());
                    break;
                case "slider":
                    Navigation.PushAsync(new SliderPage());
                    break;
                case "stepper":
                    Navigation.PushAsync(new StepperPage());
                    break;
                case "switch":
                default:
                    Navigation.PushAsync(new SwitchPage());
                    break;
            }
			
		}
    }
}