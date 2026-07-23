using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<DownloadAvailability>))]
public sealed record DownloadAvailability : StringEnum<DownloadAvailability>
{
    private DownloadAvailability(string value) : base(value)
    {
    }

    public static readonly DownloadAvailability All = new("all");

    public static readonly DownloadAvailability Downloadable = new("downloadable");

    public static readonly DownloadAvailability NonDownloadable = new("non_downloadable");

    public static DownloadAvailability FromValue(string value) => FromValueCore(value);
}
