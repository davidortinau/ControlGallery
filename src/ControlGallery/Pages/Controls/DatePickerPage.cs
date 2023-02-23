namespace ControlGallery.Pages;

public class DatePickerPage : BaseContentPage
{
    protected override void Build()
    {
        this.Title = "DatePicker";

        this.Content = new ScrollView{
            Content = new VerticalStackLayout{
                Spacing = 12,
                Children = {
                    new H1("Default"),
                    new Separator(),
                    new DatePicker(),
    
                }
            }.DynamicResource(Label.StyleProperty, "MainContainer")
        };
    }
}