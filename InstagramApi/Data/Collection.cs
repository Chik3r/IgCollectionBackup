using System.Text.Json.Serialization;

namespace InstagramApi.Data; 

public record Collection(
    [property: JsonPropertyName("collection_id")] string CollectionId,
    [property: JsonPropertyName("collection_name")] string CollectionName,
    [property: JsonPropertyName("collection_type")] string CollectionType,
    [property: JsonPropertyName("collection_media_count")] int CollectionMediaCount,
    [property: JsonPropertyName("cover_media_list")] IReadOnlyList<CoverMedia> CoverMediaList,
    [property: JsonPropertyName("cover_media")] CoverMedia CoverMedia,
    [property: JsonPropertyName("viewer_access_level")] string ViewerAccessLevel
);