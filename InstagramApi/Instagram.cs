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
        request.Headers.Add("Cookie", Cookie);
        request.Headers.Add("x-asbd-id", AsbdId);
        request.Headers.Add("x-csrftoken", CrsfToken);
        request.Headers.Add("x-ig-app-id", IgAppId);
        request.Headers.Add("x-ig-www-claim", IgWwwClaim);
        
        HttpResponseMessage response = await Client.SendAsync(request);
        string content = await response.Content.ReadAsStringAsync();
        
        return JsonSerializer.Deserialize<ItemsResponse<Collection>>(content)!;
    }
}