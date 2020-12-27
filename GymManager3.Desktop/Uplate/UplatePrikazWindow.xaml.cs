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

namespace GymManager3.Desktop.Uplate
{
    /// <summary>
    /// Interaction logic for UplatePrikazWindow.xaml
    /// </summary>
    public partial class UplatePrikazWindow : Window
    {
        APIService _service = new APIService("Uplata");
        APIService _uplateService = new APIService("Uplate");
        public UplatePrikazWindow()
        {
            InitializeComponent();
        }
        private async void btnPrikazi_click(object sender, RoutedEventArgs e)
        {
            ListView1.ClearValue(ItemsControl.ItemsSourceProperty);
            var listaUplata = await _uplateService.Get<List<Model.uplate>>(null);
            //var listaUplata = await _service.Get<List<Model.Uplata>>(null);

            ListView1.ItemsSource = listaUplata;
        }
        private void btnNazad_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();
            Close();
        }
        private void btnDodaj_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new UplateDodajWindow();
            Application.Current.MainWindow.Show();
            Close();
        }

        private void ListView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var id = ListView1.SelectedValue;
            Model.uplate uplata = (Model.uplate)id;
            Application.Current.MainWindow = new UplateUpdateWindow(uplata.UplataId);
            Application.Current.MainWindow.Show();
            Close();
        }
    }
}
