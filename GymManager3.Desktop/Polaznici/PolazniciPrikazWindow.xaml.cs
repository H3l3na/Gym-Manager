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

namespace GymManager3.Desktop.Polaznici
{
    /// <summary>
    /// Interaction logic for PolazniciPrikazWindow.xaml
    /// </summary>
    public partial class PolazniciPrikazWindow : Window
    {
        APIService _service = new APIService("Polaznik");
        public PolazniciPrikazWindow()
        {
            InitializeComponent();
        }
        private async void btnPrikazi_click(object sender, RoutedEventArgs e)
        {
            ListView1.Items.Clear();
            var listaPolaznika = await _service.Get<List<Model.Polaznik>>(null);

            ListView1.ItemsSource = listaPolaznika;
        }
        private void btnNazad_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();
            Close();
        }
        private void btnDodaj_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new PolazniciDodajWindow();
            Application.Current.MainWindow.Show();
            Close();
        }

        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private async void ListView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var id = ListView1.SelectedValue;
            Model.Polaznik polaznik = (Model.Polaznik)id;
            Application.Current.MainWindow = new PolazniciUpdateWindow(polaznik.PolaznikId);
            Application.Current.MainWindow.Show();
            Close();
        }
    }
}
