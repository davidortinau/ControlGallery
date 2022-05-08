using Android.Hardware.Camera2;
using Android.Util;

namespace Camera2Basic.Listeners
{
	public class CameraCaptureStillPictureSessionCallback : CameraCaptureSession.CaptureCallback
	{
		private static readonly string TAG = "CameraCaptureStillPictureSessionCallback";

		private readonly ICamera2Basic owner;

		public CameraCaptureStillPictureSessionCallback(ICamera2Basic owner)
		{
			if (owner == null)
				throw new System.ArgumentNullException("owner");
			this.owner = owner;
		}

		public override void OnCaptureCompleted(CameraCaptureSession session, CaptureRequest request, TotalCaptureResult result)
		{
			owner.UnlockFocus();
		}
	}
}
