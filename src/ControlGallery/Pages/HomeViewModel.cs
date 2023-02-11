using System;
using CodeHollow.FeedReader;
using AsyncAwaitBestPractices;
using System.Diagnostics;
using AngleSharp.Html.Parser;
using System.Text.Json;
using ControlGallery.Models;

namespace ControlGallery.Pages;

[INotifyPropertyChanged]
public partial class HomeViewModel
{
    [ObservableProperty]
    private List<FeedItem> articles;

    [ObservableProperty]
    private GithubRelease latestRelease;

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
        GetLatestRelease().SafeFireAndForget();
	}

    async Task LoadBlogs()
    {
        var feed = await FeedReader.ReadAsync("https://devblogs.microsoft.com/dotnet/category/maui/feed/");

        var htmlParser = new HtmlParser();
        foreach (var item in feed.Items)
        {

            var document = htmlParser.ParseDocument(item.Description);
            item.Description = document.QuerySelector("p").TextContent;
        }

        try
        {
            Articles = new List<FeedItem>(feed.Items);
        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    HttpClient _client;
    JsonSerializerOptions _serializerOptions;

    async Task GetLatestRelease()
    {
        _client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        Uri uri = new Uri("https://api.github.com/repos/dotnet/maui/releases/latest");
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                LatestRelease = JsonSerializer.Deserialize<GithubRelease>(content, _serializerOptions);
                //Items = JsonSerializer.Deserialize<List<TodoItem>>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

    }
}