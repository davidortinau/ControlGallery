using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Essentials;

namespace ControlGallery.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public LabelPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}