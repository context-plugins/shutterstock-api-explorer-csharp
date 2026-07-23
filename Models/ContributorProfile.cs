using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Contributor profile data
/// </summary>
public record ContributorProfile
{
    /// <summary>
    /// Short description of the contributors' library
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("about")]
    public string? About { get; init; }

    /// <summary>
    /// Type of content that the contributor specializes in (photographer, illustrator, etc)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("contributor_type")]
    public IReadOnlyList<string>? ContributorType { get; init; }

    /// <summary>
    /// Preferred name to be displayed for the contributor
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    /// <summary>
    /// List of equipment used by the contributor (Canon EOS 5D Mark II, etc)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("equipment")]
    public IReadOnlyList<string>? Equipment { get; init; }

    /// <summary>
    /// Contributor ID
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// Country code representing the contributor's locale
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("location")]
    public string? Location { get; init; }

    /// <summary>
    /// Web URL for the contributors' profile
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("portfolio_url")]
    public string? PortfolioUrl { get; init; }

    /// <summary>
    /// Contributor profile social media links
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("social_media")]
    public ContributorProfileSocialMedia? SocialMedia { get; init; }

    /// <summary>
    /// List of styles that the contributor specializes in (lifestyle, mixed media, etc)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("styles")]
    public IReadOnlyList<string>? Styles { get; init; }

    /// <summary>
    /// Generic list of subjects for contributors' work (food_and_drink, holiday, people, etc)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subjects")]
    public IReadOnlyList<string>? Subjects { get; init; }

    /// <summary>
    /// Personal website for the contributor
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("website")]
    public string? Website { get; init; }
}
