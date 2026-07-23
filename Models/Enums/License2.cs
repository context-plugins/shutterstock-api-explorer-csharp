using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// License agreement to use for licensing
/// </summary>
[JsonConverter(typeof(StringEnumConverter<License2>))]
public sealed record License2 : StringEnum<License2>
{
    private License2(string value) : base(value)
    {
    }

    public static readonly License2 PremierEditorialVideoDigitalOnly = new("premier_editorial_video_digital_only");

    public static readonly License2 PremierEditorialVideoAllMedia = new("premier_editorial_video_all_media");

    public static readonly License2 PremierEditorialVideoAllMediaSingleTerritory = new("premier_editorial_video_all_media_single_territory");

    public static readonly License2 PremierEditorialVideoComp = new("premier_editorial_video_comp");

    public static License2 FromValue(string value) => FromValueCore(value);
}
