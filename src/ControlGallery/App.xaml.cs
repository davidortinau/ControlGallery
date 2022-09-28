using CollectionViewDemos.Views;
using ControlGallery.Pages;
using ControlGallery.Pages.Controls.TableView;
using ControlGallery.Pages.Layouts;
using ControlGallery.Pages.Layouts.AbsoluteLayouts;

namespace ControlGallery;

public partial class App : Microsoft.Maui.Controls.Application
{
    public App()
    {
        InitializeComponent();

        RegisterRoutes();

        AppShell.BindingContext = new AppShellViewModel();

        //App.Current.UserAppTheme = AppTheme.Light;
    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute(nameof(ActivityIndicatorPage), typeof(ActivityIndicatorPage));
        Routing.RegisterRoute(nameof(AlertPage), typeof(AlertPage));
        Routing.RegisterRoute(nameof(BorderPage), typeof(BorderPage));
        Routing.RegisterRoute(nameof(ButtonPage), typeof(ButtonPage));
        Routing.RegisterRoute(nameof(CheckboxPage), typeof(CheckboxPage));
        Routing.RegisterRoute(nameof(DatePickerPage), typeof(DatePickerPage));
        Routing.RegisterRoute(nameof(EditorPage), typeof(EditorPage));
        Routing.RegisterRoute(nameof(EntryPage), typeof(EntryPage));
        Routing.RegisterRoute(nameof(ImagePage), typeof(ImagePage));
        Routing.RegisterRoute(nameof(LabelPage), typeof(LabelPage));
        Routing.RegisterRoute(nameof(ProgressBarPage), typeof(ProgressBarPage));
        Routing.RegisterRoute(nameof(RadioButtonPage), typeof(RadioButtonPage));
        Routing.RegisterRoute(nameof(ShapesPage), typeof(ShapesPage));
        Routing.RegisterRoute(nameof(SliderPage), typeof(SliderPage));
        Routing.RegisterRoute(nameof(StepperPage), typeof(StepperPage));
        Routing.RegisterRoute(nameof(SwitchPage), typeof(SwitchPage));
        Routing.RegisterRoute(nameof(FramePage), typeof(FramePage));
        Routing.RegisterRoute(nameof(RefreshViewPage), typeof(RefreshViewPage));
        Routing.RegisterRoute(nameof(WebViewPage), typeof(WebViewPage));
        Routing.RegisterRoute(nameof(TimePickerPage), typeof(TimePickerPage));
        Routing.RegisterRoute(nameof(PickerPage), typeof(PickerPage));
        Routing.RegisterRoute(nameof(SearchBarPage), typeof(SearchBarPage));

        // Layouts
        Routing.RegisterRoute(nameof(BasisExperimentPage), typeof(BasisExperimentPage));
        Routing.RegisterRoute(nameof(CatalogItemsPage), typeof(CatalogItemsPage));
        Routing.RegisterRoute(nameof(CssCatalogItemsPage), typeof(CssCatalogItemsPage));
        Routing.RegisterRoute(nameof(GrowExperimentPage), typeof(GrowExperimentPage));
        Routing.RegisterRoute(nameof(PhotoWrappingPage), typeof(PhotoWrappingPage));
        Routing.RegisterRoute(nameof(ShrinkExperimentPage), typeof(ShrinkExperimentPage));
        Routing.RegisterRoute(nameof(SimpleStackPage), typeof(SimpleStackPage));

        Routing.RegisterRoute(nameof(AlignmentGridPage), typeof(AlignmentGridPage));
        Routing.RegisterRoute(nameof(BasicGridPage), typeof(BasicGridPage));
        Routing.RegisterRoute(nameof(CalculatorPage), typeof(CalculatorPage));
        Routing.RegisterRoute(nameof(KeypadPage), typeof(KeypadPage));
        Routing.RegisterRoute(nameof(SliderGridPage), typeof(SliderGridPage));
        Routing.RegisterRoute(nameof(SpacingGridPage), typeof(SpacingGridPage));

        Routing.RegisterRoute(nameof(AlignmentStackPage), typeof(AlignmentStackPage));
        Routing.RegisterRoute(nameof(CombinedStackPage), typeof(CombinedStackPage));
        Routing.RegisterRoute(nameof(ExpansionStackPage), typeof(ExpansionStackPage));
        Routing.RegisterRoute(nameof(HorizontalStackPage), typeof(HorizontalStackPage));
        Routing.RegisterRoute(nameof(SpacingStackPage), typeof(SpacingStackPage));
        Routing.RegisterRoute(nameof(VerticalStackPage), typeof(VerticalStackPage));
        Routing.RegisterRoute(nameof(AndExpandPage), typeof(AndExpandPage));
        
        Routing.RegisterRoute(nameof(HorizontalWrapLayoutPage), typeof(HorizontalWrapLayoutPage));
        Routing.RegisterRoute(nameof(CascadeLayoutPage), typeof(CascadeLayoutPage));
        Routing.RegisterRoute(nameof(ColumnLayoutPage), typeof(ColumnLayoutPage));


        Routing.RegisterRoute(nameof(MarginPaddingPage), typeof(MarginPaddingPage));

        Routing.RegisterRoute(nameof(TableViewPage), typeof(TableViewPage));

        Routing.RegisterRoute(nameof(DataIntentXaml), typeof(DataIntentXaml));
        Routing.RegisterRoute(nameof(EntryCellDemoXaml), typeof(EntryCellDemoXaml));
        Routing.RegisterRoute(nameof(FormIntentXaml), typeof(FormIntentXaml));
        Routing.RegisterRoute(nameof(MenuIntentXaml), typeof(MenuIntentXaml));
        Routing.RegisterRoute(nameof(SettingsIntentXaml), typeof(SettingsIntentXaml));
        Routing.RegisterRoute(nameof(SwitchCellDemoXaml), typeof(SwitchCellDemoXaml));

        Routing.RegisterRoute(nameof(BouncingTextDemoPage), typeof(BouncingTextDemoPage));
        Routing.RegisterRoute(nameof(ChessboardDemoPage), typeof(ChessboardDemoPage));
        Routing.RegisterRoute(nameof(ProportionalCoordinateCalcDemoPage), typeof(ProportionalCoordinateCalcDemoPage));
        Routing.RegisterRoute(nameof(ProportionalDemoPage), typeof(ProportionalDemoPage));
        Routing.RegisterRoute(nameof(SimpleOverlayDemoPage), typeof(SimpleOverlayDemoPage));
        Routing.RegisterRoute(nameof(StylishHeaderDemoPage), typeof(StylishHeaderDemoPage));

        Routing.RegisterRoute(nameof(CollectionViewPage), typeof(CollectionViewPage));
        Routing.RegisterRoute(nameof(EmptyViewDataTemplateSelectorPage), typeof(EmptyViewDataTemplateSelectorPage));
        Routing.RegisterRoute(nameof(EmptyViewFilteredPage), typeof(EmptyViewFilteredPage));
        Routing.RegisterRoute(nameof(EmptyViewLoadSimulationPage), typeof(EmptyViewLoadSimulationPage));
        Routing.RegisterRoute(nameof(EmptyViewNullPage), typeof(EmptyViewNullPage));
        Routing.RegisterRoute(nameof(EmptyViewSwapPage), typeof(EmptyViewSwapPage));
        Routing.RegisterRoute(nameof(EmptyViewTemplatePage), typeof(EmptyViewTemplatePage));
        Routing.RegisterRoute(nameof(EmptyViewWithViewsFilteredPage), typeof(EmptyViewWithViewsFilteredPage));

        Routing.RegisterRoute(nameof(VerticalListEmptyGroupsPage), typeof(VerticalListEmptyGroupsPage));
        Routing.RegisterRoute(nameof(VerticalListGroupingPage), typeof(VerticalListGroupingPage));
        Routing.RegisterRoute(nameof(VerticalListGroupingVariableSizeItemsPage), typeof(VerticalListGroupingVariableSizeItemsPage));
        Routing.RegisterRoute(nameof(VerticalListTextGroupingPage), typeof(VerticalListTextGroupingPage));

        Routing.RegisterRoute(nameof(HorizontalGridHeaderFooterViewPage), typeof(HorizontalGridHeaderFooterViewPage));
        Routing.RegisterRoute(nameof(VerticalListHeaderFooterDataTemplatePage), typeof(VerticalListHeaderFooterDataTemplatePage));
        Routing.RegisterRoute(nameof(VerticalListHeaderFooterStringPage), typeof(VerticalListHeaderFooterStringPage));
        Routing.RegisterRoute(nameof(VerticalListHeaderFooterViewPage), typeof(VerticalListHeaderFooterViewPage));

        Routing.RegisterRoute(nameof(HorizontalGridPage), typeof(HorizontalGridPage));
        Routing.RegisterRoute(nameof(HorizontalGridTextPage), typeof(HorizontalGridTextPage));
        Routing.RegisterRoute(nameof(HorizontalListPage), typeof(HorizontalListPage));
        Routing.RegisterRoute(nameof(HorizontalListTextPage), typeof(HorizontalListTextPage));
        Routing.RegisterRoute(nameof(VerticalGridPage), typeof(VerticalGridPage));
        Routing.RegisterRoute(nameof(VerticalListDataTemplateSelectorPage), typeof(VerticalListDataTemplateSelectorPage));
        Routing.RegisterRoute(nameof(VerticalListPage), typeof(VerticalListPage));
        Routing.RegisterRoute(nameof(VerticalListRTLPage), typeof(VerticalListRTLPage));
        Routing.RegisterRoute(nameof(VerticalListTextPage), typeof(VerticalListTextPage));

        Routing.RegisterRoute(nameof(HorizontalGridPullToRefreshPage), typeof(HorizontalGridPullToRefreshPage));
        Routing.RegisterRoute(nameof(VerticalListPullToRefreshPage), typeof(VerticalListPullToRefreshPage));

        // Features pages
        Routing.RegisterRoute(nameof(AppThemePage), typeof(AppThemePage));
        Routing.RegisterRoute(nameof(ColorsPage), typeof(ColorsPage));
        Routing.RegisterRoute(nameof(FontImagePage), typeof(FontImagePage));
        Routing.RegisterRoute(nameof(MenuBarPage), typeof(MenuBarPage));
        Routing.RegisterRoute(nameof(TriggersPage), typeof(TriggersPage));
        Routing.RegisterRoute(nameof(NativeViewsPage), typeof(NativeViewsPage));
        Routing.RegisterRoute(nameof(ClippingPage), typeof(ClippingPage));
        Routing.RegisterRoute(nameof(ShadowPage), typeof(ShadowPage));
        Routing.RegisterRoute(nameof(ContextMenuPage), typeof(ContextMenuPage));


    }
}

[INotifyPropertyChanged]
public partial class AppShellViewModel
{
    private string appearance = App.Current.UserAppTheme.ToString();

    public string Appearance
    {
        get => appearance; 
        set
        {
            if (appearance == value)
                return;

            appearance = value;

            switch (appearance)
            {
                case "Light":
                    App.Current.UserAppTheme = AppTheme.Light;
                    break;
                case "Dark":
                    App.Current.UserAppTheme = AppTheme.Dark;
                    break;
                default:
                    App.Current.UserAppTheme = AppTheme.Unspecified;
                    break;
            }
        }
    }

    public AppShellViewModel()
    {
        App.Current.RequestedThemeChanged += Current_RequestedThemeChanged;    
    }

    private void Current_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
    {
        appearance = App.Current.UserAppTheme.ToString();
        OnPropertyChanged(nameof(Appearance));
    }
}
