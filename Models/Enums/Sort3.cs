using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort3>))]
public sealed record Sort3 : StringEnum<Sort3>
{
    private Sort3(string value) : base(value)
    {
    }

    public static readonly Sort3 Score = new("score");

    public static readonly Sort3 RankingAll = new("ranking_all");

    public static readonly Sort3 Artist = new("artist");

    public static readonly Sort3 Title = new("title");

    public static readonly Sort3 Bpm = new("bpm");

    public static readonly Sort3 Freshness = new("freshness");

    public static readonly Sort3 Duration = new("duration");

    public static Sort3 FromValue(string value) => FromValueCore(value);
}
