using System;
//using static Java.Util.Jar.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TravelApp
{
    public enum Europe
    {
        Albania,
        Andrroa,
        Austria,
        Belgium,
        Belarus,
        [Display(Name = "Bosnia and Herzegovina")]
        BosniaAndHerzegovina,
        Bulgaria,
        Coratia,
        Cyprus,
        Czechia,
        Denmark,
        England,
        Estonia,
        Finland,
        France,
        Germany,
        Greece,
        Guernsey,
        Hungary,
        Iceland,
        Ireland,
        Italy,
        Kosovo,
        Latvia,
        Liechtenstein,
        Lithunia,
        Luxembourg,
        Malta,
        Moldova,
        Monaco,
        Montenegro,
        Netherlands,
        Macedonia,
        Norway,
        Poland,
        Portugal,
        Romania,
        Russia,
        [Display(Name = "San Marino")]
        SanMarino,
        Scotland,
        Serbia,
        Slovakia,
        Slovenia,
        Spain,
        Sweden,
        Switzerland,
        Turkey,
        Ukraine,
        [Display(Name = "United Kingdom")]
        UnitedKingdom,
        [Display(Name = "Vatican City")]
        VaticanCity,

    }

    public enum Asia
    {
        Afghanistan,
        Armenia,
        Azerbaijan,
        Bahrain,
        Bangladesh,
        Bhutan,
        Brunei,
        Cambodia,
        China,
        Cyprus,
        Georgia,
        India,
        Indonesia,
        Iran,
        Iraq,
        Israel,
        Japan,
        Jordan,
        Kazakhstan,
        Kuwait,
        Kyrgyzstan,
        Laos,
        Lebanon,
        Malaysia,
        Maldives,
        Mongolia,
        Myanmar,
        Nepal,
        [Display(Name = "North Korea")]
        NorthKorea,
        Oman,
        Pakistan,
        Palestine,
        Philippines,
        Qatar,
        [Display(Name = "Asian Russia")]
        AsianRussia,
        [Display(Name = "Saudi Arabia")]
        SaudiArabia,
        Singapore,
        [Display(Name = "South Korea")]
        SouthKorea,
        [Display(Name = "Sri Lanka")]
        SriLanka,
        Syria,
        Taiwan,
        Tajikistan,
        Thailand,
        [Display(Name = "Timor Leste")]
        TimorLeste,
        [Display(Name = "Asian Turkey")]
        AsianTurkey,
        Turkmenistan,
        [Display(Name = "Unisted Arab Emirates")]
        UnitedArabEmirates,
        Uzbekistan,
        Vietnam,
        Yemen,
    }

    public enum Africa
    {
        Algeria,
        Angola,
        Benin,
        Botswana,
        [Display(Name = "Burkina Faso")]
        BurkinaFaso,
        Burundi,
        [Display(Name = "Cape Verde")]
        CapeVerde,
        Cameroon,
        [Display(Name = "Central African Republic")]
        CentralAfricanRepublic,
        Chad,
        Comoros,
        Congo,
        Djibouti,
        Egypt,
        [Display(Name = "Equatorial Guinea")]
        EquatorialGuinea,
        Eritrea,
        Eswatini,
        Ethiopia,
        Gabon,
        Gambia,
        Ghana,
        Guinea,
        [Display(Name = "Guinea-Bissau")]
        GuineaBissau,
        [Display(Name = "Ivory Coast")]
        IvoryCoast,
        Kenya,
        Lesotho,
        Liberia,
        Libya,
        Madagascar,
        Malawi,
        Mali,
        Mauritania,
        Mauritius,
        Morocco,
        Mozambique,
        Namibia,
        Niger,
        Nigeria,
        Rwanda,
        [Display(Name = "Sao Tome and Principe")]
        SaoTomeAndPrincipe,
        Senegal,
        Seychelles,
        [Display(Name = "Sierra Leone")]
        SierraLeone,
        Somalia,
        [Display(Name = "South Africa")]
        SouthAfrica,
        [Display(Name = "South Sudan")]
        SouthSudan,
        Sudan,
        Tanzania,
        Togo,
        Tunisia,
        Uganda,
        Zambia,
        Zimbabwe
    }

    public enum SouthAmerica
    {
        Argentina,
        Bolivia,
        Brazil,
        Chile,
        Ecuador,
        Guyana,
        Colombia,
        Paraguay,
        Peru,
        Suriname,
        Uruguay,
        Venezuela
    }

    public enum NorthAmerica
    {
        Canada,
        [Display(Name = "United States")]
        UnitedStates,
        Mexico,
        Belize,
        [Display(Name = "Costa Rica")]
        CostaRica,
        [Display(Name = "El Salvador")]
        ElSalvador,
        Guatemala,
        Honduras,
        Nicaragua,
        Panama
    }

    public enum Oceania
    {
        Australia,
        [Display(Name = "New Zealand")]
        NewZealand,
        Fiji,
        [Display(Name = "Papua New Guinea")]
        PapuaNewGuinea,
        [Display(Name = "Marshall Islands")]
        MarshallIslands,
        Kiribati,
        Micronesia,
        Palau,
        Samoa,
        Tonga,
        Tuvalu,
        Vanuatu,
        [Display(Name = "Solomon Islands")]
        SolomonIslands,
        Nauru,
    }
}

