using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Format3>))]
public sealed record Format3 : StringEnum<Format3>
{
    private Format3(string value) : base(value)
    {
    }

    public static readonly Format3 Wav = new("wav");

    public static readonly Format3 Mp3 = new("mp3");

    public static Format3 FromValue(string value) => FromValueCore(value);
}
