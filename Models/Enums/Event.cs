using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// The type of event
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Event>))]
public sealed record Event : StringEnum<Event>
{
    private Event(string value) : base(value)
    {
    }

    public static readonly Event Ending = new("ending");

    public static readonly Event Transition = new("transition");

    public static Event FromValue(string value) => FromValueCore(value);
}
