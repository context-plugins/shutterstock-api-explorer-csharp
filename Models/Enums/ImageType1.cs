using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ImageType1>))]
public sealed record ImageType1 : StringEnum<ImageType1>
{
    private ImageType1(string value) : base(value)
    {
    }

    public static readonly ImageType1 Photo = new("photo");

    public static readonly ImageType1 Illustration = new("illustration");

    public static readonly ImageType1 Vector = new("vector");

    public static ImageType1 FromValue(string value) => FromValueCore(value);
}
