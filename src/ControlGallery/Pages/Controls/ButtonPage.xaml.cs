using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGallery.Pages;

public partial class ButtonPage : ContentPage
{
    int counter;

    public int Counter
    {
        get
        {
            return counter;
        }
        set
        {
            counter = value;
            OnPropertyChanged();
        }
    }

    public ButtonPage()
    {
        InitializeComponent();

        BindingContext = this;
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Counter++;
        ShowCount();
    }

    async void ShowCount()
    {
        CounterLbl.CancelAnimations();
        await CounterLbl.FadeTo(1, 200);
        await CounterLbl.FadeTo(1, 600);// just to buffer before fade out
        await CounterLbl.FadeTo(0, 200);
    }
}