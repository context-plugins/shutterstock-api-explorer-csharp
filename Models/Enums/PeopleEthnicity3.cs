using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<PeopleEthnicity3>))]
public sealed record PeopleEthnicity3 : StringEnum<PeopleEthnicity3>
{
    private PeopleEthnicity3(string value) : base(value)
    {
    }

    public static readonly PeopleEthnicity3 African = new("african");

    public static readonly PeopleEthnicity3 AfricanAmerican = new("african_american");

    public static readonly PeopleEthnicity3 Black = new("black");

    public static readonly PeopleEthnicity3 Brazilian = new("brazilian");

    public static readonly PeopleEthnicity3 Chinese = new("chinese");

    public static readonly PeopleEthnicity3 Caucasian = new("caucasian");

    public static readonly PeopleEthnicity3 EastAsian = new("east_asian");

    public static readonly PeopleEthnicity3 Hispanic = new("hispanic");

    public static readonly PeopleEthnicity3 Japanese = new("japanese");

    public static readonly PeopleEthnicity3 MiddleEastern = new("middle_eastern");

    public static readonly PeopleEthnicity3 NativeAmerican = new("native_american");

    public static readonly PeopleEthnicity3 PacificIslander = new("pacific_islander");

    public static readonly PeopleEthnicity3 SouthAsian = new("south_asian");

    public static readonly PeopleEthnicity3 SoutheastAsian = new("southeast_asian");

    public static readonly PeopleEthnicity3 Other = new("other");

    public static PeopleEthnicity3 FromValue(string value) => FromValueCore(value);
}
