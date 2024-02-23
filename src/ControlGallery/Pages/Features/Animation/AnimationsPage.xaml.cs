namespace ControlGallery.Pages.Features.Animation;

public partial class AnimationsPage : ContentPage
{
    public Command NavigateCommand { get; private set; }

    public AnimationsPage()
	{
		InitializeComponent();

        NavigateCommand = new Command<Type>(
                async (Type pageType) =>
                {
                    await Shell.Current.GoToAsync(pageType.Name);
                });

        BindingContext = this;
    }
}
