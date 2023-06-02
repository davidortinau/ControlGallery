using CommunityToolkit.Maui.Markup;
using Xceed.Maui.Toolkit;
using Button  = Xceed.Maui.Toolkit.Button;
using Border = Xceed.Maui.Toolkit.Border;

namespace ControlGallery.Pages.Xceed;

public class XceedControlsPage : BaseContentPage
{
    
    protected override void Build()
    {
        this.Title = "Xceed Controls";

        App.Current.Resources.TryGetValue("FluentDesignButton", out object fbd);

        this.Content = new ScrollView{
            Content = new VerticalStackLayout{
                Children = {
                    new H1("Border"),
                    new Separator(),
                    new Border {
                        CornerRadius = new CornerRadius(15,0,15,0),
                        BorderBrush = Colors.Black,
                        BorderThickness = 3,
                        Background = Colors.Silver,
                        Content = new Label().Text("Border Label")
                    }
                    .Start()
                    .Padding(8),
                    new H1("Buttons"),
                    new Separator(),
                    new Button{
                        Content = new Label().Text("Button Label"),
                        CornerRadius = 20,
                        HorizontalContentAlignment = LayoutOptions.Start,
                        Style = fbd as Style,
                    }
                    .Start()
                    .Padding(8)
                    .TapGesture(() =>
                    {
                        this.DisplayAlert("Welcome", ".NET MAUI supports simple platform alerts.", "Okay");
                    }),
                    new H1("ToggleButton"),
                    new Separator(),
                    new ToggleButton{
                        Content = new Label().Text("Toggle Button")
                    },
                    new H1("RepeatButton"),
                    new Separator(),
                    new RepeatButton{
                        Content = new Label().Text("Repeat Button")
                    },
                    new H1("Numeric"),
                    new Separator(),
                    new IntegerUpDown()
                        .Size(60)
                    ,
                    new H1("ButtonSpinner"),
                    new Separator(),
                    new ButtonSpinner{
                        AllowSpin = true,
                        Content = new Label().Text("Spinner"),
                        SpinnerDownContentTemplate = new DataTemplate(() =>
                        {
                            var label = new Label
                            {
                                Text = "down template"
                            };
                            return new ViewCell { View = label };
                        }),
                        SpinnerUpContentTemplate = new DataTemplate(() =>
                        {
                            var label = new Label
                            {
                                Text = "up template"
                            };
                            return new ViewCell { View = label };
                        }),
                    },
                    new H1("Card"),
                    new Separator(),
                    new Card{
                        Content = new Label().Text("Card Label"),
                        CornerRadius = 20,
                        BackgroundColor = Colors.Silver,
                    }.Padding(12).Size(300).Start(),

                }
            }.DynamicResource(Label.StyleProperty, "MainContainer")
        };
    }
}