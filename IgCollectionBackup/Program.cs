// See https://aka.ms/new-console-template for more information

using InstagramApi;
using InstagramApi.Data;
using Spectre.Console;

class Program {
    private static HttpClient Client { get; } = new();
    
    public static async Task Main() {
        Instagram ig = new();
        
        ItemsResponse<Collection> collections = await ig.GetCollections();
        AnsiConsole.WriteLine(collections.ToString());

        List<Collection> selectedCollections = AnsiConsole.Prompt(new MultiSelectionPrompt<Collection>()
            .Title("Select collections to backup")
            .AddChoices(collections.Items)
            .UseConverter(x => $"{x.CollectionName} [{x.CollectionMediaCount} items]".EscapeMarkup()));
        
        if (selectedCollections.Count == 0) {
            AnsiConsole.MarkupLine("[red]No collections selected[/]");
            return;
        }

        foreach (Collection collection in selectedCollections) {
            AnsiConsole.WriteLine($"Downloading collection: {collection.CollectionName}");
            Progress progress = AnsiConsole.Progress();

            await progress.StartAsync(async ctx => await DownloadCollection(collection, ig, ctx));
        }
    }

    private static async Task DownloadCollection(Collection collection, Instagram ig, ProgressContext ctx) {
        ProgressTask task = ctx.AddTask("Download", maxValue: collection.CollectionMediaCount);

        ItemsResponse<MediaWrapper>? collectionMedia = await ig.GetCollectionMedia(collection);
        foreach (MediaWrapper mediaWrapper in collectionMedia.Items) {
            Media media = mediaWrapper.Media;
            await DownloadFile(Client, media);
            
            task.Increment(1);
        }

        while ((collectionMedia = await ig.GetCollectionMediaNextPage(collection, collectionMedia)) != null) {
            foreach (MediaWrapper mediaWrapper in collectionMedia.Items) {
                Media media = mediaWrapper.Media;
                await DownloadFile(Client, media);
                
                task.Increment(1);
            }
        }
    }

    private static async Task DownloadFile(HttpClient client, Media media) {
        string webFilename = media.ImageVersions.Candidates[0].Url;
        byte[] byteArray = await client.GetByteArrayAsync(webFilename);

        Uri uri = new(webFilename);
        string extension = Path.GetExtension(uri.LocalPath);
        
        DateTimeOffset time = DateTimeOffset.FromUnixTimeSeconds(media.TakenAt);
        string timeText = time.ToString("yyyyMMddTHHmm");
        
        string fileName = $"{media.User.Username} - {timeText}{extension}";

        Image image = Image.Load(byteArray);
        await image.SaveAsync(fileName);
    }
}