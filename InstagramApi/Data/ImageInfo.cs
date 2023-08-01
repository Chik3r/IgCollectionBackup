using System.Text.Json.Serialization;

namespace InstagramApi.Data; 

public record ImageInfo(
    [property: JsonPropertyName("width")] int Width,
    [property: JsonPropertyName("height")] int Height,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("scans_profile")] string? ScansProfile
);