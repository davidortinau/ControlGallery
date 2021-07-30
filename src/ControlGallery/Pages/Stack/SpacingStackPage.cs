using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace LayoutLab
{	public class SpacingStackPage : ContentPage
	{
		public SpacingStackPage()
		{
            BackgroundColor = Colors.White;
            this.Content = new StackLayout
            {
                Margin = new Thickness(20),
                Spacing = 0,
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
