using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Language code
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Language>))]
public sealed record Language : StringEnum<Language>
{
    private Language(string value) : base(value)
    {
    }

    public static readonly Language Ar = new("ar");

    public static readonly Language Bg = new("bg");

    public static readonly Language Bn = new("bn");

    public static readonly Language Cs = new("cs");

    public static readonly Language Da = new("da");

    public static readonly Language De = new("de");

    public static readonly Language El = new("el");

    public static readonly Language En = new("en");

    public static readonly Language Es = new("es");

    public static readonly Language Fi = new("fi");

    public static readonly Language Fr = new("fr");

    public static readonly Language Gu = new("gu");

    public static readonly Language He = new("he");

    public static readonly Language Hi = new("hi");

    public static readonly Language Hr = new("hr");

    public static readonly Language Hu = new("hu");

    public static readonly Language Id = new("id");

    public static readonly Language It = new("it");

    public static readonly Language Ja = new("ja");

    public static readonly Language Kn = new("kn");

    public static readonly Language Ko = new("ko");

    public static readonly Language Ml = new("ml");

    public static readonly Language Mr = new("mr");

    public static readonly Language Nb = new("nb");

    public static readonly Language Nl = new("nl");

    public static readonly Language Or = new("or");

    public static readonly Language Pl = new("pl");

    public static readonly Language Pt = new("pt");

    public static readonly Language Ro = new("ro");

    public static readonly Language Ru = new("ru");

    public static readonly Language Sk = new("sk");

    public static readonly Language Sl = new("sl");

    public static readonly Language Sv = new("sv");

    public static readonly Language Ta = new("ta");

    public static readonly Language Te = new("te");

    public static readonly Language Th = new("th");

    public static readonly Language Tr = new("tr");

    public static readonly Language Uk = new("uk");

    public static readonly Language Ur = new("ur");

    public static readonly Language Vi = new("vi");

    public static readonly Language Zh = new("zh");

    public static readonly Language ZhHant = new("zh-Hant");

    public static Language FromValue(string value) => FromValueCore(value);
}
