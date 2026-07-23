using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// A coarse progress indicator
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status>))]
public sealed record Status : StringEnum<Status>
{
    private Status(string value) : base(value)
    {
    }

    public static readonly Status WaitingCompose = new("WAITING_COMPOSE");

    public static readonly Status RunningCompose = new("RUNNING_COMPOSE");

    public static readonly Status WaitingRender = new("WAITING_RENDER");

    public static readonly Status RunningRender = new("RUNNING_RENDER");

    public static readonly Status Created = new("CREATED");

    public static readonly Status FailedCreate = new("FAILED_CREATE");

    public static Status FromValue(string value) => FromValueCore(value);
}
