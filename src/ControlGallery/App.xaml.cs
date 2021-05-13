﻿using ControlGallery.Pages;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;

namespace ControlGallery
{
	public partial class App : Microsoft.Maui.Controls.Application
	{
		public App()
		{
			InitializeComponent();
		}

		protected override IWindow CreateWindow(IActivationState activationState)
		{
			Microsoft.Maui.Controls.Compatibility.Forms.Init(activationState);

			this.On<Microsoft.Maui.Controls.PlatformConfiguration.Windows>()
				.SetImageDirectory("Assets");

			return new Microsoft.Maui.Controls.Window(
				new NavigationPage(
					new HomePage()
				)
			);
		}
	}
}