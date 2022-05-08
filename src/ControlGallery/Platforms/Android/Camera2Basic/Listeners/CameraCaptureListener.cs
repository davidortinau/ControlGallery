using Android.Hardware.Camera2;
using Java.IO;
using Java.Lang;
using Camera2Basic;

namespace Camera2Basic.Listeners
{
	public class CameraCaptureListener : CameraCaptureSession.CaptureCallback
	{
		private readonly ICamera2Basic owner;

		public CameraCaptureListener(ICamera2Basic owner)
		{
			if (owner == null)
				throw new System.ArgumentNullException("owner");
			this.owner = owner;
		}

		public override void OnCaptureCompleted(CameraCaptureSession session, CaptureRequest request, TotalCaptureResult result)
		{
			Process(result);
		}

		public override void OnCaptureProgressed(CameraCaptureSession session, CaptureRequest request, CaptureResult partialResult)
		{
			Process(partialResult);
		}

		private void Process(CaptureResult result)
		{
			switch (owner.mState)
			{
				case Camera2BasicState.STATE_WAITING_LOCK:
					{
						Integer afState = (Integer)result.Get(CaptureResult.ControlAfState);
						if (afState == null)
						{
							owner.CaptureStillPicture();
						}

						else if ((((int)ControlAFState.FocusedLocked) == afState.IntValue()) ||
								   (((int)ControlAFState.NotFocusedLocked) == afState.IntValue()))
						{
							// ControlAeState can be null on some devices
							Integer aeState = (Integer)result.Get(CaptureResult.ControlAeState);
							if (aeState == null ||
									aeState.IntValue() == ((int)ControlAEState.Converged))
							{
								owner.mState = Camera2BasicState.STATE_PICTURE_TAKEN;
								owner.CaptureStillPicture();
							}
							else
							{
								owner.RunPrecaptureSequence();
							}
						}
						break;
					}
				case Camera2BasicState.STATE_WAITING_PRECAPTURE:
					{
						// ControlAeState can be null on some devices
						Integer aeState = (Integer)result.Get(CaptureResult.ControlAeState);
						if (aeState == null ||
								aeState.IntValue() == ((int)ControlAEState.Precapture) ||
								aeState.IntValue() == ((int)ControlAEState.FlashRequired))
						{
							owner.mState = Camera2BasicState.STATE_WAITING_NON_PRECAPTURE;
						}
						break;
					}
				case Camera2BasicState.STATE_WAITING_NON_PRECAPTURE:
					{
						// ControlAeState can be null on some devices
						Integer aeState = (Integer)result.Get(CaptureResult.ControlAeState);
						if (aeState == null || aeState.IntValue() != ((int)ControlAEState.Precapture))
						{
							owner.mState = Camera2BasicState.STATE_PICTURE_TAKEN;
							owner.CaptureStillPicture();
						}
						break;
					}
				case Camera2BasicState.STATE_PICTURE_TAKEN:
					{
						System.Diagnostics.Debug.WriteLine("STATE_PICTURE_TAKEN");
						break;
					}
			}
		}
	}
}