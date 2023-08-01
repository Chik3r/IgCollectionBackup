using System.Text.Json.Serialization;

namespace InstagramApi.Data; 

public record FriendshipStatus(
    [property: JsonPropertyName("following")] bool Following,
    [property: JsonPropertyName("outgoing_request")] bool OutgoingRequest,
    [property: JsonPropertyName("is_bestie")] bool IsBestie,
    [property: JsonPropertyName("is_restricted")] bool IsRestricted,
    [property: JsonPropertyName("is_feed_favorite")] bool IsFeedFavorite
);