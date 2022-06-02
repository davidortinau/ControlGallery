using Microsoft.Maui.Handlers;

namespace ControlGallery.Handlers;

public partial class CameraViewHandler : ViewHandler<ICameraView, object>
{
	protected override object CreatePlatformView() => throw new NotImplementedException();

    public static void MapSpecialColor(ICameraViewHandler handler, ICameraView view) { }

}