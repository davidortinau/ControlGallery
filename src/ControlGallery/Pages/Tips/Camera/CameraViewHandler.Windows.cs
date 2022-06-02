using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Microsoft.UI.Xaml.Controls;
using MyControl = Microsoft.UI.Xaml.Controls.Button;

namespace ControlGallery.Handlers;

public partial class CameraViewHandler : ViewHandler<ICameraView, MyControl>
{
    protected override MyControl CreatePlatformView()
    {
        return new MyControl();
    }

    public static void MapSpecialColor(ICameraViewHandler handler, ICameraView view)
    {
        handler.PlatformView?.UpdateForegroundColor(view.Color);
    }
}
