using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<PeopleAge1>))]
public sealed record PeopleAge1 : StringEnum<PeopleAge1>
{
    private PeopleAge1(string value) : base(value)
    {
    }

    public static readonly PeopleAge1 Infants = new("infants");

    public static readonly PeopleAge1 Children = new("children");

    public static readonly PeopleAge1 Teenagers = new("teenagers");

    public static readonly PeopleAge1 _20S = new("20s");

    public static readonly PeopleAge1 _30S = new("30s");

    public static readonly PeopleAge1 _40S = new("40s");

    public static readonly PeopleAge1 _50S = new("50s");

    public static readonly PeopleAge1 _60S = new("60s");

    public static readonly PeopleAge1 Older = new("older");

    public static PeopleAge1 FromValue(string value) => FromValueCore(value);
}
