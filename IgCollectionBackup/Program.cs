// See https://aka.ms/new-console-template for more information

using InstagramApi;
using InstagramApi.Data;
using Spectre.Console;

class Program {
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

            await progress.StartAsync(async ctx => {
                ProgressTask task = ctx.AddTask("Download", maxValue: collection.CollectionMediaCount);

                ItemsResponse<MediaWrapper>? collectionMedia = await ig.GetCollectionMedia(collection);
                foreach (MediaWrapper mediaWrapper in collectionMedia.Items) {
                    Media media = mediaWrapper.Media;
                    string fileName = media.ImageVersions.Candidates[0].Url;
                    task.Increment(1);
                }

                while ((collectionMedia = await ig.GetCollectionMediaNextPage(collection, collectionMedia)) != null) {
                    foreach (MediaWrapper mediaWrapper in collectionMedia.Items) {
                        Media media = mediaWrapper.Media;
                        string fileName = media.ImageVersions.Candidates[0].Url;
                        task.Increment(1);
                    }
                }
            });
        }
    }
}