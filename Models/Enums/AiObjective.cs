using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<AiObjective>))]
public sealed record AiObjective : StringEnum<AiObjective>
{
    private AiObjective(string value) : base(value)
    {
    }

    public static readonly AiObjective Awareness = new("awareness");

    public static readonly AiObjective Traffic = new("traffic");

    public static readonly AiObjective Conversions = new("conversions");

    public static AiObjective FromValue(string value) => FromValueCore(value);
}
