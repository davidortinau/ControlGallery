using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ControlGallery.Pages.Controls.TableView
{
	public partial class DataIntentXaml : ContentPage
	{
		public DataIntentXaml ()
		{
			InitializeComponent ();
		}

        void OnViewCellTapped(object sender, EventArgs e)
        {
            _target.IsVisible = !_target.IsVisible;
            _viewCell.ForceUpdateSize();
        }
	}
}
