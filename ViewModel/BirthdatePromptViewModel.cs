using Lab01Stasiuk.Utils;
using System.Windows.Input;
using Lab01Stasiuk.Model;

namespace Lab01Stasiuk.ViewModel
{
    class BirthdatePromptViewModel : ViewModelBase
    {
        private readonly BirthdateModel _model = BirthdateModel.Instance;
        private DateTime? _birthDate;
        
        public ICommand ProceedCommand => new RelayCommand(
            execute: (_) => ProceedToAnalysis(),
            canExecute: _ => BirthDate != null
        );

        public event EventHandler OnProceedToAnalysis;


        public BirthdatePromptViewModel()
        {
        }

        public DateTime? BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                _model.Birthdate = value;
            }
        }

        private void ProceedToAnalysis()
        {
            OnProceedToAnalysis(this, EventArgs.Empty);
        }
    }
}