using System.Text.Json.Serialization;

namespace InstagramApi.Data; 

public record ImageVersions(
    [property: JsonPropertyName("candidates")] IReadOnlyList<ImageInfo> Candidates
);