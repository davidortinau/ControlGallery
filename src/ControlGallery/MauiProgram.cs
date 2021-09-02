using Microsoft.Maui;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;

namespace ControlGallery
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("fa_solid.ttf", "FontAwesome");
					fonts.AddFont("opensans_regular.ttf", "OpenSansRegular");
					fonts.AddFont("opensans_semibold.ttf", "OpenSansSemiBold");
				});

			return builder.Build();
		}
	}
}
