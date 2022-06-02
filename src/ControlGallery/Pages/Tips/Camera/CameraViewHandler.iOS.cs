using Microsoft.Maui.Handlers;
using UIKit;

namespace ControlGallery.Handlers;

public partial class CameraViewHandler : ViewHandler<ICameraView, UIView>
{
    protected override UIView CreatePlatformView()
    {
        throw new NotImplementedException(); 
    }

    public static void MapSpecialColor(ICameraViewHandler handler, ICameraView view)
    {
        
    }
}
