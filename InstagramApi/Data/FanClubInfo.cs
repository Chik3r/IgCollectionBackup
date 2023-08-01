using System.Text.Json.Serialization;

namespace InstagramApi.Data; 

public record FanClubInfo(
    [property: JsonPropertyName("fan_club_id")] object FanClubId,
    [property: JsonPropertyName("fan_club_name")] object FanClubName,
    [property: JsonPropertyName("is_fan_club_referral_eligible")] object IsFanClubReferralEligible,
    [property: JsonPropertyName("fan_consideration_page_revamp_eligiblity")] object FanConsiderationPageRevampEligiblity,
    [property: JsonPropertyName("is_fan_club_gifting_eligible")] object IsFanClubGiftingEligible,
    [property: JsonPropertyName("subscriber_count")] object SubscriberCount,
    [property: JsonPropertyName("connected_member_count")] object ConnectedMemberCount,
    [property: JsonPropertyName("autosave_to_exclusive_highlight")] object AutosaveToExclusiveHighlight,
    [property: JsonPropertyName("has_enough_subscribers_for_ssc")] object HasEnoughSubscribersForSsc
);