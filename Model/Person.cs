using System.Text.RegularExpressions;
using Lab01Stasiuk.Exceptions;

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

        public Person(string name, string surname, string email, DateTime birthdate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Birthdate = birthdate;

            CheckEmailFormat(email);
        }

        public Person(string name, string surname, string email) : this(name, surname, email, default)
        {
        }

        public Person(string name, string surname, DateTime birthDate) : this(name, surname, "", birthDate)
        {
        }

        private static void CheckEmailFormat(string email)
        {
            if (!Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                throw new EmailFormatException("Provided email is of invalid format");
            }
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
            var isBirthdateOfUnbornPersonTask = Task.Run(() => Birthdate > DateTime.Today);
            var isBirthdateOfATooOldPersonTask = Task.Run(() => Birthdate <= DateTime.Today.AddYears(-135));
            var syntheticTask = Task.Delay(1500); // Synthetic task to demonstrate asynchronicity

            await Task.WhenAll(isAdultTask, sunZodiacTask, chineseZodiacTask, isBirthdateTask,
                isBirthdateOfUnbornPersonTask, isBirthdateOfATooOldPersonTask, syntheticTask);

            IsAdult = isAdultTask.Result;
            SunZodiac = sunZodiacTask.Result;
            ChineseZodiac = chineseZodiacTask.Result;
            IsBirthday = isBirthdateTask.Result;
            if (isBirthdateOfUnbornPersonTask.Result)
            {
                throw new UnbornPersonException("Seems like you haven't born yet. Please come back later");
            }

            if (isBirthdateOfATooOldPersonTask.Result)
            {
                throw new TooOldPersonException("Looks like you're more than 135 years old. You're either mistaken or dead");
            }
        }
    }
}