using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Type4>))]
public sealed record Type4 : StringEnum<Type4>
{
    private Type4(string value) : base(value)
    {
    }

    public static readonly Type4 Photo = new("photo");

    public static readonly Type4 Editorial = new("editorial");

    public static readonly Type4 Vector = new("vector");

    public static Type4 FromValue(string value) => FromValueCore(value);
}
