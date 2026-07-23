using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<AudioLayout>))]
public sealed record AudioLayout : StringEnum<AudioLayout>
{
    private AudioLayout(string value) : base(value)
    {
    }

    public static readonly AudioLayout Ambisonic = new("ambisonic");

    public static readonly AudioLayout _51 = new("5.1");

    public static readonly AudioLayout Stereo = new("stereo");

    public static AudioLayout FromValue(string value) => FromValueCore(value);
}
