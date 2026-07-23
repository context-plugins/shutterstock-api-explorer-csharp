using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// File format, such as MP3 file, combined WAV file, or individual track WAV files
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Preset1>))]
public sealed record Preset1 : StringEnum<Preset1>
{
    private Preset1(string value) : base(value)
    {
    }

    public static readonly Preset1 MasterMp3 = new("MASTER_MP3");

    public static readonly Preset1 MasterWav = new("MASTER_WAV");

    public static readonly Preset1 StemsWav = new("STEMS_WAV");

    public static Preset1 FromValue(string value) => FromValueCore(value);
}
