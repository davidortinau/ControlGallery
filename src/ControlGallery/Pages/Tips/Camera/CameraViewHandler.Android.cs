using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
//using PlatformView = Google.Android.Material.Button.MaterialButton;

namespace ControlGallery.Handlers;

public partial class CameraViewHandler : ViewHandler<ICameraView, ContentViewGroup>
{
    protected override ContentViewGroup CreatePlatformView()
    {
        throw new NotImplementedException(); 
    }

    public static void MapSpecialColor(ICameraViewHandler handler, ICameraView view)
    {
        
    }
}
