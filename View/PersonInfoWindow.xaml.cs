using System.Windows;
using Lab01Stasiuk.Model;
using Lab01Stasiuk.ViewModel;

namespace Lab01Stasiuk.View
{
    /// <summary>
    /// Interaction logic for PersonInfoWindow.xaml
    /// </summary>
    public partial class PersonInfoWindow : Window
    {
        public PersonInfoWindow()
        {
            InitializeComponent();
            DataContext = new PersonInfoViewModel();
        }
    }
}