using GymManager3.Desktop.Polaznici;
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

namespace GymManager3.Desktop.Treneri
{
    /// <summary>
    /// Interaction logic for TreneriPrikazWindow.xaml
    /// </summary>
    public partial class TreneriPrikazWindow : Window
    {
        APIService _service = new APIService("Treneri");
        public TreneriPrikazWindow()
        {
            InitializeComponent();
        }
        private async void btnPrikazi_click(object sender, RoutedEventArgs e)
        {
            ListView1.ClearValue(ItemsControl.ItemsSourceProperty);
            var listaTrenera = await _service.Get<List<Model.Trener>>(null);

            ListView1.ItemsSource = listaTrenera;
        }
        private void btnNazad_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();
            Close();
        }
        private void btnDodaj_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new TreneriWindowDodaj();
            Application.Current.MainWindow.Show();
            Close();
        }

        private void ListView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var id = ListView1.SelectedValue;
            Model.Trener trener = (Model.Trener)id;
            Application.Current.MainWindow = new TreneriUpdateWindow(trener.TrenerId);
            Application.Current.MainWindow.Show();
            Close();
        }
    }
}
