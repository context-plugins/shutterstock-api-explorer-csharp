using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ImageType>))]
public sealed record ImageType : StringEnum<ImageType>
{
    private ImageType(string value) : base(value)
    {
    }

    public static readonly ImageType Photo = new("photo");

    public static readonly ImageType Illustration = new("illustration");

    public static readonly ImageType Vector = new("vector");

    public static ImageType FromValue(string value) => FromValueCore(value);
}
