namespace ControlGallery.Pages.Features;

[INotifyPropertyChanged]
public partial class AppThemeViewModel
{

	public AppTheme CurrentTheme
	{
		get {
			return Application.Current.UserAppTheme;
		}
		set
		{
            if (App.Current.UserAppTheme == value)
                return;

            App.Current.UserAppTheme = value;
            OnPropertyChanged(nameof(CurrentTheme));
        }
	}

	[RelayCommand]
	void ThemeChanged(AppTheme theme)
	{

        if (App.Current.UserAppTheme == theme)
            return;

        App.Current.UserAppTheme = theme;
		OnPropertyChanged(nameof(CurrentTheme));
    }

    public AppThemeViewModel()
    {
        App.Current.RequestedThemeChanged += Current_RequestedThemeChanged;
    }

    private void Current_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
    {
        OnPropertyChanged(nameof(CurrentTheme));
    }
}

