using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<License3>))]
public sealed record License3 : StringEnum<License3>
{
    private License3(string value) : base(value)
    {
    }

    public static readonly License3 AudioPlatform = new("audio_platform");

    public static readonly License3 PremierMusicBasic = new("premier_music_basic");

    public static readonly License3 PremierMusicExtended = new("premier_music_extended");

    public static readonly License3 PremierMusicPro = new("premier_music_pro");

    public static readonly License3 PremierMusicComp = new("premier_music_comp");

    public static readonly License3 AssetAllMusic = new("asset_all_music");

    public static License3 FromValue(string value) => FromValueCore(value);
}
