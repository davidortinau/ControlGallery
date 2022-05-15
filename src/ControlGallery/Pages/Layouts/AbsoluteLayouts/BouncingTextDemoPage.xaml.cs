﻿using Microsoft.Maui.Dispatching;

namespace ControlGallery.Pages.Layouts.AbsoluteLayouts;

public partial class BouncingTextDemoPage : ContentPage
{
    const double period = 2000;
    readonly DateTime now = DateTime.Now;
    bool isCurrentPage;

    public BouncingTextDemoPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        isCurrentPage = true;

        this.Dispatcher.StartTimer(TimeSpan.FromMilliseconds(15), () =>
        {
            TimeSpan elapsed = DateTime.Now - now;
            double t = (elapsed.TotalMilliseconds % period) / period;
            t = 2 * (t < 0.5 ? t : 1 - t);

            AbsoluteLayout.SetLayoutBounds(label1, new Rect(t, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutBounds(label2, new Rect(0.5, 1-t, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            return isCurrentPage;
        });
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        isCurrentPage = false;
    }
}