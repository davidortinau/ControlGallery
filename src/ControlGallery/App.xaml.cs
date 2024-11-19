using System.Diagnostics;
using CommunityToolkit.Mvvm.Messaging;
using ControlGallery.Common.Messages;

namespace ControlGallery;

public partial class App : Microsoft.Maui.Controls.Application
{
    public App()
    {
        InitializeComponent();

        MauiExceptions.UnhandledException += (sender, args) =>
        {
            Debug.WriteLine($"Unhandled Exception: {args.ExceptionObject}");
            // _logger.LogCritical(e.ExceptionObject as Exception, "App failed to handle exception");
            throw (Exception)args.ExceptionObject;
        };
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = new Window(new AppShell());
        window.SizeChanged += UpdateFlyoutBehaviorIfNeeded;
        return window;
    }

    private const double minPageWidth = 800;
    private void UpdateFlyoutBehaviorIfNeeded(object sender, EventArgs e)
    {
        var window = (Window)sender;
        double currentWidth = window.Width + Shell.Current.FlyoutWidth; // don't get this, insteaed get the window size
        
        Debug.WriteLine($"currentWidth: {currentWidth}, " +
        $"PageWidth: {window.Width}, " +
            $"Shell.Current.FlyoutWidth: {Shell.Current.FlyoutWidth}"   );

        if (currentWidth < minPageWidth && Shell.Current.FlyoutWidth > 75)
        {
            // Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
            Shell.Current.FlyoutWidth = 75;
            WeakReferenceMessenger.Default.Send(new ToggleFlyoutHeaderMsg(false));
        }
        else if (currentWidth > minPageWidth && Shell.Current.FlyoutWidth < 320)
        {
            // Shell.Current.FlyoutBehavior = FlyoutBehavior.Locked;
            Shell.Current.FlyoutWidth = 320;
            WeakReferenceMessenger.Default.Send(new ToggleFlyoutHeaderMsg(true));
        }
    }   
}