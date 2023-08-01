using System.Text.Json.Serialization;

namespace InstagramApi.Data; 

public record User(
    [property: JsonPropertyName("has_anonymous_profile_picture")] bool HasAnonymousProfilePicture,
    [property: JsonPropertyName("fan_club_info")] FanClubInfo FanClubInfo,
    [property: JsonPropertyName("fbid_v2")] string FbidV2,
    [property: JsonPropertyName("transparency_product_enabled")] bool TransparencyProductEnabled,
    [property: JsonPropertyName("hd_profile_pic_url_info")] ImageInfo HdProfilePicUrlInfo,
    [property: JsonPropertyName("hd_profile_pic_versions")] IReadOnlyList<ImageInfo> HdProfilePicVersions,
    [property: JsonPropertyName("is_favorite")] bool IsFavorite,
    [property: JsonPropertyName("is_unpublished")] bool IsUnpublished,
    [property: JsonPropertyName("pk")] string Pk,
    [property: JsonPropertyName("pk_id")] string PkId,
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("full_name")] string FullName,
    [property: JsonPropertyName("is_private")] bool IsPrivate,
    [property: JsonPropertyName("is_verified")] bool IsVerified,
    [property: JsonPropertyName("friendship_status")] FriendshipStatus FriendshipStatus,
    [property: JsonPropertyName("profile_pic_id")] string ProfilePicId,
    [property: JsonPropertyName("profile_pic_url")] string ProfilePicUrl,
    [property: JsonPropertyName("account_badges")] IReadOnlyList<object> AccountBadges,
    [property: JsonPropertyName("feed_post_reshare_disabled")] bool FeedPostReshareDisabled,
    [property: JsonPropertyName("show_account_transparency_details")] bool ShowAccountTransparencyDetails,
    [property: JsonPropertyName("third_party_downloads_enabled")] int ThirdPartyDownloadsEnabled,
    [property: JsonPropertyName("latest_reel_media")] int LatestReelMedia,
    [property: JsonPropertyName("text_post_app_joiner_number")] int? TextPostAppJoinerNumber
);