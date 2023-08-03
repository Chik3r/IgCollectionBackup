// See https://aka.ms/new-console-template for more information

using InstagramApi;
using InstagramApi.Data;
using Spectre.Console;

class Program {
    private static HttpClient Client { get; } = new();
    private const string OutputFolder = "output";

    public static async Task Main() {
        string cookie = AnsiConsole.Ask<string>("Enter your Instagram cookie: ");
        string asbdId = AnsiConsole.Ask<string>("Enter your Instagram asbdId: ");
        string crsfToken = AnsiConsole.Ask<string>("Enter your Instagram crsfToken: ");
        string igAppId = AnsiConsole.Ask<string>("Enter your Instagram igAppId: ");
        string igWwwClaim = AnsiConsole.Ask<string>("Enter your Instagram igWwwClaim: ");
        AnsiConsole.WriteLine();

        Instagram ig = new(cookie, asbdId, crsfToken, igAppId, igWwwClaim);
        
        ItemsResponse<Collection> collections = await ig.GetCollections();

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
        string folder = OutputFolder + "/" + collection.CollectionName;
        if (Directory.Exists(folder))
            Directory.Delete(folder, true);
        
        Directory.CreateDirectory(folder);

        ItemsResponse<MediaWrapper>? collectionMedia = await ig.GetCollectionMedia(collection);
        foreach (MediaWrapper mediaWrapper in collectionMedia.Items) {
            Media media = mediaWrapper.Media;
            await DownloadFile(Client, media, folder);
            
            task.Increment(1);
        }

        while ((collectionMedia = await ig.GetCollectionMediaNextPage(collection, collectionMedia)) != null) {
            foreach (MediaWrapper mediaWrapper in collectionMedia.Items) {
                Media media = mediaWrapper.Media;
                await DownloadFile(Client, media, folder);
                
                task.Increment(1);
            }
        }
    }

    private static async Task DownloadFile(HttpClient client, Media media, string folder) {
        string webFilename = media.ImageVersions.Candidates[0].Url;
        byte[] byteArray = await client.GetByteArrayAsync(webFilename);

        Uri uri = new(webFilename);
        string extension = Path.GetExtension(uri.LocalPath);
        
        DateTimeOffset time = DateTimeOffset.FromUnixTimeSeconds(media.TakenAt);
        string timeText = time.ToString("yyyyMMddTHHmm");
        
        string fileName = $"{folder}/{media.User.Username} - {timeText}{extension}";

        Image image = Image.Load(byteArray);
        await image.SaveAsync(fileName);
    }
}