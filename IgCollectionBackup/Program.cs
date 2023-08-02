// See https://aka.ms/new-console-template for more information

using InstagramApi;
using InstagramApi.Data;
using Spectre.Console;

Console.WriteLine("Hello, World!");

Instagram ig = new();

ItemsResponse<Collection> tmp = await ig.GetCollections();
AnsiConsole.WriteLine(tmp.ToString());

foreach (Collection collection in tmp.Items) {
    ItemsResponse<MediaWrapper> tmp2 = await ig.GetCollectionMedia(collection);
    Console.WriteLine(tmp2);

    ItemsResponse<MediaWrapper>? nextPage;
    while ((nextPage = await ig.GetCollectionMediaNextPage(collection, tmp2)) != null) {
        Console.WriteLine(nextPage);
    }
}