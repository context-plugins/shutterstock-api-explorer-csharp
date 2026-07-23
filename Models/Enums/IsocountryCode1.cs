using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<IsocountryCode1>))]
public sealed record IsocountryCode1 : StringEnum<IsocountryCode1>
{
    private IsocountryCode1(string value) : base(value)
    {
    }

    public static readonly IsocountryCode1 Af = new("AF");

    public static readonly IsocountryCode1 Ax = new("AX");

    public static readonly IsocountryCode1 Al = new("AL");

    public static readonly IsocountryCode1 Dz = new("DZ");

    public static readonly IsocountryCode1 As = new("AS");

    public static readonly IsocountryCode1 Ad = new("AD");

    public static readonly IsocountryCode1 Ao = new("AO");

    public static readonly IsocountryCode1 Ai = new("AI");

    public static readonly IsocountryCode1 Aq = new("AQ");

    public static readonly IsocountryCode1 Ag = new("AG");

    public static readonly IsocountryCode1 Ar = new("AR");

    public static readonly IsocountryCode1 Am = new("AM");

    public static readonly IsocountryCode1 Aw = new("AW");

    public static readonly IsocountryCode1 Au = new("AU");

    public static readonly IsocountryCode1 At = new("AT");

    public static readonly IsocountryCode1 Az = new("AZ");

    public static readonly IsocountryCode1 Bs = new("BS");

    public static readonly IsocountryCode1 Bh = new("BH");

    public static readonly IsocountryCode1 Bd = new("BD");

    public static readonly IsocountryCode1 Bb = new("BB");

    public static readonly IsocountryCode1 By = new("BY");

    public static readonly IsocountryCode1 Be = new("BE");

    public static readonly IsocountryCode1 Bz = new("BZ");

    public static readonly IsocountryCode1 Bj = new("BJ");

    public static readonly IsocountryCode1 Bm = new("BM");

    public static readonly IsocountryCode1 Bt = new("BT");

    public static readonly IsocountryCode1 Bo = new("BO");

    public static readonly IsocountryCode1 Ba = new("BA");

    public static readonly IsocountryCode1 Bw = new("BW");

    public static readonly IsocountryCode1 Bv = new("BV");

    public static readonly IsocountryCode1 Br = new("BR");

    public static readonly IsocountryCode1 Io = new("IO");

    public static readonly IsocountryCode1 Bn = new("BN");

    public static readonly IsocountryCode1 Bg = new("BG");

    public static readonly IsocountryCode1 Bf = new("BF");

    public static readonly IsocountryCode1 Bi = new("BI");

    public static readonly IsocountryCode1 Kh = new("KH");

    public static readonly IsocountryCode1 Cm = new("CM");

    public static readonly IsocountryCode1 Ca = new("CA");

    public static readonly IsocountryCode1 Cv = new("CV");

    public static readonly IsocountryCode1 Ky = new("KY");

    public static readonly IsocountryCode1 Cf = new("CF");

    public static readonly IsocountryCode1 Td = new("TD");

    public static readonly IsocountryCode1 Cl = new("CL");

    public static readonly IsocountryCode1 Cn = new("CN");

    public static readonly IsocountryCode1 Cx = new("CX");

    public static readonly IsocountryCode1 Cc = new("CC");

    public static readonly IsocountryCode1 Co = new("CO");

    public static readonly IsocountryCode1 Km = new("KM");

    public static readonly IsocountryCode1 Cg = new("CG");

    public static readonly IsocountryCode1 Cd = new("CD");

    public static readonly IsocountryCode1 Ck = new("CK");

    public static readonly IsocountryCode1 Cr = new("CR");

    public static readonly IsocountryCode1 Ci = new("CI");

    public static readonly IsocountryCode1 Hr = new("HR");

    public static readonly IsocountryCode1 Cu = new("CU");

    public static readonly IsocountryCode1 Cy = new("CY");

    public static readonly IsocountryCode1 Cz = new("CZ");

