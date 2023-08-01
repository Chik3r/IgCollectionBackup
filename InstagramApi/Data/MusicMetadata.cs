using System.Text.Json.Serialization;

namespace InstagramApi.Data; 

public record MusicMetadata(
    [property: JsonPropertyName("music_canonical_id")] string MusicCanonicalId,
    [property: JsonPropertyName("audio_type")] object AudioType,
    [property: JsonPropertyName("music_info")] object MusicInfo,
    [property: JsonPropertyName("original_sound_info")] object OriginalSoundInfo,
    [property: JsonPropertyName("pinned_media_ids")] object PinnedMediaIds
);