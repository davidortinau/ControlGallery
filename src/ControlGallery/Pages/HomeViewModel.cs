using System;
using CodeHollow.FeedReader;
using AsyncAwaitBestPractices;
using System.Diagnostics;

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

        //Console.WriteLine("Feed Title: " + feed.Title);
        //Console.WriteLine("Feed Description: " + feed.Description);
        //Console.WriteLine("Feed Image: " + feed.ImageUrl);
        //// ...
        //foreach (var item in feed.Items)
        //{
        //    Console.WriteLine(item.Title + " - " + item.Link);
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



