using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Type of license
/// </summary>
[JsonConverter(typeof(StringEnumConverter<License1>))]
public sealed record License1 : StringEnum<License1>
{
    private License1(string value) : base(value)
    {
    }

    public static readonly License1 AudioPlatform = new("audio_platform");

    public static readonly License1 PremierMusicBasic = new("premier_music_basic");

    public static readonly License1 PremierMusicExtended = new("premier_music_extended");

    public static readonly License1 PremierMusicPro = new("premier_music_pro");

    public static readonly License1 PremierMusicComp = new("premier_music_comp");

    public static readonly License1 AssetAllMusic = new("asset_all_music");

    public static License1 FromValue(string value) => FromValueCore(value);
}
