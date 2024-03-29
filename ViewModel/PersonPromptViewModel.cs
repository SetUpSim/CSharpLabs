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
        public event EventHandler<ErrorEventArgs>? OnAnalysisEndedWithError;

        private async void ProceedToAnalysis()
        {
            OnStartComputingForAnalysis?.Invoke(this, EventArgs.Empty);
            try
            {
                Person.Instance = new Person(Name!, Surname!, Email!, (DateTime) Birthdate!);
                await Person.Instance.ComputePropertiesAsync();
            }
            catch (ArgumentException e)
            {
                OnAnalysisEndedWithError?.Invoke(this, new ErrorEventArgs(e.Message));
                return;
            }
            catch (FormatException e)
            {
                OnAnalysisEndedWithError?.Invoke(this, new ErrorEventArgs(e.Message));
                return;
            } 
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