    public static readonly IsocountryCode1 Dk = new("DK");

    public static readonly IsocountryCode1 Dj = new("DJ");

    public static readonly IsocountryCode1 Dm = new("DM");

    public static readonly IsocountryCode1 Do = new("DO");

    public static readonly IsocountryCode1 Ec = new("EC");

    public static readonly IsocountryCode1 Eg = new("EG");

    public static readonly IsocountryCode1 Sv = new("SV");

    public static readonly IsocountryCode1 Gq = new("GQ");

    public static readonly IsocountryCode1 Er = new("ER");

    public static readonly IsocountryCode1 Ee = new("EE");

    public static readonly IsocountryCode1 Et = new("ET");

    public static readonly IsocountryCode1 Fk = new("FK");

    public static readonly IsocountryCode1 Fo = new("FO");

    public static readonly IsocountryCode1 Fj = new("FJ");

    public static readonly IsocountryCode1 Fi = new("FI");

    public static readonly IsocountryCode1 Fr = new("FR");

    public static readonly IsocountryCode1 Gf = new("GF");

    public static readonly IsocountryCode1 Pf = new("PF");

    public static readonly IsocountryCode1 Tf = new("TF");

    public static readonly IsocountryCode1 Ga = new("GA");

    public static readonly IsocountryCode1 Gm = new("GM");

    public static readonly IsocountryCode1 Ge = new("GE");

    public static readonly IsocountryCode1 De = new("DE");

    public static readonly IsocountryCode1 Gh = new("GH");

    public static readonly IsocountryCode1 Gi = new("GI");

    public static readonly IsocountryCode1 Gr = new("GR");

    public static readonly IsocountryCode1 Gl = new("GL");

    public static readonly IsocountryCode1 Gd = new("GD");

    public static readonly IsocountryCode1 Gp = new("GP");

    public static readonly IsocountryCode1 Gu = new("GU");

    public static readonly IsocountryCode1 Gt = new("GT");

    public static readonly IsocountryCode1 Gg = new("GG");

    public static readonly IsocountryCode1 Gn = new("GN");

    public static readonly IsocountryCode1 Gw = new("GW");

    public static readonly IsocountryCode1 Gy = new("GY");

    public static readonly IsocountryCode1 Ht = new("HT");

    public static readonly IsocountryCode1 Hm = new("HM");

    public static readonly IsocountryCode1 Va = new("VA");

    public static readonly IsocountryCode1 Hn = new("HN");

    public static readonly IsocountryCode1 Hk = new("HK");

    public static readonly IsocountryCode1 Hu = new("HU");

    public static readonly IsocountryCode1 Is = new("IS");

    public static readonly IsocountryCode1 In = new("IN");

    public static readonly IsocountryCode1 Id = new("ID");

    public static readonly IsocountryCode1 Ir = new("IR");

    public static readonly IsocountryCode1 Iq = new("IQ");

    public static readonly IsocountryCode1 Ie = new("IE");

    public static readonly IsocountryCode1 Im = new("IM");

    public static readonly IsocountryCode1 Il = new("IL");

    public static readonly IsocountryCode1 It = new("IT");

    public static readonly IsocountryCode1 Jm = new("JM");

    public static readonly IsocountryCode1 Jp = new("JP");

    public static readonly IsocountryCode1 Je = new("JE");

    public static readonly IsocountryCode1 Jo = new("JO");

    public static readonly IsocountryCode1 Kz = new("KZ");

    public static readonly IsocountryCode1 Ke = new("KE");

    public static readonly IsocountryCode1 Ki = new("KI");

    public static readonly IsocountryCode1 Kr = new("KR");

    public static readonly IsocountryCode1 Kw = new("KW");

    public static readonly IsocountryCode1 Kg = new("KG");

    public static readonly IsocountryCode1 La = new("LA");

    public static readonly IsocountryCode1 Lv = new("LV");

    public static readonly IsocountryCode1 Lb = new("LB");

