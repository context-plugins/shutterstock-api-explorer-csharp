using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Show images with people of the specified gender
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PeopleGender>))]
public sealed record PeopleGender : StringEnum<PeopleGender>
{
    private PeopleGender(string value) : base(value)
    {
    }

    public static readonly PeopleGender Male = new("male");

    public static readonly PeopleGender Female = new("female");

    public static readonly PeopleGender Both = new("both");

    public static PeopleGender FromValue(string value) => FromValueCore(value);
}
