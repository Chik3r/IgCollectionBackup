using System.Text.Json.Serialization;

namespace InstagramApi.Data; 

public record CoverMedia(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("media_type")] int MediaType,
    [property: JsonPropertyName("image_versions2")] ImageVersions ImageVersions,
    [property: JsonPropertyName("original_width")] int OriginalWidth,
    [property: JsonPropertyName("original_height")] int OriginalHeight,
    [property: JsonPropertyName("explore_pivot_grid")] bool ExplorePivotGrid,
    [property: JsonPropertyName("accessibility_caption")] string AccessibilityCaption,
    [property: JsonPropertyName("product_type")] string ProductType
);