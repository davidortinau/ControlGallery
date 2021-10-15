using ControlGallery.Pages;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using System;

namespace ControlGallery
{
	public partial class App : Microsoft.Maui.Controls.Application
	{
		public App()
		{
			InitializeComponent();

			RegisterRoutes();

			App.Current.UserAppTheme = OSAppTheme.Light;
		}

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(ActivityIndicatorPage),typeof(ActivityIndicatorPage));
			Routing.RegisterRoute(nameof(AlertPage), typeof(AlertPage));
			Routing.RegisterRoute(nameof(AppThemePage), typeof(AppThemePage));
			Routing.RegisterRoute(nameof(BorderPage), typeof(BorderPage));
			Routing.RegisterRoute(nameof(ButtonPage), typeof(ButtonPage));
			Routing.RegisterRoute(nameof(CheckboxPage), typeof(CheckboxPage));
			Routing.RegisterRoute(nameof(DatePickerPage), typeof(DatePickerPage));
			Routing.RegisterRoute(nameof(EditorPage), typeof(EditorPage));
			Routing.RegisterRoute(nameof(EntryPage), typeof(EntryPage));
			Routing.RegisterRoute(nameof(ImagePage), typeof(ImagePage));
			Routing.RegisterRoute(nameof(LabelPage), typeof(LabelPage));
			Routing.RegisterRoute(nameof(ProgressBarPage), typeof(ProgressBarPage));
			Routing.RegisterRoute(nameof(RadioButtonPage), typeof(RadioButtonPage));
			Routing.RegisterRoute(nameof(ShadowPage), typeof(ShadowPage));
			Routing.RegisterRoute(nameof(ShapesPage), typeof(ShapesPage));
			Routing.RegisterRoute(nameof(SliderPage), typeof(SliderPage));
			Routing.RegisterRoute(nameof(StepperPage), typeof(StepperPage));
			Routing.RegisterRoute(nameof(SwitchPage), typeof(SwitchPage));
		}
    }
}