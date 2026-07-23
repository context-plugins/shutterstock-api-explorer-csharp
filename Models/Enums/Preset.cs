using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// The file format preset
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Preset>))]
public sealed record Preset : StringEnum<Preset>
{
    private Preset(string value) : base(value)
    {
    }

    public static readonly Preset MasterMp3 = new("MASTER_MP3");

    public static readonly Preset MasterWav = new("MASTER_WAV");

    public static readonly Preset StemsWav = new("STEMS_WAV");

    public static Preset FromValue(string value) => FromValueCore(value);
}
