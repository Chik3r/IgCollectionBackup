using System.Text.Json.Serialization;

namespace InstagramApi.Data; 

public record SharingFrictionInfo(
    [property: JsonPropertyName("should_have_sharing_friction")] bool ShouldHaveSharingFriction,
    [property: JsonPropertyName("bloks_app_url")] object BloksAppUrl,
    [property: JsonPropertyName("sharing_friction_payload")] object SharingFrictionPayload
);