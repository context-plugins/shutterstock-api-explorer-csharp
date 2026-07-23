using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Library1>))]
public sealed record Library1 : StringEnum<Library1>
{
    private Library1(string value) : base(value)
    {
    }

    public static readonly Library1 Shutterstock = new("shutterstock");

    public static readonly Library1 Premier = new("premier");

    public static readonly Library1 Premiumbeat = new("premiumbeat");

    public static Library1 FromValue(string value) => FromValueCore(value);
}
