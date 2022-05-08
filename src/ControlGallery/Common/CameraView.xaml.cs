using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceVision.Models;
using ConferenceVision.Services;
using ConferenceVision.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConferenceVision.Views
{
	public partial class CameraView : ContentPage
	{
		CameraViewModel vm;

		public CameraViewModel ViewModel
		{
			get => vm; set
			{
				vm = value;
				BindingContext = vm;
			}
		}

		public CameraView()
		{
			InitializeComponent();
			if (vm == null)
				ViewModel = new CameraViewModel();

			vm.PropertyChanged += Vm_PropertyChanged;
		}

		async void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(vm.HasAchievement))
			{
				if (vm.HasAchievement)
				{
					var fadeIn = AchievementIndicator.FadeTo(1, 400, Easing.SpringIn);
					var taskDelay = Task.Delay(1000);
					await Task.WhenAll(fadeIn, taskDelay);
					await AchievementIndicator.FadeTo(0, 2000, Easing.SinIn);


				}
			}
		}


		private double width = 0;
		private double height = 0;

		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height); //must be called
			if (this.width != width || this.height != height)
			{
				this.width = width;
				this.height = height;

				VisualStateManager.GoToState(Container, (width > height) ? "Horizontal" : "Portrait");
				VisualStateManager.GoToState(LastImage, (width > height) ? "Horizontal" : "Portrait");
			}
		}


		public void StopCamera()
		{
			Camera.StopRecording?.Invoke();
		}
		protected override void OnDisappearing()
		{
			MessagingCenter.Unsubscribe<App>(this, "OnSleep");

			StopCamera();
			base.OnDisappearing();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			MessagingCenter.Subscribe<App>(this, "OnSleep", async (app) =>
			{
				StopCamera();
				await Navigation.PopModalAsync(false);
			});
		}

		void OnCaptureTapped(object sender, EventArgs args)
		{
			Camera.StartRecording();
		}

		async void OnCloseAsync(object sender, EventArgs e)
		{
			StopCamera();
			await Navigation.PopModalAsync(true);
		}

		async void NavToDetailAsync(object sender, System.EventArgs e)
		{
			StopCamera();
			MessagingCenter.Send<CameraView, Memory>(this, "GoToImage", vm.LastMemory);
			await Navigation.PopModalAsync(true);
		}
	}
}