using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<PeopleEthnicity1>))]
public sealed record PeopleEthnicity1 : StringEnum<PeopleEthnicity1>
{
    private PeopleEthnicity1(string value) : base(value)
    {
    }

    public static readonly PeopleEthnicity1 African = new("african");

    public static readonly PeopleEthnicity1 AfricanAmerican = new("african_american");

    public static readonly PeopleEthnicity1 Black = new("black");

    public static readonly PeopleEthnicity1 Brazilian = new("brazilian");

    public static readonly PeopleEthnicity1 Chinese = new("chinese");

    public static readonly PeopleEthnicity1 Caucasian = new("caucasian");

    public static readonly PeopleEthnicity1 EastAsian = new("east_asian");

    public static readonly PeopleEthnicity1 Hispanic = new("hispanic");

    public static readonly PeopleEthnicity1 Japanese = new("japanese");

    public static readonly PeopleEthnicity1 MiddleEastern = new("middle_eastern");

    public static readonly PeopleEthnicity1 NativeAmerican = new("native_american");

    public static readonly PeopleEthnicity1 PacificIslander = new("pacific_islander");

    public static readonly PeopleEthnicity1 SouthAsian = new("south_asian");

    public static readonly PeopleEthnicity1 SoutheastAsian = new("southeast_asian");

    public static readonly PeopleEthnicity1 Other = new("other");

    public static readonly PeopleEthnicity1 NotAfrican = new("NOT african");

    public static readonly PeopleEthnicity1 NotAfricanAmerican = new("NOT african_american");

    public static readonly PeopleEthnicity1 NotBlack = new("NOT black");

    public static readonly PeopleEthnicity1 NotBrazilian = new("NOT brazilian");

    public static readonly PeopleEthnicity1 NotChinese = new("NOT chinese");

    public static readonly PeopleEthnicity1 NotCaucasian = new("NOT caucasian");

    public static readonly PeopleEthnicity1 NotEastAsian = new("NOT east_asian");

    public static readonly PeopleEthnicity1 NotHispanic = new("NOT hispanic");

    public static readonly PeopleEthnicity1 NotJapanese = new("NOT japanese");

    public static readonly PeopleEthnicity1 NotMiddleEastern = new("NOT middle_eastern");

    public static readonly PeopleEthnicity1 NotNativeAmerican = new("NOT native_american");

    public static readonly PeopleEthnicity1 NotPacificIslander = new("NOT pacific_islander");

    public static readonly PeopleEthnicity1 NotSouthAsian = new("NOT south_asian");

    public static readonly PeopleEthnicity1 NotSoutheastAsian = new("NOT southeast_asian");

    public static readonly PeopleEthnicity1 NotOther = new("NOT other");

    public static PeopleEthnicity1 FromValue(string value) => FromValueCore(value);
}
