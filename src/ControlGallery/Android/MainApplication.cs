﻿using System;
using Android.App;
using Android.Runtime;
using Microsoft.Maui;

namespace ControlGallery
{
	[Application]
	public class MainApplication : MauiApplication<Application>
	{
		public MainApplication(IntPtr handle, JniHandleOwnership ownerShip) : base(handle, ownerShip)
		{
		}
	}
}