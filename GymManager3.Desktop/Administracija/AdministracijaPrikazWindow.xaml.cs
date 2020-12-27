using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GymManager3.Desktop.Administracija
{
    /// <summary>
    /// Interaction logic for AdministracijaPrikazWindow.xaml
    /// </summary>
    public partial class AdministracijaPrikazWindow : Window
    {
        APIService _service = new APIService("Administracija");
        public AdministracijaPrikazWindow()
        {
            InitializeComponent();
        }

        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
        private async void btnPrikazi_click(object sender, RoutedEventArgs e)
        {
            ListView1.ClearValue(ItemsControl.ItemsSourceProperty);
            var listaAdministratora = await _service.Get<List<Model.Administracija>>(null);
            
            ListView1.ItemsSource = listaAdministratora;
        }
        private void btnNazad_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();
            Close();
        }
        private void btnDodaj_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new AdministracijaDodajWindow();
            Application.Current.MainWindow.Show();
            Close();
        }

        private async void ListView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var id = ListView1.SelectedValue;
            Model.Administracija admin = (Model.Administracija)id;
            Application.Current.MainWindow = new AdministracijaUpdateWindow(admin.AdministracijaID);
            Application.Current.MainWindow.Show();
            Close();
        }
    }
}
