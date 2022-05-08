using Android.Media;
using Java.IO;
using Java.Lang;
using Java.Nio;
using Camera2Basic;

namespace Camera2Basic.Listeners
{
	public class ImageAvailableListener : Java.Lang.Object, ImageReader.IOnImageAvailableListener
	{
		public ImageAvailableListener(ICamera2Basic fragment, File file)
		{
			if (fragment == null)
				throw new System.ArgumentNullException("fragment");
			if (file == null)
				throw new System.ArgumentNullException("file");

			owner = fragment;
			this.file = file;
		}

		private readonly File file;
		private readonly ICamera2Basic owner;

		public void OnImageAvailable(ImageReader reader)
		{
			owner.mBackgroundHandler.Post(new ImageSaver(reader.AcquireNextImage(), file, owner));
		}

		// Saves a JPEG {@link Image} into the specified {@link File}.
		private class ImageSaver : Java.Lang.Object, IRunnable
		{
			// The JPEG image
			private Image mImage;

			// The file we save the image into.
			private File mFile;

			private ICamera2Basic mOwner;

			public ImageSaver(Image image, File file, ICamera2Basic owner)
			{
				if (image == null)
					throw new System.ArgumentNullException("image");
				if (file == null)
					throw new System.ArgumentNullException("file");

				mImage = image;
				mFile = file;
				mOwner = owner;
			}

			public void Run()
			{
				ByteBuffer buffer = mImage.GetPlanes()[0].Buffer;
				byte[] bytes = new byte[buffer.Remaining()];
				buffer.Get(bytes);
				using (var output = new FileOutputStream(mFile))
				{
					try
					{
						output.Write(bytes);
					}
					catch (IOException e)
					{
						e.PrintStackTrace();
					}
					finally
					{
						mImage.Close();
						mOwner.OnCaptureComplete();
					}
				}
			}
		}
	}
}