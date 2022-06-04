using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Microsoft.UI.Xaml.Controls;
using MyControl = Microsoft.UI.Xaml.Controls.Button;

namespace ControlGallery.Handlers;

public partial class CameraViewHandler : ViewHandler<ICameraView, MyControl>
{
    public static PropertyMapper<ICameraView, CameraViewHandler> CameraViewMapper = 
        new PropertyMapper<ICameraView, CameraViewHandler>(ViewHandler.ViewMapper)
    {
        [nameof(ICameraView.Color)] = MapSpecialColor
    };

    public static readonly CommandMapper<ICameraView, CameraViewHandler> CameraViewCommandMapper = new(ViewCommandMapper);

    public CameraViewHandler(IPropertyMapper mapper, CommandMapper commandMapper = null) : base(mapper ?? CameraViewMapper, commandMapper ?? CameraViewCommandMapper)
    {
    }

    public CameraViewHandler() : this(CameraViewMapper, CameraViewCommandMapper)
    {
    }

    protected override MyControl CreatePlatformView()
    {
        return new MyControl();
    }

    static void MapSpecialColor(CameraViewHandler handler, ICameraView view)
    {
        handler.PlatformView?.UpdateForegroundColor(view.Color);
    }
}
