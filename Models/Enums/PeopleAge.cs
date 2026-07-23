using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Show images that feature people of the specified age category
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PeopleAge>))]
public sealed record PeopleAge : StringEnum<PeopleAge>
{
    private PeopleAge(string value) : base(value)
    {
    }

    public static readonly PeopleAge Infants = new("infants");

    public static readonly PeopleAge Children = new("children");

    public static readonly PeopleAge Teenagers = new("teenagers");

    public static readonly PeopleAge _20S = new("20s");

    public static readonly PeopleAge _30S = new("30s");

    public static readonly PeopleAge _40S = new("40s");

    public static readonly PeopleAge _50S = new("50s");

    public static readonly PeopleAge _60S = new("60s");

    public static readonly PeopleAge Older = new("older");

    public static PeopleAge FromValue(string value) => FromValueCore(value);
}
