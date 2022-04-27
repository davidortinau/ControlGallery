namespace ControlGallery.Pages;

public partial class ControlsPage : ContentPage
{
    public ControlsPage()
    {
        InitializeComponent();

			//InitMenu();
    }

		void InitMenu()
		{
			var fileMenu = new MenuBarItem { Text = "File" };
			var exitItem = new MenuFlyoutItem
			{
				Text = "Exit",
				Command = new Command((obj) =>
				{
					Application.Current.Quit();
				})
			};
			MenuItem.SetAccelerator(exitItem, Accelerator.FromString("cmd+q"));
			fileMenu.Add(exitItem);

			var locationMenu = new MenuBarItem { Text = "Location" };
			var changeItem = new MenuFlyoutItem
			{
				Text = "Change",
				Command = new Command((obj) =>
				{
					Navigation.PushAsync(new ButtonPage());
				})
			};
			locationMenu.Add(changeItem);

			var refreshItem = new MenuFlyoutItem
			{
				Text = "Refresh"
			};
			MenuItem.SetAccelerator(refreshItem, Accelerator.FromString("cmd+r"));
			locationMenu.Add(refreshItem);

			this.MenuBarItems.Add(fileMenu);
			this.MenuBarItems.Add(locationMenu);
		}
	}