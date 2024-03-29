using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Lab01Stasiuk.ViewModel;

namespace Lab01Stasiuk.View
{
    /// <summary>
    /// Interaction logic for PersonPromptWindow.xaml
    /// </summary>
    public partial class PersonPromptWindow : Window
    {
        public PersonPromptWindow()
        {
            InitializeComponent();

            var vm = new PersonPromptViewModel();
            DataContext = vm;

            vm.OnStartComputingForAnalysis += (s, e) => { IsEnabled = false; };
            vm.OnAnalysisEndedWithError += (s, e) =>
            {
                MessageBox.Show(this, e.Message);
                Close();
            };
            vm.OnProceedToAnalysis += (s, e) =>
            {
                IsEnabled = true;
                var analysisWindow = new PersonInfoWindow();
                Application.Current.MainWindow = analysisWindow;
                analysisWindow.Show();
                Close();
            };
        }
    }
}