using Microsoft.Maui.Controls;
using System;
using Microsoft.Maui.Controls.Xaml;
using System.Diagnostics;

namespace ControlGallery.Pages;

public partial class AlertPage : ContentPage
{
    public AlertPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //Debug.WriteLine("Trying to DisplayAlert");
        this.DisplayAlert("Welcome", ".NET MAUI supports simple platform alerts.", "Okay");
    }

    private async void YesNo_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
        this.Dispatcher.Dispatch(() =>
        {
            YesNoLbl.Text = "Answer: " + answer;
        });
    }

    private async void ActionSheet_Clicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("ActionSheet: Send to?", "Cancel", null, "Email", "Twitter", "Facebook");
        this.Dispatcher.Dispatch(() =>
        {
            ActionLbl.Text = "Action: " + action;
        });
        
    }

    
    private async void Prompt_Clicked(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Question 1", "What's your name?");
        this.Dispatcher.Dispatch(() =>
        {
            PromptLbl.Text = "Result: " + result;
        });

    }

}