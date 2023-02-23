using CommunityToolkit.Maui.Markup;

namespace ControlGallery.Pages;

public class AlertPage : BaseContentPage
{
    Label YesNoLbl, ActionLbl, PromptLbl;

    protected override void Build()
    {
        this.Title = "Alerts";

        this.Content = new ScrollView{
            Content = new VerticalStackLayout{
                Children = {
                    new H1("Simple Alert"),
                    new Separator(),
                    new Button()
                    .Text("Display Alert")
                    .TapGesture(() =>
                    {
                        this.DisplayAlert("Welcome", ".NET MAUI supports simple platform alerts.", "Okay");
                    }),

                    new H1("Return Response"),
                    new Separator(),
                    new Button()
                    .Text("Display Alert")
                    .TapGesture(async () =>
                    {
                        bool answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
                        this.Dispatcher.Dispatch(() =>
                        {
                            YesNoLbl.Text = "Answer: " + answer;
                        });
                    }),
                    new Label()
                        .Assign(out YesNoLbl)
                        .TextColor(AppColors.Primary),

                    new H1("Action Sheet"),
                    new Separator(),
                    new Button()
                    .Text("Display Alert")
                    .TapGesture(async () =>
                    {
                        string action = await DisplayActionSheet("ActionSheet: Send to?", "Cancel", null, "Email", "Twitter", "Facebook");
                        this.Dispatcher.Dispatch(() =>
                        {
                            ActionLbl.Text = "Action: " + action;
                        });
                    }),
                    new Label()
                        .Assign(out ActionLbl)
                        .TextColor(AppColors.Primary),

                    new H1("Prompt"),
                    new Separator(),
                    new Button()
                    .Text("Display Alert")
                    .TapGesture(async () =>
                    {
                        string result = await DisplayPromptAsync("Question 1", "What's your name?");
                        this.Dispatcher.Dispatch(() =>
                        {
                            PromptLbl.Text = "Result: " + result;
                        });
                    }),
                    new Label()
                        .Assign(out PromptLbl)
                        .TextColor(AppColors.Primary),
                }
            }.DynamicResource(Label.StyleProperty, "MainContainer")
        };
    }
}