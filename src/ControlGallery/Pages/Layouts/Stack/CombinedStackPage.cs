using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ControlGallery.Pages.Layouts
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
                                new Label { Text = "Red", FontSize = 16, VerticalOptions = LayoutOptions.Center }
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
                                new Label { Text = "Yellow", FontSize = 16, VerticalOptions = LayoutOptions.Center }
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
                                new Label { Text = "Blue", FontSize = 16, VerticalOptions = LayoutOptions.Center }
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
                                new Label { Text = "Green", FontSize = 16, VerticalOptions = LayoutOptions.Center }
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
                                new Label { Text = "Orange", FontSize = 16, VerticalOptions = LayoutOptions.Center }
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
                                new Label { Text = "Purple", FontSize = 16, VerticalOptions = LayoutOptions.Center }
                            }
                        }
                    },
                }
            };
		}
	}
}
