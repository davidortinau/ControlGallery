using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ControlGallery.Pages.Layouts
{	public class HorizontalStackPage : ContentPage
	{
		public HorizontalStackPage()
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

            this.Content = new ScrollView()
            {
                Orientation = ScrollOrientation.Horizontal,
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Orientation = StackOrientation.Horizontal,
                    Children =
                    {
                        new BoxView { Color = Colors.Red },
                        new BoxView { Color = Colors.Yellow },
                        new BoxView { Color = Colors.Blue },
                        new BoxView { Color = Colors.Green },
                        new BoxView { Color = Colors.Orange },
                        new BoxView { Color = Colors.Purple }
                    }
                }
            };
		}
	}
}
