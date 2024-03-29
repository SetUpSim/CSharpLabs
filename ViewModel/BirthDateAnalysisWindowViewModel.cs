using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lab01Stasiuk.Model;

namespace Lab01Stasiuk.ViewModel
{
    internal class BirthDateAnalysisWindowViewModel : ViewModelBase
    {
        private readonly BirthdateModel _model = BirthdateModel.Instance;

        public int Age => _model.GetAge();
        public string WesternZodiac => _model.GetWesternZodiac();
        public string ChineseZodiac => _model.GetChineseZodiac();

        public BirthDateAnalysisWindowViewModel()
        {
            var tooOld = _model.IsBirthdateOfATooOldPerson();
            var unborn = _model.IsBirthdateOfUnbornPerson();

            if (tooOld || unborn)
            {
                MessageBox.Show(Application.Current.MainWindow,
                    tooOld ?
                        "Looks like you're more than 135 years old. You're either mistaken or dead :(" :
                        "Seems like you haven't born yet. Please come back later"
                );
                Application.Current.Shutdown();
            }

            if (_model.IsTodayBirthDay())
            {
                MessageBox.Show(Application.Current.MainWindow, "Happy birthday!");
            }

        }
    }
}
