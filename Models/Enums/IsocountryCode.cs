using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<IsocountryCode>))]
public sealed record IsocountryCode : StringEnum<IsocountryCode>
{
    private IsocountryCode(string value) : base(value)
    {
    }

    public static readonly IsocountryCode Abw = new("ABW");

    public static readonly IsocountryCode Afg = new("AFG");

    public static readonly IsocountryCode Ago = new("AGO");

    public static readonly IsocountryCode Aia = new("AIA");

    public static readonly IsocountryCode Ala = new("ALA");

    public static readonly IsocountryCode Alb = new("ALB");

    public static readonly IsocountryCode And = new("AND");

    public static readonly IsocountryCode Are = new("ARE");

    public static readonly IsocountryCode Arg = new("ARG");

    public static readonly IsocountryCode Arm = new("ARM");

    public static readonly IsocountryCode Asm = new("ASM");

    public static readonly IsocountryCode Ata = new("ATA");

    public static readonly IsocountryCode Atf = new("ATF");

    public static readonly IsocountryCode Atg = new("ATG");

    public static readonly IsocountryCode Aus = new("AUS");

    public static readonly IsocountryCode Aut = new("AUT");

    public static readonly IsocountryCode Aze = new("AZE");

    public static readonly IsocountryCode Bdi = new("BDI");

    public static readonly IsocountryCode Bel = new("BEL");

    public static readonly IsocountryCode Ben = new("BEN");

    public static readonly IsocountryCode Bes = new("BES");

    public static readonly IsocountryCode Bfa = new("BFA");

    public static readonly IsocountryCode Bgd = new("BGD");

    public static readonly IsocountryCode Bgr = new("BGR");

    public static readonly IsocountryCode Bhr = new("BHR");

    public static readonly IsocountryCode Bhs = new("BHS");

    public static readonly IsocountryCode Bih = new("BIH");

    public static readonly IsocountryCode Blm = new("BLM");

    public static readonly IsocountryCode Blr = new("BLR");

    public static readonly IsocountryCode Blz = new("BLZ");

    public static readonly IsocountryCode Bmu = new("BMU");

    public static readonly IsocountryCode Bol = new("BOL");

    public static readonly IsocountryCode Bra = new("BRA");

    public static readonly IsocountryCode Brb = new("BRB");

    public static readonly IsocountryCode Brn = new("BRN");

    public static readonly IsocountryCode Btn = new("BTN");

    public static readonly IsocountryCode Bvt = new("BVT");

    public static readonly IsocountryCode Bwa = new("BWA");

    public static readonly IsocountryCode Caf = new("CAF");

    public static readonly IsocountryCode Can = new("CAN");

    public static readonly IsocountryCode Cck = new("CCK");

    public static readonly IsocountryCode Che = new("CHE");

    public static readonly IsocountryCode Chl = new("CHL");

    public static readonly IsocountryCode Chn = new("CHN");

    public static readonly IsocountryCode Civ = new("CIV");

    public static readonly IsocountryCode Cmr = new("CMR");

    public static readonly IsocountryCode Cod = new("COD");

    public static readonly IsocountryCode Cog = new("COG");

    public static readonly IsocountryCode Cok = new("COK");

    public static readonly IsocountryCode Col = new("COL");

    public static readonly IsocountryCode Com = new("COM");

    public static readonly IsocountryCode Cpv = new("CPV");

    public static readonly IsocountryCode Cri = new("CRI");

    public static readonly IsocountryCode Cub = new("CUB");

    public static readonly IsocountryCode Cuw = new("CUW");

    public static readonly IsocountryCode Cxr = new("CXR");

    public static readonly IsocountryCode Cym = new("CYM");

    public static readonly IsocountryCode Cyp = new("CYP");

    public static readonly IsocountryCode Cze = new("CZE");

    public static readonly IsocountryCode Deu = new("DEU");

