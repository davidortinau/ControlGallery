#if WINDOWS
using Microsoft.Maui.LifecycleEvents;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

using ControlGallery.Common.Effects;
using Fonts;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Syncfusion.Maui.Toolkit.Hosting;

#if IOS || MACCATALYST
using UIKit;
using Microsoft.Maui.Controls.Platform;
using static Microsoft.Maui.Controls.Platform.ButtonExtensions;
using CoreGraphics;
using Foundation;
using CommunityToolkit.Maui.Markup;
using System.Reflection;
#endif

namespace ControlGallery;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMarkup()
            .UseMauiMaps()
            .UseVirtualListView()
            .ConfigureSyncfusionToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("fa_solid.ttf", "FontAwesome");
				fonts.AddFont("opensans_regular.ttf", "OpenSansRegular");
				fonts.AddFont("opensans_semibold.ttf", "OpenSansSemiBold");
                fonts.AddFont("fabmdl2.ttf", "FabMDL2");
                fonts.AddFont("FluentSystemIcons-Regular.ttf", FluentUI.FontFamily);
            })
            // .ConfigureResources(resources =>
            // {
            //     resources.AddResource("Sizes.xaml");
            //     resources.AddResource("Icons.xaml");
            //     resources.AddResource("Colors.xaml");
            //     resources.AddResource("Text.xaml");
            //     resources.AddResource("Converters.xaml");
            //     resources.AddResource("DefaultStyles.xaml");
            //     resources.AddResource("AppStyles.xaml");
            // })

			.ConfigureEffects(effects =>
			{
                #if IOS || MACCATALYST
				effects.Add<ContentInsetAdjustmentBehaviorRoutingEffect, ContentInsetAdjustmentBehaviorPlatformEffect>();
                #endif
			})

#if DEBUG
			// .EnableHotReload()
#endif
            ;

            

        // Microsoft.Maui.Controls.Internals.Profile.Enable();
        // Microsoft.Maui.Controls.Internals.Profile.Start();



        var app = builder.Build();

        Microsoft.Maui.Handlers.EditorHandler.Mapper.ReplaceMapping(nameof(EditorHandler.MapPlaceholder),
                (IEditorHandler handler, IEditor editor) =>
                {
                    handler.PlatformView?.UpdatePlaceholder(editor);
                    handler.PlatformView?.UpdateCharacterSpacing(editor);
                });
        
        

        return app;
	}

}

public static class AppBuilderExtensions
{
    public static MauiAppBuilder ConfigureResources(
        this MauiAppBuilder builder,
        Action<ResourcesConfiguration> configureDelegate)
    {
        var config = new ResourcesConfiguration();
        configureDelegate(config);
        
        builder.ConfigureMauiHandlers(async handlers =>
        {
            // Register resources when the app starts
            Application.Current.Resources.MergedDictionaries.Clear();
            
            foreach(var resource in config.Resources)
            {
                await using Stream stream = await FileSystem.OpenAppPackageFileAsync(resource);
                
                using (var reader = new StreamReader(stream))
                {
                    var xamlContent = reader.ReadToEnd();
                    var resourceDictionary = new ResourceDictionary().LoadFromXaml(xamlContent);
                    Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
                }
                
            }
        });

        return builder;
    }
}

public class ResourcesConfiguration
{
    internal List<string> Resources { get; } = new();

    public void AddResource(string resourcePath)
    {
        Resources.Add(resourcePath);
    }
}