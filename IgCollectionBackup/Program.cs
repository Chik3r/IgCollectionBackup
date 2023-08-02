// See https://aka.ms/new-console-template for more information

using InstagramApi;
using InstagramApi.Data;
using Spectre.Console;

class Program {
    public static async Task Main() {
        Instagram ig = new();
        
        ItemsResponse<Collection> tmp = await ig.GetCollections();
        AnsiConsole.WriteLine(tmp.ToString());

        List<string> selectedCollections = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
            .Title("Select collections to backup")
            .AddChoices(tmp.Items.Select(x => $"{x.CollectionName} [[{x.CollectionMediaCount} items]]")));

        AnsiConsole.WriteLine(string.Join(" - ", selectedCollections));
        return;

        foreach (Collection collection in tmp.Items) {
            ItemsResponse<MediaWrapper> tmp2 = await ig.GetCollectionMedia(collection);
            Console.WriteLine(tmp2);

            ItemsResponse<MediaWrapper>? nextPage;
            while ((nextPage = await ig.GetCollectionMediaNextPage(collection, tmp2)) != null) {
                Console.WriteLine(nextPage);
            }
        }
    }
}