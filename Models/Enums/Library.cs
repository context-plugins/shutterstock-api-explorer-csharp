using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Library>))]
public sealed record Library : StringEnum<Library>
{
    private Library(string value) : base(value)
    {
    }

    public static readonly Library Shutterstock = new("shutterstock");

    public static readonly Library Premier = new("premier");

    public static Library FromValue(string value) => FromValueCore(value);
}
