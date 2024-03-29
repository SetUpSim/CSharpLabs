using Lab01Stasiuk.Model;
using System.Windows;

namespace Lab01Stasiuk.ViewModel
{
    internal class PersonInfoViewModel : ViewModelBase
    {
        private readonly Person _model;

        public string Name => _model.Name;
        public string Surname => _model.Surname;
        public string Email => _model.Email;
        public string Birthdate => _model.Birthdate.ToLongDateString();
        public string IsAdult => _model.IsAdult ? "Yes" : "No";
        public string SunSign => _model.SunZodiac.ToString();
        public string ChineseSign => _model.ChineseZodiac.ToString();
        public string IsBirthday => _model.IsBirthday ? "Yes" : "No";

        public PersonInfoViewModel()
        {
            _model = Person.Instance ?? new Person("Some name", "Some surname", "example@mail.com", DateTime.Today);

            var tooOld = _model.IsBirthdateOfATooOldPerson;
            var unborn = _model.IsBirthdateOfUnbornPerson;

            if (tooOld || unborn)
            {
                MessageBox.Show(Application.Current.MainWindow,
                    tooOld ?
                        "Looks like you're more than 135 years old. You're either mistaken or dead :(" :
                        "Seems like you haven't born yet. Please come back later"
                );
                Application.Current.Shutdown();
            }

            if (_model.IsBirthday)
            {
                MessageBox.Show(Application.Current.MainWindow, "Happy birthday!");
            }

        }
    }
}
