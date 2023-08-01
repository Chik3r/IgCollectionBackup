using System.Text.Json.Serialization;

namespace InstagramApi.Data; 

public record CommentInformTreatment(
    [property: JsonPropertyName("should_have_inform_treatment")] bool ShouldHaveInformTreatment,
    [property: JsonPropertyName("text")] string Text,
    [property: JsonPropertyName("url")] object Url,
    [property: JsonPropertyName("action_type")] object ActionType
);