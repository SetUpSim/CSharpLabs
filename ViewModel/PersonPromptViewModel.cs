using Lab01Stasiuk.Utils;
using System.Windows.Input;
using Lab01Stasiuk.Model;

namespace Lab01Stasiuk.ViewModel
{
    class PersonPromptViewModel : ViewModelBase
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public DateTime? Birthdate { get; set; }

        public ICommand ProceedCommand => new RelayCommand(
            execute: _ => ProceedToAnalysis(),
            canExecute: _ => CanProceed()
        );

        public event EventHandler? OnProceedToAnalysis;
        public event EventHandler? OnStartComputingForAnalysis;

        private async void ProceedToAnalysis()
        {
            Person.Instance = new Person(Name!, Surname!, Email!, (DateTime) Birthdate!);
            OnStartComputingForAnalysis?.Invoke(this, EventArgs.Empty);
            await Person.Instance.ComputePropertiesAsync();
            OnProceedToAnalysis?.Invoke(this, EventArgs.Empty);
        }

        private bool CanProceed()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Surname) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   Birthdate != null;
        }
    }
}