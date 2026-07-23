using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<AiIndustry>))]
public sealed record AiIndustry : StringEnum<AiIndustry>
{
    private AiIndustry(string value) : base(value)
    {
    }

    public static readonly AiIndustry Automotive = new("automotive");

    public static readonly AiIndustry Cpg = new("cpg");

    public static readonly AiIndustry Finance = new("finance");

    public static readonly AiIndustry Healthcare = new("healthcare");

    public static readonly AiIndustry Retail = new("retail");

    public static readonly AiIndustry Technology = new("technology");

    public static AiIndustry FromValue(string value) => FromValueCore(value);
}
