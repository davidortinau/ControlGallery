﻿using System;
using Microsoft.Maui; 
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;
using ControlGallery.Common;

namespace ControlGallery.Pages.Layouts.AbsoluteLayouts
{
    public partial class ProportionalCoordinateCalcDemoPage : ContentPage
    {
        public ProportionalCoordinateCalcDemoPage()
        {
            InitializeComponent();

            Rectangle[] fractionalRects =
            {
                new Rectangle(0.05, 0.1, 0.90, 0.1),    // outer top
                new Rectangle(0.05, 0.8, 0.90, 0.1),    // outer bottom
                new Rectangle(0.05, 0.1, 0.05, 0.8),    // outer left
                new Rectangle(0.90, 0.1, 0.05, 0.8),    // outer right

                new Rectangle(0.15, 0.3, 0.70, 0.1),    // inner top
                new Rectangle(0.15, 0.6, 0.70, 0.1),    // inner bottom
                new Rectangle(0.15, 0.3, 0.05, 0.4),    // inner left
                new Rectangle(0.80, 0.3, 0.05, 0.4),    // inner right
            };

            foreach(Rectangle fractionalRect in fractionalRects)
            {
                Rectangle layoutBounds = new Rectangle
                {
                    // Proportional coordinate calculations
                    X = fractionalRect.X / (1 - fractionalRect.Width),
                    Y = fractionalRect.Y / (1 - fractionalRect.Height),
                    Width = fractionalRect.Width,
                    Height = fractionalRect.Height
                };

                absoluteLayout.Add(new BoxView
                {
                    Color = Colors.DarkBlue
                }, layoutBounds, AbsoluteLayoutFlags.All);
            }
        }

        void OnContentViewSizeChanged(object sender, EventArgs args)
        {
            ContentView contentView = (ContentView)sender;

            // Figure has an aspect ratio of 2:1
            double height = Math.Min(contentView.Width / 2, contentView.Height);
            absoluteLayout.WidthRequest = 2 * height;
            absoluteLayout.HeightRequest = height;
        }
    }
}
