using System.Text.Json.Serialization;

namespace InstagramApi.Data; 

public record ItemsResponse<T>(
    [property: JsonPropertyName("items")] IReadOnlyList<T> Items,
    [property: JsonPropertyName("num_results") ]int? NumResults,
    [property: JsonPropertyName("more_available")] bool MoreAvailable,
    [property: JsonPropertyName("auto_load_more_enabled")] bool AutoLoadMoreEnabled,
    [property: JsonPropertyName("status")] string Status
);