using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionViewDemos.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace ControlGallery.Pages
{
    public partial class VirtualListViewPage : ContentPage
    {
        public VirtualListViewPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}