    public static readonly IsocountryCode1 Ls = new("LS");

    public static readonly IsocountryCode1 Lr = new("LR");

    public static readonly IsocountryCode1 Ly = new("LY");

    public static readonly IsocountryCode1 Li = new("LI");

    public static readonly IsocountryCode1 Lt = new("LT");

    public static readonly IsocountryCode1 Lu = new("LU");

    public static readonly IsocountryCode1 Mo = new("MO");

    public static readonly IsocountryCode1 Mk = new("MK");

    public static readonly IsocountryCode1 Mg = new("MG");

    public static readonly IsocountryCode1 Mw = new("MW");

    public static readonly IsocountryCode1 My = new("MY");

    public static readonly IsocountryCode1 Mv = new("MV");

    public static readonly IsocountryCode1 Ml = new("ML");

    public static readonly IsocountryCode1 Mt = new("MT");

    public static readonly IsocountryCode1 Mh = new("MH");

    public static readonly IsocountryCode1 Mq = new("MQ");

    public static readonly IsocountryCode1 Mr = new("MR");

    public static readonly IsocountryCode1 Mu = new("MU");

    public static readonly IsocountryCode1 Yt = new("YT");

    public static readonly IsocountryCode1 Mx = new("MX");

    public static readonly IsocountryCode1 Fm = new("FM");

    public static readonly IsocountryCode1 Md = new("MD");

    public static readonly IsocountryCode1 Mc = new("MC");

    public static readonly IsocountryCode1 Mn = new("MN");

    public static readonly IsocountryCode1 Me = new("ME");

    public static readonly IsocountryCode1 Ms = new("MS");

    public static readonly IsocountryCode1 Ma = new("MA");

    public static readonly IsocountryCode1 Mz = new("MZ");

    public static readonly IsocountryCode1 Mm = new("MM");

    public static readonly IsocountryCode1 Na = new("NA");

    public static readonly IsocountryCode1 Nr = new("NR");

    public static readonly IsocountryCode1 Np = new("NP");

    public static readonly IsocountryCode1 Nl = new("NL");

    public static readonly IsocountryCode1 An = new("AN");

    public static readonly IsocountryCode1 Nc = new("NC");

    public static readonly IsocountryCode1 Nz = new("NZ");

    public static readonly IsocountryCode1 Ni = new("NI");

    public static readonly IsocountryCode1 Ne = new("NE");

    public static readonly IsocountryCode1 Ng = new("NG");

    public static readonly IsocountryCode1 Nu = new("NU");

    public static readonly IsocountryCode1 Nf = new("NF");

    public static readonly IsocountryCode1 Mp = new("MP");

    public static readonly IsocountryCode1 No = new("NO");

    public static readonly IsocountryCode1 Om = new("OM");

    public static readonly IsocountryCode1 Pk = new("PK");

    public static readonly IsocountryCode1 Pw = new("PW");

    public static readonly IsocountryCode1 Ps = new("PS");

    public static readonly IsocountryCode1 Pa = new("PA");

    public static readonly IsocountryCode1 Pg = new("PG");

    public static readonly IsocountryCode1 Py = new("PY");

    public static readonly IsocountryCode1 Pe = new("PE");

    public static readonly IsocountryCode1 Ph = new("PH");

    public static readonly IsocountryCode1 Pn = new("PN");

    public static readonly IsocountryCode1 Pl = new("PL");

    public static readonly IsocountryCode1 Pt = new("PT");

    public static readonly IsocountryCode1 Pr = new("PR");

    public static readonly IsocountryCode1 Qa = new("QA");

    public static readonly IsocountryCode1 Re = new("RE");

    public static readonly IsocountryCode1 Ro = new("RO");

    public static readonly IsocountryCode1 Ru = new("RU");

    public static readonly IsocountryCode1 Rw = new("RW");

    public static readonly IsocountryCode1 Bl = new("BL");

    public static readonly IsocountryCode1 Sh = new("SH");

