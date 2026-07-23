using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Files associated with the render
/// </summary>
public record AudioRendersFilesList
{
    /// <summary>
    /// The bit depth of the audio files in bits/sample
    /// </summary>
    [JsonPropertyName("bits_sample")]
    public required double BitsSample { get; init; }

    /// <summary>
    /// The content-type of the file
    /// </summary>
    [JsonPropertyName("content_type")]
    public required string ContentType { get; init; }

    /// <summary>
    /// The internet-accessible URL from which the file can be downloaded. Any redirects encountered when using this URL must be followed
    /// </summary>
    [JsonPropertyName("download_url")]
    public required string DownloadUrl { get; init; }

    /// <summary>
    /// The user-specified file name suggestion from the render request; this file name becomes the filename property of the Content-Disposition header when the user downloads the rendered audio file
    /// </summary>
    [JsonPropertyName("filename")]
    public required string Filename { get; init; }

    /// <summary>
    /// The Sample rate of the audio files in Hertz (Hz)
    /// </summary>
    [JsonPropertyName("frequency_hz")]
    public required double FrequencyHz { get; init; }

    /// <summary>
    /// The data rate of the audio files in kilobits/second
    /// </summary>
    [JsonPropertyName("kbits_second")]
    public required double KbitsSecond { get; init; }

    /// <summary>
    /// Size of the file in bytes
    /// </summary>
    [JsonPropertyName("size_bytes")]
    public required double SizeBytes { get; init; }

    /// <summary>
    /// An array of track names included in the file
    /// </summary>
    [JsonPropertyName("tracks")]
    public required IReadOnlyList<string> Tracks { get; init; }
}
