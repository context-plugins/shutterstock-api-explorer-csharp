using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// The specific action to perform; if the event type is "ending" then this must be "ringout" and if event type is "transition" this must be "cut"
/// </summary>
[JsonConverter(typeof(StringEnumConverter<TypeModel>))]
public sealed record TypeModel : StringEnum<TypeModel>
{
    private TypeModel(string value) : base(value)
    {
    }

    public static readonly TypeModel Ringout = new("ringout");

    public static readonly TypeModel Cut = new("cut");

    public static TypeModel FromValue(string value) => FromValueCore(value);
}
