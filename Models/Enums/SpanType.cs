using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Type of span; metered spans represent a pariod of time with music, and unmetered spans denote the end of the prior metered span
/// </summary>
[JsonConverter(typeof(StringEnumConverter<SpanType>))]
public sealed record SpanType : StringEnum<SpanType>
{
    private SpanType(string value) : base(value)
    {
    }

    public static readonly SpanType Metered = new("metered");

    public static readonly SpanType Unmetered = new("unmetered");

    public static SpanType FromValue(string value) => FromValueCore(value);
}
