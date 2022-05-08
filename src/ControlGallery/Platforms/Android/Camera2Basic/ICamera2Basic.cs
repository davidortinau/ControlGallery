using System;
using Android.App;
using Android.Content;
using Android.Hardware.Camera2;
using Android.OS;
using Camera2Basic.Listeners;
using Java.Util.Concurrent;
using Semaphore = Java.Util.Concurrent.Semaphore;

namespace Camera2Basic
{
    public interface ICamera2Basic
    {
        Semaphore mCameraOpenCloseLock { get; set; }
        CameraDevice mCameraDevice { get; set; }
        Activity Activity { get; set; }
        Camera2BasicState mState { get; set; }
        Handler mBackgroundHandler { get; set; }
        CameraCaptureSession mCaptureSession { get; set; }
        CaptureRequest.Builder mPreviewRequestBuilder { get; set; }
        CaptureRequest mPreviewRequest { get; set; }
        CameraCaptureListener mCaptureCallback {get;set;}

        void CreateCameraPreviewSession();
        void CaptureStillPicture();
        void RunPrecaptureSequence();
        void OpenCamera(int width, int height);
        void ConfigureTransform(int width, int height);
        void UnlockFocus();
        void OnCaptureComplete();
    }
}
