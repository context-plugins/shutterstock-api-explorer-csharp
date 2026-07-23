using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Validation.Attributes;
using ShutterstockApiExplorer.Models.AnyOf;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Data required to search for an image
/// </summary>
public record SearchImage
{
    /// <summary>
    /// Show images added on the specified date
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("added_date")]
    public DateTimeOffset? AddedDate { get; init; }

    /// <summary>
    /// Show images added before the specified date
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("added_date_end")]
    public DateTimeOffset? AddedDateEnd { get; init; }

    /// <summary>
    /// Show images added on or after the specified date
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("added_date_start")]
    public DateTimeOffset? AddedDateStart { get; init; }

    /// <summary>
    /// Show images with the specified aspect ratio, using a positive decimal of the width divided by the height, such as 1.7778 for a 16:9 image
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("aspect_ratio")]
    public double? AspectRatio { get; init; }

    /// <summary>
    /// Show images with the specified aspect ratio or lower, using a positive decimal of the width divided by the height, such as 1.7778 for a 16:9 image
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("aspect_ratio_max")]
    [Minimum(0.0)]
    public double? AspectRatioMax { get; init; }

    /// <summary>
    /// Show images with the specified aspect ratio or higher, using a positive decimal of the width divided by the height, such as 1.7778 for a 16:9 image
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("aspect_ratio_min")]
    [Minimum(0.0)]
    public double? AspectRatioMin { get; init; }

    /// <summary>
    /// Show only authentic images
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("authentic")]
    public bool? Authentic { get; init; }

    /// <summary>
    /// Show images with the specified Shutterstock-defined category; specify a category name or ID
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("category")]
    public string? Category { get; init; }

    /// <summary>
    /// Specify either a hexadecimal color in the format '4F21EA' or 'grayscale'; the API returns images that use similar colors
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("color")]
    public string? Color { get; init; }

    /// <summary>
    /// Show images with the specified contributor names or IDs, allows multiple
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("contributor")]
    public IReadOnlyList<string>? Contributor { get; init; }

    /// <summary>
    /// Show images from contributors in one or more specified countries, or start with NOT to exclude a country from the search
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("contributor_country")]
    public ContributorCountry? ContributorCountry { get; init; }

    /// <summary>
    /// Fields to display in the response; see the documentation for the fields parameter in the overview section
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fields")]
    public string? Fields { get; init; }

    /// <summary>
    /// (Deprecated; use height_from and height_to instead) Show images with the specified height
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("height")]
    public int? Height { get; init; }

    /// <summary>
    /// Show images with the specified height or larger, in pixels
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("height_from")]
    public int? HeightFrom { get; init; }

    /// <summary>
    /// Show images with the specified height or smaller, in pixels
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("height_to")]
    public int? HeightTo { get; init; }

    /// <summary>
    /// Show images of the specified type
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("image_type")]
    public IReadOnlyList<ImageType>? ImageType { get; init; }

    /// <summary>
    /// Hide results with potentially unsafe keywords
    /// </summary>
    [JsonPropertyName("keyword_safe_search")]
    public bool? KeywordSafeSearch { get; init; } = true;

    /// <summary>
    /// Language code
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("language")]
    public Language? Language { get; init; }

    /// <summary>
    /// Show only images with the specified license
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("license")]
    public IReadOnlyList<License>? License { get; init; }

    /// <summary>
    /// Show image results with the specified model IDs
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("model")]
    public IReadOnlyList<string>? Model { get; init; }

    /// <summary>
    /// Show image results with horizontal or vertical orientation
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("orientation")]
    public Orientation? Orientation { get; init; }

    /// <summary>
    /// Page number
    /// </summary>
    [JsonPropertyName("page")]
    [Minimum(1)]
    public int? Page { get; init; } = 1;

    /// <summary>
    /// Show images that feature people of the specified age category
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("people_age")]
    public PeopleAge? PeopleAge { get; init; }

    /// <summary>
    /// Show images with people of the specified ethnicities, or start with NOT to show images without those ethnicities
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("people_ethnicity")]
    public IReadOnlyList<PeopleEthnicity>? PeopleEthnicity { get; init; }

    /// <summary>
    /// Show images with people of the specified gender
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("people_gender")]
    public PeopleGender? PeopleGender { get; init; }

    /// <summary>
    /// Show images of people with a signed model release
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("people_model_released")]
    public bool? PeopleModelReleased { get; init; }

    /// <summary>
    /// Show images with the specified number of people
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("people_number")]
    [Minimum(0)]
    [Maximum(4)]
    public int? PeopleNumber { get; init; }

    /// <summary>
    /// Number of results per page
    /// </summary>
    [JsonPropertyName("per_page")]
    [Minimum(0)]
    [Maximum(20)]
    public int? PerPage { get; init; } = 20;

    /// <summary>
    /// One or more search terms separated by spaces; you can use NOT to filter out images that match a term
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("query")]
    public string? Query { get; init; }

    /// <summary>
    /// Raise or lower search result rankings based on the result's relevance to a specified region; you can provide a country code or an IP address from which the API infers a country
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("region")]
    public Region1? Region { get; init; }

    /// <summary>
    /// Enable or disable safe search
    /// </summary>
    [JsonPropertyName("safe")]
    public bool? Safe { get; init; } = true;

    /// <summary>
    /// Sort by
    /// </summary>
    [JsonPropertyName("sort")]
    public Sort? Sort { get; init; } = Sort.Popular;

    /// <summary>
    /// Spellcheck the search query and return results on suggested spellings
    /// </summary>
    [JsonPropertyName("spellcheck_query")]
    public bool? SpellcheckQuery { get; init; } = true;

    /// <summary>
    /// Amount of detail to render in the response
    /// </summary>
    [JsonPropertyName("view")]
    public View? View { get; init; } = View.Minimal;

    /// <summary>
    /// (Deprecated; use width_from and width_to instead) Show images with the specified width
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("width")]
    public int? Width { get; init; }

    /// <summary>
    /// Show images with the specified width or larger, in pixels
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("width_from")]
    public int? WidthFrom { get; init; }

    /// <summary>
    /// Show images with the specified width or smaller, in pixels
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("width_to")]
    public int? WidthTo { get; init; }
}
