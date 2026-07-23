using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ResponseType>))]
public sealed record ResponseType : StringEnum<ResponseType>
{
    private ResponseType(string value) : base(value)
    {
    }

    public static readonly ResponseType Code = new("code");

    public static ResponseType FromValue(string value) => FromValueCore(value);
}
