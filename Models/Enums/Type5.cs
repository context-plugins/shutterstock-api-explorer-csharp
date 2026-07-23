using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Type5>))]
public sealed record Type5 : StringEnum<Type5>
{
    private Type5(string value) : base(value)
    {
    }

    public static readonly Type5 Addition = new("addition");

    public static readonly Type5 Deletion = new("deletion");

    public static readonly Type5 Edit = new("edit");

    public static Type5 FromValue(string value) => FromValueCore(value);
}
