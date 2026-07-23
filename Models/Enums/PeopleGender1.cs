using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<PeopleGender1>))]
public sealed record PeopleGender1 : StringEnum<PeopleGender1>
{
    private PeopleGender1(string value) : base(value)
    {
    }

    public static readonly PeopleGender1 Male = new("male");

    public static readonly PeopleGender1 Female = new("female");

    public static readonly PeopleGender1 Both = new("both");

    public static PeopleGender1 FromValue(string value) => FromValueCore(value);
}
