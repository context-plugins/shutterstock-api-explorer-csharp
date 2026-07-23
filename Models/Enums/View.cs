using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Amount of detail to render in the response
/// </summary>
[JsonConverter(typeof(StringEnumConverter<View>))]
public sealed record View : StringEnum<View>
{
    private View(string value) : base(value)
    {
    }

    public static readonly View Minimal = new("minimal");

    public static readonly View Full = new("full");

    public static View FromValue(string value) => FromValueCore(value);
}
