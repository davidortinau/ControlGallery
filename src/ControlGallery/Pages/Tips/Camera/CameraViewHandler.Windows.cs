using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Microsoft.UI.Xaml.Controls;
using Frame = Microsoft.UI.Xaml.Controls.Frame;

namespace ControlGallery.Handlers;

public partial class CameraViewHandler : ViewHandler<ICameraView, Frame>
{
    protected override Frame CreatePlatformView()
    {
        return new Frame();
    }

    public static void MapSpecialColor(ICameraViewHandler handler, ICameraView view)
    {
        handler.PlatformView?.UpdateForegroundColor(view.Color);
    }
}
