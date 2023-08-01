using System.Text.Json.Serialization;

namespace InstagramApi.Data; 

public record TextContent(
    [property: JsonPropertyName("did_report_as_spam")] bool DidReportAsSpam,
    [property: JsonPropertyName("share_enabled")] bool ShareEnabled,
    [property: JsonPropertyName("user")] User User,
    [property: JsonPropertyName("is_covered")] bool IsCovered,
    [property: JsonPropertyName("is_ranked_comment")] bool IsRankedComment,
    [property: JsonPropertyName("media_id")] string MediaId,
    [property: JsonPropertyName("has_liked_comment")] bool? HasLikedComment,
    [property: JsonPropertyName("comment_like_count")] int? CommentLikeCount,
    [property: JsonPropertyName("private_reply_status")] int PrivateReplyStatus,
    [property: JsonPropertyName("pk")] string Pk,
    [property: JsonPropertyName("user_id")] string UserId,
    [property: JsonPropertyName("type")] int Type,
    [property: JsonPropertyName("text")] string Text,
    [property: JsonPropertyName("created_at")] int CreatedAt,
    [property: JsonPropertyName("created_at_utc")] int CreatedAtUtc,
    [property: JsonPropertyName("content_type")] string ContentType,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("bit_flags")] int BitFlags,
    [property: JsonPropertyName("has_translation")] bool? HasTranslation
);