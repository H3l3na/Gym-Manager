using GymManager3.Desktop.Administracija;
using GymManager3.Desktop.Polaznici;
using GymManager3.Desktop.Termini;
using GymManager3.Desktop.Treneri;
using GymManager3.Desktop.Treninzi;
using GymManager3.Desktop.Uplate;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GymManager3.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new AdministracijaPrikazWindow();
            Application.Current.MainWindow.Show();
            Close();
        }
        private void btnPolaznik_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new PolazniciPrikazWindow();
            Application.Current.MainWindow.Show();
            Close();
        }
        private void btnTrener_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new TreneriPrikazWindow();
            Application.Current.MainWindow.Show();
            Close();
        }
        private void btnTrening_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new TreninziPrikazWindow();
            Application.Current.MainWindow.Show();
            Close();
        }
        private void btnUplate_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new UplatePrikazWindow();
            Application.Current.MainWindow.Show();
            Close();
        }
        private void btnTermini_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new TerminiPrikazWindow();
            Application.Current.MainWindow.Show();
            Close();
        }
    }
}
