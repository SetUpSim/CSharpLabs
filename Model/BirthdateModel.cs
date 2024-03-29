namespace Lab01Stasiuk.Model
{
    internal class BirthdateModel
    {
        private static BirthdateModel? _instance;

        public static BirthdateModel Instance => _instance ??= new BirthdateModel();

        public DateTime? Birthdate { get; set; }

        public bool IsTodayBirthDay()
        {
            return Birthdate != null && Birthdate.Value == DateTime.Today;
        }

        public bool IsBirthdateOfUnbornPerson()
        {
            return Birthdate != null && Birthdate.Value > DateTime.Today;
        }

        public bool IsBirthdateOfATooOldPerson()
        {
            return Birthdate != null && Birthdate.Value <= DateTime.Today.AddYears(-135);
        }

        public int GetAge()
        {
            if (!Birthdate.HasValue)
            {
                return 0;
            }

            var today = DateTime.Today;

            var age = today.Year - Birthdate.Value.Year;

            if (Birthdate.Value > today.AddYears(-age)) age--;

            return age;
        }

        public string GetWesternZodiac()
        {
            if (!Birthdate.HasValue)
            {
                return "";
            }

            var month = Birthdate.Value.Month;
            var day = Birthdate.Value.Day;
            string[] zodiacSigns =
            {
                "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini",
                "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn"
            };
            var zodiacChangeDays = new[] {20, 19, 21, 20, 21, 21, 23, 23, 23, 23, 22, 22, 22};
            return day < zodiacChangeDays[month - 1] ? zodiacSigns[month - 1] : zodiacSigns[month];
        }

        public string GetChineseZodiac()
        {
            if (!Birthdate.HasValue)
            {
                return "";
            }

            var chineseZodiac = new[]
            {
                "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit",
                "Dragon", "Snake", "Horse", "Goat"
            };
            return chineseZodiac[Birthdate.Value.Year % 12];
        }
    }
}