namespace Lab01Stasiuk.Model
{
    internal enum ChineseZodiac
    {
        Monkey,
        Rooster,
        Dog,
        Pig,
        Rat,
        Ox,
        Tiger,
        Rabbit,
        Dragon,
        Snake,
        Horse,
        Goat
    }

    internal static class ChineseZodiacMethods
    {
        internal static ChineseZodiac GetChineseZodiac(this DateTime birthdate)
        {
            return Enum.GetValues<ChineseZodiac>().ToArray()[birthdate.Year % 12];
        }
    }
}