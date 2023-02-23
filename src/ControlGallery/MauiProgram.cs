#if WINDOWS
using Microsoft.Maui.LifecycleEvents;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

using System.Diagnostics;
using ControlGallery.Extensions;
using ControlGallery.Services;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.Maui.Handlers;
using static Microsoft.Maui.Controls.Button;
using Microsoft.Maui.Controls.Maps;
using Tbc.Target.Config;
using IContainer = DryIoc.IContainer;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;

#if IOS || MACCATALYST
using UIKit;
using Microsoft.Maui.Controls.Platform;
using static Microsoft.Maui.Controls.Platform.ButtonExtensions;
using CoreGraphics;
using Foundation;
using CommunityToolkit.Maui.Markup;
#endif

namespace ControlGallery;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        var container = ConfigureMutableContainer(builder);
        
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMarkup()
            .UseMauiMaps()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("fa_solid.ttf", "FontAwesome");
				fonts.AddFont("opensans_regular.ttf", "OpenSansRegular");
				fonts.AddFont("opensans_semibold.ttf", "OpenSansSemiBold");
                fonts.AddFont("fabmdl2.ttf", "FabMDL2");
            });

        // Microsoft.Maui.Controls.Internals.Profile.Enable();
        // Microsoft.Maui.Controls.Internals.Profile.Start();

        var app = builder.Build();
#if DEBUG	
        Task.Run(() => RunTbc(app, container));
#endif
        return app;
	}
    
    private static async Task RunTbc(MauiApp app, IContainer container)
    {
        var rm = new ReloadManager(container);
        var ts = new Tbc.Target.TargetServer(TargetConfiguration.Default(port: 50129));
        await ts.Run(rm, x => Debug.WriteLine(x));
    }

    private static IContainer ConfigureMutableContainer(MauiAppBuilder builder)
    {
        // this is the dryioc container
        var container =
            new Container(Rules.MicrosoftDependencyInjectionRules)
                .RegisterApplicationTypes(typeof(MauiProgram).Assembly.GetTypes());

        // this makes it maui friendly
        builder.ConfigureContainer(new DryIocServiceProviderFactory(container));

        return container;
    }
}