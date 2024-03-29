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
    /// Interaction logic for BirthdatePromptWindow.xaml
    /// </summary>
    public partial class BirthdatePromptWindow : Window
    {
        public BirthdatePromptWindow()
        {
            InitializeComponent();
            var vm = new BirthdatePromptViewModel();
            DataContext = vm;
            vm.OnProceedToAnalysis += (s, e) =>
            {
                var analysisWindow = new BirthdateAnalysisWindow();
                Application.Current.MainWindow = analysisWindow;
                analysisWindow.Show();
                Close();
            };

        }
    }
}
