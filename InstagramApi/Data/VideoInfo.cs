using System.Text.Json.Serialization;

namespace InstagramApi.Data; 

public record VideoVersion(
    [property: JsonPropertyName("type")] int Type,
    [property: JsonPropertyName("width")] int Width,
    [property: JsonPropertyName("height")] int Height,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("id")] string Id
);