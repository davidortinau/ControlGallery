using System;
using CodeHollow.FeedReader;
using AsyncAwaitBestPractices;
using System.Diagnostics;
using AngleSharp.Html.Parser;

namespace ControlGallery.Pages;

[INotifyPropertyChanged]
public partial class HomeViewModel
{
    [ObservableProperty]
    private List<FeedItem> articles;

    [RelayCommand]
    async Task NavigateTo(string link)
    {
        try
        {
            await Browser.OpenAsync(link);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Crap: {ex.Message}");
        }
    }

	public HomeViewModel()
    {
		LoadBlogs().SafeFireAndForget();
	}

    async Task LoadBlogs()
    {
        var feed = await FeedReader.ReadAsync("https://devblogs.microsoft.com/dotnet/category/maui/feed/");

        //var htmlParser = new HtmlParser();
        //foreach (var item in feed.Items)
        //{
            
        //    var document = htmlParser.ParseDocument(item.Description);
        //    item.Description = document.QuerySelector("p").TextContent;
        //}

        try
        {
            Articles = new List<FeedItem>(feed.Items);
        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }



}