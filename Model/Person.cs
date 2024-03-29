namespace Lab01Stasiuk.Model
{
    internal class Person
    {
        public static Person? Instance;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }

        public bool IsAdult { get; private set; }
        public SunZodiac SunZodiac { get; private set; }
        public ChineseZodiac ChineseZodiac { get; private set; }
        public bool IsBirthday { get; private set; }
        public bool IsBirthdateOfUnbornPerson { get; private set; }
        public bool IsBirthdateOfATooOldPerson { get; private set; }

        public Person(string name, string surname, string email, DateTime birthdate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Birthdate = birthdate;
        }

        public Person(string name, string surname, string email) : this(name, surname, email, default)
        {
        }

        public Person(string name, string surname, DateTime birthDate) : this(name, surname, "", birthDate)
        {
        }

        public async Task ComputePropertiesAsync()
        {
            var isAdultTask = Task.Run(() => Birthdate.AddYears(18) <= DateTime.Today);
            var sunZodiacTask = Task.Run(() => Birthdate.GetSunZodiac());
            var chineseZodiacTask = Task.Run(() => Birthdate.GetChineseZodiac());
            var isBirthdateTask = Task.Run(() =>
                Birthdate.Day == DateTime.Today.Day &&
                Birthdate.Month == DateTime.Today.Month
            );
            var isBirthdateOfUnbornPerson = Task.Run(() => Birthdate > DateTime.Today);
            var isBirthdateOfATooOldPerson = Task.Run(() => Birthdate <= DateTime.Today.AddYears(-135));
            var syntheticTask = Task.Delay(1500); // Synthetic task to demonstrate asynchronicity

            await Task.WhenAll(isAdultTask, sunZodiacTask, chineseZodiacTask, isBirthdateTask, isBirthdateOfUnbornPerson, isBirthdateOfATooOldPerson, syntheticTask);

            IsAdult = isAdultTask.Result;
            SunZodiac = sunZodiacTask.Result;
            ChineseZodiac = chineseZodiacTask.Result;
            IsBirthday = isBirthdateTask.Result;
            IsBirthdateOfUnbornPerson = isBirthdateOfUnbornPerson.Result;
            IsBirthdateOfATooOldPerson = isBirthdateOfATooOldPerson.Result;
        }
    }
}