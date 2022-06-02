#if __IOS__ || MACCATALYST
using PlatformView = UIKit.UIView;
#elif MONOANDROID
using PlatformView = Google.Android.Material.Button.MaterialButton;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.Frame;
#elif TIZEN
using PlatformView = Tizen.UIExtensions.ElmSharp.Button;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

namespace ControlGallery.Handlers;

public partial interface ICameraViewHandler : IViewHandler
{
    new ICameraView VirtualView { get; }
    new PlatformView PlatformView { get; }
}