    public static readonly IsocountryCode Dji = new("DJI");

    public static readonly IsocountryCode Dma = new("DMA");

    public static readonly IsocountryCode Dnk = new("DNK");

    public static readonly IsocountryCode Dom = new("DOM");

    public static readonly IsocountryCode Dza = new("DZA");

    public static readonly IsocountryCode Ecu = new("ECU");

    public static readonly IsocountryCode Egy = new("EGY");

    public static readonly IsocountryCode Eri = new("ERI");

    public static readonly IsocountryCode Esh = new("ESH");

    public static readonly IsocountryCode Esp = new("ESP");

    public static readonly IsocountryCode Est = new("EST");

    public static readonly IsocountryCode Eth = new("ETH");

    public static readonly IsocountryCode Fin = new("FIN");

    public static readonly IsocountryCode Fji = new("FJI");

    public static readonly IsocountryCode Flk = new("FLK");

    public static readonly IsocountryCode Fra = new("FRA");

    public static readonly IsocountryCode Fro = new("FRO");

    public static readonly IsocountryCode Fsm = new("FSM");

    public static readonly IsocountryCode Gab = new("GAB");

    public static readonly IsocountryCode Gbr = new("GBR");

    public static readonly IsocountryCode Geo = new("GEO");

    public static readonly IsocountryCode Ggy = new("GGY");

    public static readonly IsocountryCode Gha = new("GHA");

    public static readonly IsocountryCode Gib = new("GIB");

    public static readonly IsocountryCode Gin = new("GIN");

    public static readonly IsocountryCode Glp = new("GLP");

    public static readonly IsocountryCode Gmb = new("GMB");

    public static readonly IsocountryCode Gnb = new("GNB");

    public static readonly IsocountryCode Gnq = new("GNQ");

    public static readonly IsocountryCode Grc = new("GRC");

    public static readonly IsocountryCode Grd = new("GRD");

    public static readonly IsocountryCode Grl = new("GRL");

    public static readonly IsocountryCode Gtm = new("GTM");

    public static readonly IsocountryCode Guf = new("GUF");

    public static readonly IsocountryCode Gum = new("GUM");

    public static readonly IsocountryCode Guy = new("GUY");

    public static readonly IsocountryCode Hkg = new("HKG");

    public static readonly IsocountryCode Hmd = new("HMD");

    public static readonly IsocountryCode Hnd = new("HND");

    public static readonly IsocountryCode Hrv = new("HRV");

    public static readonly IsocountryCode Hti = new("HTI");

    public static readonly IsocountryCode Hun = new("HUN");

    public static readonly IsocountryCode Idn = new("IDN");

    public static readonly IsocountryCode Imn = new("IMN");

    public static readonly IsocountryCode Ind = new("IND");

    public static readonly IsocountryCode Iot = new("IOT");

    public static readonly IsocountryCode Irl = new("IRL");

    public static readonly IsocountryCode Irn = new("IRN");

    public static readonly IsocountryCode Irq = new("IRQ");

    public static readonly IsocountryCode Isl = new("ISL");

    public static readonly IsocountryCode Isr = new("ISR");

    public static readonly IsocountryCode Ita = new("ITA");

    public static readonly IsocountryCode Jam = new("JAM");

    public static readonly IsocountryCode Jey = new("JEY");

    public static readonly IsocountryCode Jor = new("JOR");

    public static readonly IsocountryCode Jpn = new("JPN");

    public static readonly IsocountryCode Kaz = new("KAZ");

    public static readonly IsocountryCode Ken = new("KEN");

    public static readonly IsocountryCode Kgz = new("KGZ");

    public static readonly IsocountryCode Khm = new("KHM");

    public static readonly IsocountryCode Kir = new("KIR");

    public static readonly IsocountryCode Kna = new("KNA");

    public static readonly IsocountryCode Kor = new("KOR");

    public static readonly IsocountryCode Kwt = new("KWT");

