using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace LayoutLab
{	public class HorizontalStackPage : ContentPage
	{
		public HorizontalStackPage()
		{
			this.Content = new ScrollView()
            {
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
