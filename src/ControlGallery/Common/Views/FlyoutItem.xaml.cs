using CommunityToolkit.Mvvm.Messaging;
using ControlGallery.Common.Messages;

namespace ControlGallery.Common.Views;

public partial class FlyoutItem : Grid
{
    private bool isLabelVisible = true;
    public bool IsLabelVisible { get => isLabelVisible; set { isLabelVisible = value; OnPropertyChanged(); } }

    public FlyoutItem()
    {
        InitializeComponent();

        this.BindingContext = this;

        WeakReferenceMessenger.Default.Register<ToggleFlyoutHeaderMsg>(this, (r, m) =>
		{
            this.ColumnDefinitions[2].Width = m.IsVisible ? GridLength.Star : 0;
            IsLabelVisible = m.IsVisible;
		});
    }
}