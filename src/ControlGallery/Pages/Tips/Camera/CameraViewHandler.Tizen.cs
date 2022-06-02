using Microsoft.Maui.Handlers;
using PView = Tizen.UIExtensions.ElmSharp.Button;

namespace ControlGallery.Handlers;

public partial class CameraViewHandler : ViewHandler<ICameraView, PView>
{
    protected override PView CreatePlatformView()
    {
        throw new NotImplementedException(); 
    }

    public static void MapSpecialColor(ICameraViewHandler handler, ICameraView view)
    {
        
    }
}
