using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<PeopleEthnicity>))]
public sealed record PeopleEthnicity : StringEnum<PeopleEthnicity>
{
    private PeopleEthnicity(string value) : base(value)
    {
    }

    public static readonly PeopleEthnicity African = new("african");

    public static readonly PeopleEthnicity AfricanAmerican = new("african_american");

    public static readonly PeopleEthnicity Black = new("black");

    public static readonly PeopleEthnicity Brazilian = new("brazilian");

    public static readonly PeopleEthnicity Chinese = new("chinese");

    public static readonly PeopleEthnicity Caucasian = new("caucasian");

    public static readonly PeopleEthnicity EastAsian = new("east_asian");

    public static readonly PeopleEthnicity Hispanic = new("hispanic");

    public static readonly PeopleEthnicity Japanese = new("japanese");

    public static readonly PeopleEthnicity MiddleEastern = new("middle_eastern");

    public static readonly PeopleEthnicity NativeAmerican = new("native_american");

    public static readonly PeopleEthnicity PacificIslander = new("pacific_islander");

    public static readonly PeopleEthnicity SouthAsian = new("south_asian");

    public static readonly PeopleEthnicity SoutheastAsian = new("southeast_asian");

    public static readonly PeopleEthnicity Other = new("other");

    public static readonly PeopleEthnicity NotAfrican = new("NOT african");

    public static readonly PeopleEthnicity NotAfricanAmerican = new("NOT african_american");

    public static readonly PeopleEthnicity NotBlack = new("NOT black");

    public static readonly PeopleEthnicity NotBrazilian = new("NOT brazilian");

    public static readonly PeopleEthnicity NotChinese = new("NOT chinese");

    public static readonly PeopleEthnicity NotCaucasian = new("NOT caucasian");

    public static readonly PeopleEthnicity NotEastAsian = new("NOT east_asian");

    public static readonly PeopleEthnicity NotHispanic = new("NOT hispanic");

    public static readonly PeopleEthnicity NotJapanese = new("NOT japanese");

    public static readonly PeopleEthnicity NotMiddleEastern = new("NOT middle_eastern");

    public static readonly PeopleEthnicity NotNativeAmerican = new("NOT native_american");

    public static readonly PeopleEthnicity NotPacificIslander = new("NOT pacific_islander");

    public static readonly PeopleEthnicity NotSouthAsian = new("NOT south_asian");

    public static readonly PeopleEthnicity NotSoutheastAsian = new("NOT southeast_asian");

    public static readonly PeopleEthnicity NotOther = new("NOT other");

    public static PeopleEthnicity FromValue(string value) => FromValueCore(value);
}
