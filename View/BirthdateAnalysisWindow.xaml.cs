using System.Windows;
using Lab01Stasiuk.Model;
using Lab01Stasiuk.ViewModel;

namespace Lab01Stasiuk.View
{
    /// <summary>
    /// Interaction logic for BirthdateAnalysisWindow.xaml
    /// </summary>
    public partial class BirthdateAnalysisWindow : Window
    {
        public BirthdateAnalysisWindow()
        {
            InitializeComponent();
            DataContext = new BirthDateAnalysisWindowViewModel();
        }
    }
}