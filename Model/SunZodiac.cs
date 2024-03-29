namespace Lab01Stasiuk.Model
{
    internal enum SunZodiac
    {
        Capricorn,
        Aquarius,
        Pisces,
        Aries,
        Taurus,
        Gemini,
        Cancer,
        Leo,
        Virgo,
        Libra,
        Scorpio,
        Sagittarius
    }

    internal static class SunZodiacMethods
    {
        internal static SunZodiac GetSunZodiac(this DateTime birthdate)
        {
            switch (birthdate.Month)
            {
                case 1:
                    return birthdate.Day <= 19 ? SunZodiac.Capricorn : SunZodiac.Aquarius;
                case 2:
                    return birthdate.Day <= 18 ? SunZodiac.Aquarius : SunZodiac.Pisces;
                case 3:
                    return birthdate.Day <= 20 ? SunZodiac.Pisces : SunZodiac.Aries;
                case 4:
                    return birthdate.Day <= 19 ? SunZodiac.Aries : SunZodiac.Taurus;
                case 5:
                    return birthdate.Day <= 20 ? SunZodiac.Taurus : SunZodiac.Gemini;
                case 6:
                    return birthdate.Day <= 20 ? SunZodiac.Gemini : SunZodiac.Cancer;
                case 7:
                    return birthdate.Day <= 22 ? SunZodiac.Cancer : SunZodiac.Leo;
                case 8:
                    return birthdate.Day <= 22 ? SunZodiac.Leo : SunZodiac.Virgo;
                case 9:
                    return birthdate.Day <= 22 ? SunZodiac.Virgo : SunZodiac.Libra;
                case 10:
                    return birthdate.Day <= 22 ? SunZodiac.Libra : SunZodiac.Scorpio;
                case 11:
                    return birthdate.Day <= 21 ? SunZodiac.Scorpio : SunZodiac.Sagittarius;
                case 12:
                    return birthdate.Day <= 21 ? SunZodiac.Sagittarius : SunZodiac.Capricorn;
                default:
                    return SunZodiac.Capricorn;
            }
        }
    }
}