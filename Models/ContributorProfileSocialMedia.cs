using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Contributor profile social media links
/// </summary>
public record ContributorProfileSocialMedia
{
    /// <summary>
    /// Facebook link for contributor
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("facebook")]
    public string? Facebook { get; init; }

    /// <summary>
    /// Google+ link for contributor
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("google_plus")]
    public string? GooglePlus { get; init; }

    /// <summary>
    /// LinkedIn link for contributor
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("linkedin")]
    public string? Linkedin { get; init; }

    /// <summary>
    /// Pinterest page for contributor
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pinterest")]
    public string? Pinterest { get; init; }

    /// <summary>
    /// Tumblr link for contributor
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tumblr")]
    public string? Tumblr { get; init; }

    /// <summary>
    /// Twitter link for contributor
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("twitter")]
    public string? Twitter { get; init; }
}
