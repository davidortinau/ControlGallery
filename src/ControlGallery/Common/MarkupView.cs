using CommunityToolkit.Maui.Markup;
using ControlGallery.Common;

namespace ControlGallery.Common;

public class MarkupView : ContentView
{
	public MarkupView()
	{
		Content = new HorizontalStackLayout
		{
			Children =
			{
				new Button()
					.Text("Button")
					.Style("PrimaryButtonOutline")
					.TapGesture(()=>Button_Clicked()),
				new Button()
					.Text("Button")
					.Style("PrimaryButtonOutline")
					.TapGesture(()=>Button_Clicked())
					.IsEnabled(false),
			}
		};
	}

	void Button_Clicked()
	{
		// do click things
	}
}