    public static readonly IsocountryCode Lao = new("LAO");

    public static readonly IsocountryCode Lbn = new("LBN");

    public static readonly IsocountryCode Lbr = new("LBR");

    public static readonly IsocountryCode Lby = new("LBY");

    public static readonly IsocountryCode Lca = new("LCA");

    public static readonly IsocountryCode Lie = new("LIE");

    public static readonly IsocountryCode Lka = new("LKA");

    public static readonly IsocountryCode Lso = new("LSO");

    public static readonly IsocountryCode Ltu = new("LTU");

    public static readonly IsocountryCode Lux = new("LUX");

    public static readonly IsocountryCode Lva = new("LVA");

    public static readonly IsocountryCode Mac = new("MAC");

    public static readonly IsocountryCode Maf = new("MAF");

    public static readonly IsocountryCode Mar = new("MAR");

    public static readonly IsocountryCode Mco = new("MCO");

    public static readonly IsocountryCode Mda = new("MDA");

    public static readonly IsocountryCode Mdg = new("MDG");

    public static readonly IsocountryCode Mdv = new("MDV");

    public static readonly IsocountryCode Mex = new("MEX");

    public static readonly IsocountryCode Mhl = new("MHL");

    public static readonly IsocountryCode Mkd = new("MKD");

    public static readonly IsocountryCode Mli = new("MLI");

    public static readonly IsocountryCode Mlt = new("MLT");

    public static readonly IsocountryCode Mmr = new("MMR");

    public static readonly IsocountryCode Mne = new("MNE");

    public static readonly IsocountryCode Mng = new("MNG");

    public static readonly IsocountryCode Mnp = new("MNP");

    public static readonly IsocountryCode Moz = new("MOZ");

    public static readonly IsocountryCode Mrt = new("MRT");

    public static readonly IsocountryCode Msr = new("MSR");

    public static readonly IsocountryCode Mtq = new("MTQ");

    public static readonly IsocountryCode Mus = new("MUS");

    public static readonly IsocountryCode Mwi = new("MWI");

    public static readonly IsocountryCode Mys = new("MYS");

    public static readonly IsocountryCode Myt = new("MYT");

    public static readonly IsocountryCode Nam = new("NAM");

    public static readonly IsocountryCode Ncl = new("NCL");

    public static readonly IsocountryCode Ner = new("NER");

    public static readonly IsocountryCode Nfk = new("NFK");

    public static readonly IsocountryCode Nga = new("NGA");

    public static readonly IsocountryCode Nic = new("NIC");

    public static readonly IsocountryCode Niu = new("NIU");

    public static readonly IsocountryCode Nld = new("NLD");

    public static readonly IsocountryCode Nor = new("NOR");

    public static readonly IsocountryCode Npl = new("NPL");

    public static readonly IsocountryCode Nru = new("NRU");

    public static readonly IsocountryCode Nzl = new("NZL");

    public static readonly IsocountryCode Omn = new("OMN");

    public static readonly IsocountryCode Pak = new("PAK");

    public static readonly IsocountryCode Pan = new("PAN");

    public static readonly IsocountryCode Pcn = new("PCN");

    public static readonly IsocountryCode Per = new("PER");

    public static readonly IsocountryCode Phl = new("PHL");

    public static readonly IsocountryCode Plw = new("PLW");

    public static readonly IsocountryCode Png = new("PNG");

    public static readonly IsocountryCode Pol = new("POL");

    public static readonly IsocountryCode Pri = new("PRI");

    public static readonly IsocountryCode Prk = new("PRK");

    public static readonly IsocountryCode Prt = new("PRT");

    public static readonly IsocountryCode Pry = new("PRY");

    public static readonly IsocountryCode Pse = new("PSE");

    public static readonly IsocountryCode Pyf = new("PYF");

    public static readonly IsocountryCode Qat = new("QAT");

