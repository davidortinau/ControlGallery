#if WINDOWS
using Microsoft.Maui.LifecycleEvents;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

using ControlGallery.Common.Effects;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

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
        
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMarkup()
            .UseMauiMaps()
            .UseVirtualListView()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("fa_solid.ttf", "FontAwesome");
				fonts.AddFont("opensans_regular.ttf", "OpenSansRegular");
				fonts.AddFont("opensans_semibold.ttf", "OpenSansSemiBold");
                fonts.AddFont("fabmdl2.ttf", "FabMDL2");
            })

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