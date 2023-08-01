using System.Text.Json.Serialization;

namespace InstagramApi.Data; 

public record CarouselMedium(
    string Id,
    int MediaType,
    ImageVersions ImageVersions,
    int OriginalWidth,
    int OriginalHeight,
    bool ExplorePivotGrid,
    string AccessibilityCaption,
    string ProductType,
    [property: JsonPropertyName("carousel_parent_id")] string CarouselParentId,
    [property: JsonPropertyName("pk")] string Pk,
    [property: JsonPropertyName("featured_products")] IReadOnlyList<object> FeaturedProducts,
    [property: JsonPropertyName("commerciality_status")] string CommercialityStatus,
    [property: JsonPropertyName("sharing_friction_info")] SharingFrictionInfo SharingFrictionInfo,
    [property: JsonPropertyName("product_suggestions")] IReadOnlyList<object> ProductSuggestions,
    [property: JsonPropertyName("video_versions")] IReadOnlyList<VideoVersion> VideoVersions,
    [property: JsonPropertyName("has_audio")] bool? HasAudio,
    [property: JsonPropertyName("video_duration")] double? VideoDuration,
    [property: JsonPropertyName("is_dash_eligible")] int? IsDashEligible,
    [property: JsonPropertyName("video_dash_manifest")] string VideoDashManifest,
    [property: JsonPropertyName("video_codec")] string VideoCodec,
    [property: JsonPropertyName("number_of_qualities")] int? NumberOfQualities
) : CoverMedia(Id, MediaType, ImageVersions, OriginalWidth, OriginalHeight, ExplorePivotGrid, AccessibilityCaption, ProductType);