    public static readonly IsocountryCode Reu = new("REU");

    public static readonly IsocountryCode Rou = new("ROU");

    public static readonly IsocountryCode Rus = new("RUS");

    public static readonly IsocountryCode Rwa = new("RWA");

    public static readonly IsocountryCode Sau = new("SAU");

    public static readonly IsocountryCode Sdn = new("SDN");

    public static readonly IsocountryCode Sen = new("SEN");

    public static readonly IsocountryCode Sgp = new("SGP");

    public static readonly IsocountryCode Sgs = new("SGS");

    public static readonly IsocountryCode Shn = new("SHN");

    public static readonly IsocountryCode Sjm = new("SJM");

    public static readonly IsocountryCode Slb = new("SLB");

    public static readonly IsocountryCode Sle = new("SLE");

    public static readonly IsocountryCode Slv = new("SLV");

    public static readonly IsocountryCode Smr = new("SMR");

    public static readonly IsocountryCode Som = new("SOM");

    public static readonly IsocountryCode Spm = new("SPM");

    public static readonly IsocountryCode Srb = new("SRB");

    public static readonly IsocountryCode Ssd = new("SSD");

    public static readonly IsocountryCode Stp = new("STP");

    public static readonly IsocountryCode Sur = new("SUR");

    public static readonly IsocountryCode Svk = new("SVK");

    public static readonly IsocountryCode Svn = new("SVN");

    public static readonly IsocountryCode Swe = new("SWE");

    public static readonly IsocountryCode Swz = new("SWZ");

    public static readonly IsocountryCode Sxm = new("SXM");

    public static readonly IsocountryCode Syc = new("SYC");

    public static readonly IsocountryCode Syr = new("SYR");

    public static readonly IsocountryCode Tca = new("TCA");

    public static readonly IsocountryCode Tcd = new("TCD");

    public static readonly IsocountryCode Tgo = new("TGO");

    public static readonly IsocountryCode Tha = new("THA");

    public static readonly IsocountryCode Tjk = new("TJK");

    public static readonly IsocountryCode Tkl = new("TKL");

    public static readonly IsocountryCode Tkm = new("TKM");

    public static readonly IsocountryCode Tls = new("TLS");

    public static readonly IsocountryCode Ton = new("TON");

    public static readonly IsocountryCode Tto = new("TTO");

    public static readonly IsocountryCode Tun = new("TUN");

    public static readonly IsocountryCode Tur = new("TUR");

    public static readonly IsocountryCode Tuv = new("TUV");

    public static readonly IsocountryCode Twn = new("TWN");

    public static readonly IsocountryCode Tza = new("TZA");

    public static readonly IsocountryCode Uga = new("UGA");

    public static readonly IsocountryCode Ukr = new("UKR");

    public static readonly IsocountryCode Umi = new("UMI");

    public static readonly IsocountryCode Ury = new("URY");

    public static readonly IsocountryCode Usa = new("USA");

    public static readonly IsocountryCode Uzb = new("UZB");

    public static readonly IsocountryCode Vat = new("VAT");

    public static readonly IsocountryCode Vct = new("VCT");

    public static readonly IsocountryCode Ven = new("VEN");

    public static readonly IsocountryCode Vgb = new("VGB");

    public static readonly IsocountryCode Vir = new("VIR");

    public static readonly IsocountryCode Vnm = new("VNM");

    public static readonly IsocountryCode Vut = new("VUT");

    public static readonly IsocountryCode Wlf = new("WLF");

    public static readonly IsocountryCode Wsm = new("WSM");

    public static readonly IsocountryCode Yem = new("YEM");

    public static readonly IsocountryCode Zaf = new("ZAF");

    public static readonly IsocountryCode Zmb = new("ZMB");

    public static readonly IsocountryCode Zwe = new("ZWE");

    public static IsocountryCode FromValue(string value) => FromValueCore(value);
}