    public static readonly IsocountryCode1 Kn = new("KN");

    public static readonly IsocountryCode1 Lc = new("LC");

    public static readonly IsocountryCode1 Mf = new("MF");

    public static readonly IsocountryCode1 Pm = new("PM");

    public static readonly IsocountryCode1 Vc = new("VC");

    public static readonly IsocountryCode1 Ws = new("WS");

    public static readonly IsocountryCode1 Sm = new("SM");

    public static readonly IsocountryCode1 St = new("ST");

    public static readonly IsocountryCode1 Sa = new("SA");

    public static readonly IsocountryCode1 Sn = new("SN");

    public static readonly IsocountryCode1 Rs = new("RS");

    public static readonly IsocountryCode1 Sc = new("SC");

    public static readonly IsocountryCode1 Sl = new("SL");

    public static readonly IsocountryCode1 Sg = new("SG");

    public static readonly IsocountryCode1 Sk = new("SK");

    public static readonly IsocountryCode1 Si = new("SI");

    public static readonly IsocountryCode1 Sb = new("SB");

    public static readonly IsocountryCode1 So = new("SO");

    public static readonly IsocountryCode1 Za = new("ZA");

    public static readonly IsocountryCode1 Gs = new("GS");

    public static readonly IsocountryCode1 Es = new("ES");

    public static readonly IsocountryCode1 Lk = new("LK");

    public static readonly IsocountryCode1 Sd = new("SD");

    public static readonly IsocountryCode1 Sr = new("SR");

    public static readonly IsocountryCode1 Sj = new("SJ");

    public static readonly IsocountryCode1 Sz = new("SZ");

    public static readonly IsocountryCode1 Se = new("SE");

    public static readonly IsocountryCode1 Ch = new("CH");

    public static readonly IsocountryCode1 Sy = new("SY");

    public static readonly IsocountryCode1 Tw = new("TW");

    public static readonly IsocountryCode1 Tj = new("TJ");

    public static readonly IsocountryCode1 Tz = new("TZ");

    public static readonly IsocountryCode1 Th = new("TH");

    public static readonly IsocountryCode1 Tl = new("TL");

    public static readonly IsocountryCode1 Tg = new("TG");

    public static readonly IsocountryCode1 Tk = new("TK");

    public static readonly IsocountryCode1 To = new("TO");

    public static readonly IsocountryCode1 Tt = new("TT");

    public static readonly IsocountryCode1 Tn = new("TN");

    public static readonly IsocountryCode1 Tr = new("TR");

    public static readonly IsocountryCode1 Tm = new("TM");

    public static readonly IsocountryCode1 Tc = new("TC");

    public static readonly IsocountryCode1 Tv = new("TV");

    public static readonly IsocountryCode1 Ug = new("UG");

    public static readonly IsocountryCode1 Ua = new("UA");

    public static readonly IsocountryCode1 Ae = new("AE");

    public static readonly IsocountryCode1 Gb = new("GB");

    public static readonly IsocountryCode1 Us = new("US");

    public static readonly IsocountryCode1 Um = new("UM");

    public static readonly IsocountryCode1 Uy = new("UY");

    public static readonly IsocountryCode1 Uz = new("UZ");

    public static readonly IsocountryCode1 Vu = new("VU");

    public static readonly IsocountryCode1 Ve = new("VE");

    public static readonly IsocountryCode1 Vn = new("VN");

    public static readonly IsocountryCode1 Vg = new("VG");

    public static readonly IsocountryCode1 Vi = new("VI");

    public static readonly IsocountryCode1 Wf = new("WF");

    public static readonly IsocountryCode1 Eh = new("EH");

    public static readonly IsocountryCode1 Ye = new("YE");

    public static readonly IsocountryCode1 Zm = new("ZM");

    public static readonly IsocountryCode1 Zw = new("ZW");

    public static IsocountryCode1 FromValue(string value) => FromValueCore(value);
}
