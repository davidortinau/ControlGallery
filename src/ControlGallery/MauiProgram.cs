#if WINDOWS
using Microsoft.Maui.LifecycleEvents;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

using System.Diagnostics;
using CommunityToolkit.Maui.Markup;
using ControlGallery.Extensions;
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

        OverrideHandlers();

        Microsoft.Maui.Controls.Internals.Profile.Enable();
        Microsoft.Maui.Controls.Internals.Profile.Start();

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

    private static void OverrideHandlers()
    {
#if IOS || MACCATALYST
        ButtonHandler.Mapper.ModifyMapping(nameof(Button.ContentLayout), (handler, btn, element) =>
        {
            UpdateContentLayout(handler.PlatformView, (Button)btn);
        });
#endif
    }

    
#if IOS || MACCATALYST

    static CGRect GetTitleBoundingRect(this UIButton platformButton)
    {
        if (platformButton.CurrentAttributedTitle != null ||
                   platformButton.CurrentTitle != null)
        {
            var title =
                   platformButton.CurrentAttributedTitle ??
                   new NSAttributedString(platformButton.CurrentTitle, new UIStringAttributes { Font = platformButton.TitleLabel.Font });

            return title.GetBoundingRect(
                platformButton.Bounds.Size,
                NSStringDrawingOptions.UsesLineFragmentOrigin | NSStringDrawingOptions.UsesFontLeading,
                null);
        }

        return CGRect.Empty;
    }

    public static void UpdateContentLayout(this UIButton platformButton, Button button)
    {
        if (platformButton.Bounds.Width == 0)
        {
            return;
        }

        var imageInsets = new UIEdgeInsets();
        var titleInsets = new UIEdgeInsets();

        var layout = button.ContentLayout;
        var spacing = (nfloat)layout.Spacing;

        var image = platformButton.CurrentImage;


        // if the image is too large then we just position at the edge of the button
        // depending on the position the user has picked
        // This makes the behavior consistent with android
        var contentMode = UIViewContentMode.Center;

        if (image != null && !string.IsNullOrEmpty(platformButton.CurrentTitle))
        {
            // TODO: Do not use the title label as it is not yet updated and
            //       if we move the image, then we technically have more
            //       space and will require a new layout pass.

            var titleRect = platformButton.GetTitleBoundingRect();
            var titleWidth = titleRect.Width;
            var titleHeight = titleRect.Height;
            var imageWidth = image.Size.Width;
            var imageHeight = image.Size.Height;
            var buttonWidth = platformButton.Bounds.Width;
            var buttonHeight = platformButton.Bounds.Height;
            var sharedSpacing = spacing / 2;

            // These are just used to shift the image and title to center
            // Which makes the later math easier to follow
            imageInsets.Left += titleWidth / 2;
            imageInsets.Right -= titleWidth / 2;
            titleInsets.Left -= imageWidth / 2;
            titleInsets.Right += imageWidth / 2;

            if (layout.Position == ButtonContentLayout.ImagePosition.Top)
            {
                if (imageHeight > buttonHeight)
                {
                    contentMode = UIViewContentMode.Top;
                }
                else
                {
                    imageInsets.Top -= (titleHeight / 2) + sharedSpacing;
                    imageInsets.Bottom += titleHeight / 2;

                    titleInsets.Top += imageHeight / 2;
                    titleInsets.Bottom -= (imageHeight / 2) + sharedSpacing;
                }
            }
            else if (layout.Position == ButtonContentLayout.ImagePosition.Bottom)
            {
                if (imageHeight > buttonHeight)
                {
                    contentMode = UIViewContentMode.Bottom;
                }
                else
                {
                    imageInsets.Top += titleHeight / 2;
                    imageInsets.Bottom -= (titleHeight / 2) + sharedSpacing;
                }

                titleInsets.Top -= (imageHeight / 2) + sharedSpacing;
                titleInsets.Bottom += imageHeight / 2;
            }
            else if (layout.Position == ButtonContentLayout.ImagePosition.Left)
            {
                if (imageWidth > buttonWidth)
                {
                    contentMode = UIViewContentMode.Left;
                }
                else
                {
                    imageInsets.Left -= (titleWidth / 2) + sharedSpacing;
                    imageInsets.Right += titleWidth / 2;
                }

                titleInsets.Left += imageWidth / 2;
                titleInsets.Right -= (imageWidth / 2) + sharedSpacing;
            }
            else if (layout.Position == ButtonContentLayout.ImagePosition.Right)
            {
                if (imageWidth > buttonWidth)
                {
                    contentMode = UIViewContentMode.Right;
                }
                else
                {
                    imageInsets.Left += titleWidth / 2;
                    imageInsets.Right -= (titleWidth / 2) + sharedSpacing;
                }

                titleInsets.Left -= (imageWidth / 2) + sharedSpacing;
                titleInsets.Right += imageWidth / 2;
            }
        }

        platformButton.ImageView.ContentMode = contentMode;

        // This is used to match the behavior between platforms.
        // If the image is too big then we just hide the label because
        // the image is pushing the title out of the visible view.
        // We can't use insets because then the title shows up outside the 
        // bounds of the UIButton. We could set the UIButton to clip bounds
        // but that feels like it might cause confusing side effects
        if (contentMode == UIViewContentMode.Center)
            platformButton.TitleLabel.Layer.Hidden = false;
        else
            platformButton.TitleLabel.Layer.Hidden = true;

        platformButton.UpdatePadding(button);

#pragma warning disable CA1416 // TODO: [UnsupportedOSPlatform("ios15.0")]
        if (platformButton.ImageEdgeInsets != imageInsets ||
            platformButton.TitleEdgeInsets != titleInsets)
        {
            platformButton.ImageEdgeInsets = imageInsets;
            platformButton.TitleEdgeInsets = titleInsets;
            platformButton.Superview?.SetNeedsLayout();
        }
#pragma warning restore CA1416
    }
#endif

}


