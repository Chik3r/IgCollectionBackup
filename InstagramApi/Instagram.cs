using System.Text.Json;
using InstagramApi.Data;

namespace InstagramApi;

public class Instagram {
    private HttpClient Client { get; } = new();
    
    private string Cookie { get; }
    private string AsbdId { get; }
    private string CrsfToken { get; }
    private string IgAppId { get; }
    private string IgWwwClaim { get; }

    public Instagram(string cookie, string asbdId, string crsfToken, string igAppId, string igWwwClaim) {
        Cookie = cookie;
        AsbdId = asbdId;
        CrsfToken = crsfToken;
        IgAppId = igAppId;
        IgWwwClaim = igWwwClaim;
    }

    public async Task<ItemsResponse<Collection>> GetCollections() {
        HttpRequestMessage request = new(HttpMethod.Get,
            "https://www.instagram.com/api/v1/collections/list/?collection_types=%5B%22ALL_MEDIA_AUTO_COLLECTION%22%2C%22MEDIA%22%2C%22AUDIO_AUTO_COLLECTION%22%5D&include_public_only=0&max_id=");
        AddRequiredHeaders(ref request);
        
        HttpResponseMessage response = await Client.SendAsync(request);
        string content = await response.Content.ReadAsStringAsync();
        
        return JsonSerializer.Deserialize<ItemsResponse<Collection>>(content)!;
    }

    public Task<ItemsResponse<MediaWrapper>> GetCollectionMedia(Collection collection) =>
        GetCollectionMedia(collection.CollectionId);

    public async Task<ItemsResponse<MediaWrapper>> GetCollectionMedia(string collectionId) {
        string uri;
        if (collectionId == "ALL_MEDIA_AUTO_COLLECTION")
            uri = "https://www.instagram.com/api/v1/feed/saved/posts/";
        else
            uri = $"https://www.instagram.com/api/v1/feed/collection/{collectionId}/posts/";
        
        HttpRequestMessage request = new(HttpMethod.Get, uri);
        AddRequiredHeaders(ref request);
        
        HttpResponseMessage response = await Client.SendAsync(request);
        string content = await response.Content.ReadAsStringAsync();
        
        return JsonSerializer.Deserialize<ItemsResponse<MediaWrapper>>(content)!;
    }
    
    public Task<ItemsResponse<MediaWrapper>?> GetCollectionMediaNextPage(Collection collection, ItemsResponse<MediaWrapper> previousPage) =>
        GetCollectionMediaNextPage(collection.CollectionId, previousPage);

    public async Task<ItemsResponse<MediaWrapper>?> GetCollectionMediaNextPage(string collectionId, ItemsResponse<MediaWrapper> previousPage) {
        if (!previousPage.MoreAvailable) return null;

        string uri;
        if (collectionId == "ALL_MEDIA_AUTO_COLLECTION")
            uri = "https://www.instagram.com/api/v1/feed/saved/posts/";
        else
            uri = $"https://www.instagram.com/api/v1/feed/collection/{collectionId}/posts/?max_id=";
        uri += $"?max_id={previousPage.NextMaxId}";
        
        HttpRequestMessage request = new(HttpMethod.Get, uri);
        AddRequiredHeaders(ref request);
        
        HttpResponseMessage response = await Client.SendAsync(request);
        string content = await response.Content.ReadAsStringAsync();
        
        return JsonSerializer.Deserialize<ItemsResponse<MediaWrapper>>(content)!;
    }

    private void AddRequiredHeaders(ref HttpRequestMessage request) {
        request.Headers.Add("Cookie", Cookie);
        request.Headers.Add("x-asbd-id", AsbdId);
        request.Headers.Add("x-csrftoken", CrsfToken);
        request.Headers.Add("x-ig-app-id", IgAppId);
        request.Headers.Add("x-ig-www-claim", IgWwwClaim);
    }
}