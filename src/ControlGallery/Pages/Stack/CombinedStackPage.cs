using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace LayoutLab
{	public class CombinedStackPage : ContentPage
	{
		public CombinedStackPage()
		{
            BackgroundColor = Colors.White;
			this.Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children =
                {
                    new Label { Text = "Primary colors" },
                    new Frame
                    {
                        BorderColor = Colors.Black,
                        Padding = new Thickness(5),
                        Content = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Spacing = 15,
                            Children =
                            {
                                new BoxView { Color = Colors.Red },
                                new Label { Text = "Red", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), VerticalOptions = LayoutOptions.Center }
                            }
                        }
                    },
                    new Frame
                    {
                        BorderColor = Colors.Black,
                        Padding = new Thickness(5),
                        Content = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Spacing = 15,
                            Children =
                            {
                                new BoxView { Color = Colors.Yellow },
                                new Label { Text = "Yellow", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), VerticalOptions = LayoutOptions.Center }
                            }
                        }
                    },
                    new Frame
                    {
                        BorderColor = Colors.Black,
                        Padding = new Thickness(5),
                        Content = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Spacing = 15,
                            Children =
                            {
                                new BoxView { Color = Colors.Blue },
                                new Label { Text = "Blue", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), VerticalOptions = LayoutOptions.Center }
                            }
                        }
                    },
                    new Label { Text = "Secondary colors" },
                    new Frame
                    {
                        BorderColor = Colors.Black,
                        Padding = new Thickness(5),
                        Content = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Spacing = 15,
                            Children =
                            {
                                new BoxView { Color = Colors.Green },
                                new Label { Text = "Green", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), VerticalOptions = LayoutOptions.Center }
                            }
                        }
                    },
                    new Frame
                    {
                        BorderColor = Colors.Black,
                        Padding = new Thickness(5),
                        Content = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Spacing = 15,
                            Children =
                            {
                                new BoxView { Color = Colors.Orange },
                                new Label { Text = "Orange", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), VerticalOptions = LayoutOptions.Center }
                            }
                        }
                    },
                    new Frame
                    {
                        BorderColor = Colors.Black,
                        Padding = new Thickness(5),
                        Content = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Spacing = 15,
                            Children =
                            {
                                new BoxView { Color = Colors.Purple },
                                new Label { Text = "Purple", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), VerticalOptions = LayoutOptions.Center }
                            }
                        }
                    },
                }
            };
		}
	}
}
