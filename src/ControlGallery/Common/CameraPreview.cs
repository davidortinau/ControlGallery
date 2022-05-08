using System.Diagnostics;
using System.Windows.Input;

namespace ConferenceVision.Views.Renderers
{
    public enum CameraOptions
    {
        Rear,
        Front
    }

    public class CameraPreview : View
    {
		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);
		}



		public static readonly BindableProperty CameraProperty = BindableProperty.Create(
            propertyName: "Camera",
            returnType: typeof(CameraOptions),
            declaringType: typeof(CameraPreview),
            defaultValue: CameraOptions.Rear);

        public CameraOptions Camera
        {
            get { return (CameraOptions)GetValue(CameraProperty); }
            set { SetValue(CameraProperty, value); }
        }

        public static readonly BindableProperty FilenameProperty = BindableProperty.Create<CameraPreview, string>(s => s.Filename, default(string));
        public string Filename
        {
            get { return (string)GetValue(FilenameProperty); }
            set { SetValue(FilenameProperty, value); }
        }

        public static readonly BindableProperty PosterPathProperty = BindableProperty.Create<CameraPreview, string>(s => s.PosterPath, default(string));
        public string PosterPath
        {
            get { return (string)GetValue(PosterPathProperty); }
            set { SetValue(PosterPathProperty, value); }
        }

        public static readonly BindableProperty TotalBytesProperty = BindableProperty.Create<CameraPreview, long>(s => s.TotalBytes, default(long));
        public long TotalBytes
        {
            get { return (long)GetValue(TotalBytesProperty); }
            set { SetValue(TotalBytesProperty, value); }
        }

        public static readonly BindableProperty SaveCommandProperty =
            BindableProperty.Create<CameraPreview, ICommand>(p => p.SaveCommand, default(ICommand));
        public ICommand SaveCommand
        {
            get
            {
                return (ICommand)GetValue(SaveCommandProperty);
            }
            set
            {
                SetValue(SaveCommandProperty, value);
            }
        }

        public static readonly BindableProperty EncodingIdProperty = BindableProperty.Create<CameraPreview, int>(s => s.EncodingId, default(int));
        public int EncodingId
        {
            get { return (int)GetValue(EncodingIdProperty); }
            set { SetValue(EncodingIdProperty, value); }
        }

        public Action StartRecording;
        public Action StopRecording;
        public Action Dispose;

        public void OnMediaSaved(string mediaPath, string posterPath, bool isLandscape, long totalBytes)
        {
            Debug.WriteLine("OnMovieSaved {0} {1}", mediaPath, posterPath);
            SetValue(PosterPathProperty, posterPath);
            SetValue(FilenameProperty, mediaPath);
            SetValue(TotalBytesProperty, totalBytes);
            SaveCommand.Execute(isLandscape);
        }


    }
}

