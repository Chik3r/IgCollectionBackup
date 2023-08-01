using System.Text.Json.Serialization;

namespace InstagramApi.Data; 

public record MediaWrapper(
    [property: JsonPropertyName("media")] Media Media
);