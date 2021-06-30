using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace LayoutLab
{	public class ExpansionStackPage : ContentPage
	{
		public ExpansionStackPage()
		{
			BackgroundColor = Colors.White;
			this.Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children = {
					new BoxView { BackgroundColor = Colors.Red, HeightRequest = 1 },
					new Label { Text = "StartAndExpand", BackgroundColor = Colors.Gray, VerticalOptions = LayoutOptions.StartAndExpand },
					new BoxView { BackgroundColor = Colors.Red, HeightRequest = 1 },
					new Label { Text = "CenterAndExpand", BackgroundColor = Colors.Gray, VerticalOptions = LayoutOptions.CenterAndExpand },
					new BoxView { BackgroundColor = Colors.Red, HeightRequest = 1 },
					new Label { Text = "EndAndExpand", BackgroundColor = Colors.Gray, VerticalOptions = LayoutOptions.EndAndExpand },
					new BoxView { BackgroundColor = Colors.Red, HeightRequest = 1 },
					new Label { Text = "FillAndExpand", BackgroundColor = Colors.Gray, VerticalOptions = LayoutOptions.FillAndExpand },
					new BoxView { BackgroundColor = Colors.Red, HeightRequest = 1 }
				}
			};
		}
	}
}
