#if __IOS__ || MACCATALYST
using Microsoft.Maui.Handlers;
using PlatformView = UIKit.UIView;
#elif MONOANDROID
using PlatformView = Google.Android.Material.Button.MaterialButton;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.Button;
#elif TIZEN
using PlatformView = Tizen.UIExtensions.ElmSharp.Button;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

namespace ControlGallery.Handlers;

public partial class CameraViewHandler : ICameraViewHandler
{
    public static IPropertyMapper<ICameraView, ICameraViewHandler> Mapper = new PropertyMapper<ICameraView, ICameraViewHandler>(ViewHandler.ViewMapper)
    {
            [nameof(ICameraView.Color)] = MapSpecialColor
    };

    public static CommandMapper<ICameraView, ICameraViewHandler> CommandMapper = new(ViewCommandMapper);


    public CameraViewHandler() : base(Mapper, CommandMapper)
    { }

    public CameraViewHandler(IPropertyMapper? mapper) : base(mapper ?? Mapper, CommandMapper)
    {
    }

    ICameraView ICameraViewHandler.VirtualView => VirtualView;

    PlatformView ICameraViewHandler.PlatformView => PlatformView;
}
