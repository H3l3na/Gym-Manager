using GymManager3.Model.Requests;
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
    /// Interaction logic for UplateDodajWindow.xaml
    /// </summary>
    public partial class UplateDodajWindow : Window
    {
        APIService _servicePolaznik = new APIService("Polaznik");
        APIService _serviceAdmin = new APIService("Administracija");
        APIService _service = new APIService("Uplata");
        APIService _serviceSubskripcija = new APIService("Subskripcija");
        
        public UplateDodajWindow()
        {
            InitializeComponent();
            LoadPolaznici();
            LoadAdmins();
            LoadSubskripcije();
        }
        private async void LoadPolaznici()
        {
            var listaPolaznika = await _servicePolaznik.Get<IEnumerable<Model.Polaznik>>(null);
            cmbPolaznici.ItemsSource = listaPolaznika;
        }
        private async void LoadSubskripcije()
        {
            var listaSubskripcija = await _serviceSubskripcija.Get<IEnumerable<Model.Subskripcija>>(null);
            cmbSubskripcije.ItemsSource = listaSubskripcija;
        }
        private async void LoadAdmins()
        {
            var listaAdmina = await _serviceAdmin.Get<IEnumerable<Model.Administracija>>(null);
            cmbAdmini.ItemsSource = listaAdmina;
        }
        private void btnNazad_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new UplatePrikazWindow();
            Application.Current.MainWindow.Show();
            Close();
        }
        private async void btnSacuvaj_click(object sender, RoutedEventArgs e)
        {
            double value;
            if (textBoxSvrha.Text=="" || textBoxIznos.Text == "" || dtmUplate.SelectedDate==null || cmbPolaznici.SelectedValue == null || cmbAdmini.SelectedValue == null || cmbSubskripcije.SelectedValue==null)
            {
                errormessage.Text = "Sva polja su obavezna";
            }
            else if (!(double.TryParse(textBoxIznos.Text, out value)))
            {
                errormessage.Text = "Polje iznos mora biti broj";
            }
            else if (double.TryParse(textBoxIznos.Text, out value) && (double.Parse(textBoxIznos.Text)<10 || double.Parse(textBoxIznos.Text) > 5000))
            {
                errormessage.Text = "Polje iznos mora biti u rasponu od 10 do 5000";
            }
            else
            {
                
                UplataInsertRequest request = new UplataInsertRequest()
                {
                    Iznos=double.Parse(textBoxIznos.Text),
                    DatumUplate= DateTime.Parse(dtmUplate.ToString()),
                    Svrha =textBoxSvrha.Text,
                    AdministracijaId=(int)cmbAdmini.SelectedValue,
                    PolaznikId=(int)cmbPolaznici.SelectedValue,
                    SubskripcijaId=(int)cmbSubskripcije.SelectedValue
                };
                await _service.Insert<Model.Uplata>(request);
                Application.Current.MainWindow = new MainWindow();
                Application.Current.MainWindow.Show();
                Close();
            }
        }
    }
}
