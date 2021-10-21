using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ControlGallery.Pages.Layouts
{	public class VerticalStackPage : ContentPage
	{
		public VerticalStackPage()
		{
            Style boxStyle = new Style(typeof(BoxView))
            {
                Setters =
                {
                    new Setter { Property = BoxView.HeightRequestProperty, Value = 50 },
                    new Setter { Property = BoxView.WidthRequestProperty, Value = 50 }
                }
            };
            Resources.Add(boxStyle);

            this.Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children =
                {
                    new Label { Text = "Primary colors" },
                    new BoxView { Color = Colors.Red },
                    new BoxView { Color = Colors.Yellow },
                    new BoxView { Color = Colors.Blue },
                    new Label { Text = "Secondary colors" },
                    new BoxView { Color = Colors.Green },
                    new BoxView { Color = Colors.Orange },
                    new BoxView { Color = Colors.Purple }
                }
            };
		}
	}
}
